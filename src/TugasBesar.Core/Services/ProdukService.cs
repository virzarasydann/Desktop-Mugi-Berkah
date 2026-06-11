using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Models;
using TugasBesar.Core.Repositories.Interfaces;
using TugasBesar.Core.Services.Interfaces;

namespace TugasBesar.Core.Services
{
    public class ProdukService : IProdukServices
    {
        private readonly IProdukRepository _ProdukRepository;
        private readonly IKategoriRepository _KategoriRepository;
        public ProdukService(IProdukRepository produkRepo, IKategoriRepository kategoriRepo)
        {
            _ProdukRepository = produkRepo;
            _KategoriRepository = kategoriRepo;

        }


        public async Task<IReadOnlyList<ProdukModels>> GetAll()
        {
            return await _ProdukRepository.GetAllAsync();
        }

        public async Task<IReadOnlyList<ProdukResponseDTO>> GetAllProdukWithRelation()
        {
            return await _ProdukRepository.GetAllProdukWithRelation();
        }


        public async Task Tambah(ProdukRequestDTO request)
        {
            var list =  await GetAll();
            var newName = request.nama.Trim();
            var newKategori = request.kategori_id;
            var findKategori = await _KategoriRepository.GetByIdAsync(newKategori);
            if(findKategori == null)
            {
                throw new Exception("Kategori Tidak ditemukan");
            }

            if (list.Any(p => string.Equals(p.nama?.Trim(), newName, StringComparison.OrdinalIgnoreCase)
                           && string.Equals(p.kategori_id, newKategori)))
                throw new Exception("Produk dengan nama dan kategori yang sama sudah ada!");

           await _ProdukRepository.AddAsync(new ProdukModels { nama = newName, kategori_id = newKategori, harga = request.harga });
        }

        public async Task Edit(int id, ProdukRequestDTO request)
        {
           
            if (id < 0)
                throw new Exception("Data tidak ditemukan!");

            var newName = request.nama.Trim();
            var newKategori = request.kategori_id;
            var findKategori = await _KategoriRepository.GetByIdAsync(newKategori);
            if (findKategori == null)
            {
                throw new Exception("Kategori Tidak ditemukan");
            }

            var existing = await _ProdukRepository.GetByIdAsync(id);

            if (existing == null)
                throw new Exception("Data tidak ditemukan!");

            if (string.Equals((existing.nama ?? string.Empty).Trim(), newName, StringComparison.OrdinalIgnoreCase)
                && existing.kategori_id == newKategori && existing.harga ==request.harga )
            {
                throw new Exception("Data masih sama!");
            }




            existing.nama = request.nama;
            existing.kategori_id = request.kategori_id;
            existing.harga = request.harga;

            await _ProdukRepository.UpdateAsync(existing);
        }

        public async Task Hapus(int id)
        {
            if (id < 0 )
                throw new Exception("Data tidak valid!");

            var findProduk = await _ProdukRepository.GetByIdAsync(id);
            if (findProduk == null)
            {
                throw new Exception("Produk Tidak ditemukan");
            }
            await _ProdukRepository.DeleteAsync(id);
        }
    }
}
