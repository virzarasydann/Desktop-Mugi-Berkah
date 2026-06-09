using System;
using System.Linq;
using System.Collections.Generic;
using TugasBesar.Core.Models;
using TugasBesar.Core.Repositories.Interfaces;
using TugasBesar.Core.Services.Interfaces;
using TugasBesar.Core.DTO.Response;

namespace TugasBesar.Core.Services
{
    public class KategoriService : IKategoriServices
    {
        private readonly IKategoriRepository _repository;

       
        public KategoriService(IKategoriRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<KategoriResponseDTO>> GetAll()
        {
            var kategoriList = await _repository.GetAllAsync();

            var dtoList = kategoriList.Select(k => new KategoriResponseDTO
            {
                id = k.id,
                nama = k.nama,
                
            }).ToList();

            return dtoList;
        }

        public async Task Tambah(string nama)
        {
            if (string.IsNullOrWhiteSpace(nama))
                throw new Exception("Nama kategori tidak boleh kosong!");

            var newName = nama.Trim();
            var list = await _repository.GetAllAsync();

            if (list.Any(k => string.Equals(k.nama?.Trim(), newName, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("nama kategori sudah ada!");

           await _repository.AddAsync(new KategoriModels { nama = newName });
        }

        public async Task Edit(int id, string nama)
        {
            if (string.IsNullOrWhiteSpace(nama))
                throw new Exception("nama kategori tidak boleh kosong!");

            var newName = nama.Trim();
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                throw new Exception("Data tidak ditemukan!");

            if (string.Equals((existing.nama ?? string.Empty).Trim(), newName, StringComparison.OrdinalIgnoreCase))
                throw new Exception("Data masih sama!");

            var list = await _repository.GetAllAsync();
            if (list.Where(k => k.id != id).Any(k => string.Equals(k.nama?.Trim(), newName, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("nama kategori sudah ada!");

            existing.nama = newName;
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