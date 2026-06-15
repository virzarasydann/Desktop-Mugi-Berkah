using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.Models;
using TugasBesar.Core.Repositories.Interfaces;
using TugasBesar.Core.Services.Interfaces;

namespace TugasBesar.Core.Services
{
    public class AkunPegawaiService : IAkunPegawaiServices
    {
        private readonly IAkunPegawaiRepository _repository;

        public AkunPegawaiService(IAkunPegawaiRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<AkunPegawaiModels>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task Tambah(AkunRequestDTO request)
        {
            var newName = request.name.Trim();
            var list = await _repository.GetAllAsync();

            if (list.Any(a => string.Equals(a.name?.Trim(), newName, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Username pegawai sudah ada!");

            await _repository.AddAsync(new AkunPegawaiModels 
            { 
                name = newName,
                password = request.password
            });
        }

        public async Task Edit(int id, AkunRequestDTO request)
        {
            var newName = request.name.Trim();
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                throw new Exception("Data tidak ditemukan!");

            if (string.Equals((existing.name ?? string.Empty).Trim(), newName, StringComparison.OrdinalIgnoreCase) && existing.password == request.password)
                throw new Exception("Data masih sama!");

            var list = await _repository.GetAllAsync();
            if (list.Where(a => a.id != id).Any(a => string.Equals(a.name?.Trim(), newName, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Username pegawai sudah ada!");

            existing.name = newName;
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