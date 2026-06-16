using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Models;
using TugasBesar.Core.Repositories.Interfaces;
using TugasBesar.Core.Services.Interfaces;

namespace TugasBesar.Core.Services
{
    public class StatusService : IStatusServices
    {
        private readonly IStatusRepository _repo;

        public StatusService(IStatusRepository repo)
        {
            _repo = repo;
        }

        public async Task<IReadOnlyList<StatusResponseDTO>> GetAll()
        {
            var data = await _repo.GetAllAsync();
            return data.Select(x => new StatusResponseDTO
            {
                IdStatus = x.IdStatus,
                NamaStatus = x.NamaStatus
            }).ToList();
        }

        public async Task Tambah(StatusRequestDTO request)
        {
            var list = await _repo.GetAllAsync();
            var newName = request.NamaStatus.Trim();

            if (list.Any(x => string.Equals(x.NamaStatus.Trim(), newName, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Status dengan nama yang sama sudah ada!");

            await _repo.AddAsync(new StatusModels
            {
                NamaStatus = newName
            });
        }

        public async Task Edit(int id, StatusRequestDTO request)
        {
            if (id <= 0)
                throw new Exception("Data tidak valid!");

            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                throw new Exception("Data tidak ditemukan!");

            var newName = request.NamaStatus.Trim();
            if (string.Equals(existing.NamaStatus.Trim(), newName, StringComparison.OrdinalIgnoreCase))
                throw new Exception("Data masih sama!");

            existing.NamaStatus = newName;
            await _repo.UpdateAsync(existing);
        }

        public async Task Hapus(int id)
        {
            if (id <= 0)
                throw new Exception("Data tidak valid!");

            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                throw new Exception("Data tidak ditemukan!");

            await _repo.DeleteAsync(id);
        }
    }
}