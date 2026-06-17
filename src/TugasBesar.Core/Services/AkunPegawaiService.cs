using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Models;
using TugasBesar.Core.Repositories.Interfaces;
using TugasBesar.Core.Services.Interfaces;
using TugasBesar.Core.Factories;
using TugasBesar.Core.Security;

namespace TugasBesar.Core.Services
{
    /// <summary>
    /// Layanan bisnis asinkron untuk penanganan data akun pegawai.
    /// Menggunakan repository pattern dan factory pattern.
    /// </summary>
    public class AkunPegawaiService : IAkunPegawaiServices
    {
        private readonly IAkunPegawaiRepository _repository;
        private readonly IAkunPegawaiFactory _factory;

        public AkunPegawaiService(IAkunPegawaiRepository repository, IAkunPegawaiFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public async Task<IReadOnlyList<AkunResponseDTO>> GetAll()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(a => new AkunResponseDTO
            {
                Id = a.id,
                Name = a.nama,
                Role = a.role
            }).ToList();
        }

        public async Task Tambah(AkunRequestDTO request)
        {
            var newName = request.name.Trim();
            var list = await _repository.GetAllAsync();

            if (list.Any(a => string.Equals(a.nama?.Trim(), newName, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Username pegawai sudah ada!");

            // Hash password sebelum disimpan
            var hashedPassword = PasswordHasher.HashPassword(request.password);
            var akunBaru = _factory.Create(request.name, hashedPassword);
            await _repository.AddAsync(akunBaru);
        }

        public async Task Edit(long id, AkunRequestDTO request)
        {
            var newName = request.name.Trim();
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                throw new Exception("Data tidak ditemukan!");

            // Verifikasi password lama yang ter-hash dengan password baru masukan
            bool isPasswordSame = PasswordHasher.VerifyPassword(existing.password, request.password);
            if (string.Equals((existing.nama ?? string.Empty).Trim(), newName, StringComparison.OrdinalIgnoreCase) && isPasswordSame)
                throw new Exception("Data masih sama!");

            var list = await _repository.GetAllAsync();
            if (list.Where(a => a.id != id).Any(a => string.Equals(a.nama?.Trim(), newName, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Username pegawai sudah ada!");

            existing.nama = newName;
            existing.nama_user = newName;
            existing.password = PasswordHasher.HashPassword(request.password);
            await _repository.UpdateAsync(existing);
        }

        public async Task Hapus(long id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                throw new Exception("Data tidak valid!");

            await _repository.DeleteAsync(id);
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO request)
        {
            var username = request.Username.Trim();
            var list = await _repository.GetAllAsync();

            var user = list.FirstOrDefault(a => string.Equals(a.nama?.Trim(), username, StringComparison.OrdinalIgnoreCase));
            if (user == null)
            {
                return new LoginResponseDTO
                {
                    IsSuccess = false,
                    Message = "Username tidak ditemukan!"
                };
            }

            // Verify the hashed password
            bool isPasswordCorrect = PasswordHasher.VerifyPassword(user.password, request.Password);
            if (!isPasswordCorrect)
            {
                return new LoginResponseDTO
                {
                    IsSuccess = false,
                    Message = "Password salah!"
                };
            }

            return new LoginResponseDTO
            {
                IsSuccess = true,
                Message = "Login berhasil!",
                Username = user.nama,
                Role = user.role
            };
        }
    }
}