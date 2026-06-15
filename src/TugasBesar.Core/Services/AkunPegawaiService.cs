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

namespace TugasBesar.Core.Services
{
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

            var akunBaru = _factory.Create(request.name, request.password);
            await _repository.AddAsync(akunBaru);
        }

        public async Task Edit(int id, AkunRequestDTO request)
        {
            var newName = request.name.Trim();
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                throw new Exception("Data tidak ditemukan!");

            if (string.Equals((existing.nama ?? string.Empty).Trim(), newName, StringComparison.OrdinalIgnoreCase) && existing.password == request.password)
                throw new Exception("Data masih sama!");

            var list = await _repository.GetAllAsync();
            if (list.Where(a => a.id != id).Any(a => string.Equals(a.nama?.Trim(), newName, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Username pegawai sudah ada!");

            existing.nama = newName;
            existing.password = request.password;
            await _repository.UpdateAsync(existing);
        }

        public async Task Hapus(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                throw new Exception("Data tidak valid!");

            await _repository.DeleteAsync(id);
        }
    }
}