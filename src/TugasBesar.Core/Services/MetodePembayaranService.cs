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
    public class MetodePembayaranService : IMetodePembayaranServices
    {
        private readonly IMetodePembayaranRepository _repo;

        public MetodePembayaranService(IMetodePembayaranRepository repo)
        {
            _repo = repo;
        }

        public async Task<IReadOnlyList<MetodePembayaranResponseDTO>> GetAll()
        {
            var data = await _repo.GetAllAsync();
            return data.Select(x => new MetodePembayaranResponseDTO
            {
                IdMetodePembayaran = x.IdMetodePembayaran,
                NamaMetode = x.NamaMetode
            }).ToList();
        }

        public async Task Tambah(MetodePembayaranRequestDTO request)
        {
            var list = await _repo.GetAllAsync();
            var newName = request.NamaMetode.Trim();

            if (list.Any(x => string.Equals(x.NamaMetode.Trim(), newName, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Metode pembayaran dengan nama yang sama sudah ada!");

            await _repo.AddAsync(new MetodePembayaranModels
            {
                NamaMetode = newName
            });
        }

        public async Task Edit(int id, MetodePembayaranRequestDTO request)
        {
            if (id <= 0)
                throw new Exception("Data tidak valid!");

            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                throw new Exception("Data tidak ditemukan!");

            var newName = request.NamaMetode.Trim();
            if (string.Equals(existing.NamaMetode.Trim(), newName, StringComparison.OrdinalIgnoreCase))
                throw new Exception("Data masih sama!");

            existing.NamaMetode = newName;
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