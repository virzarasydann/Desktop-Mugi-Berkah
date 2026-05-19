using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using TugasBesar.Core.Models;

namespace TugasBesar.Core.Services
{
    public class ProdukService
    {
        private DataGeneric<ProdukModels> dataProduk = DataManager.Produk;


        public IReadOnlyList<ProdukModels> GetAll()
        {
            return dataProduk.GetAll();
        }


        public void Tambah(string nama, string kategori, int harga)
        {
            if (harga < 0)
                throw new Exception("Harga harus lebih dari atau sama dengan 0!");

            var list = dataProduk.GetAll();
            var newName = nama.Trim();
            var newKategori = kategori.Trim();

            if (list.Any(p => string.Equals(p.Nama?.Trim(), newName, StringComparison.OrdinalIgnoreCase)
                           && string.Equals(p.Kategori?.Trim(), newKategori, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Produk dengan nama dan kategori yang sama sudah ada!");

            dataProduk.Add(new ProdukModels { Nama = newName, Kategori = newKategori, Harga = harga });
        }

        public void Edit(int index, string nama, string kategori, int harga)
        {
            var list = dataProduk.GetAll();

            if (index < 0 || index >= list.Count)
                throw new Exception("Data tidak ditemukan!");

            if (harga < 0)
                throw new Exception("Harga harus lebih dari atau sama dengan 0!");

            var newName = nama.Trim();
            var newKategori = kategori.Trim();

            var existing = list[index];
            var existingName = (existing?.Nama ?? string.Empty).Trim();
            var existingKategori = (existing?.Kategori ?? string.Empty).Trim();
            var existingHarga = existing?.Harga ?? 0;

            if (string.Equals(existingName, newName, StringComparison.OrdinalIgnoreCase)
                && string.Equals(existingKategori, newKategori, StringComparison.OrdinalIgnoreCase)
                && existingHarga == harga)
                throw new Exception("Data masih sama!");

            if (list.Where((v, i) => i != index).Any(p => string.Equals(p.Nama?.Trim(), newName, StringComparison.OrdinalIgnoreCase)
                                                        && string.Equals(p.Kategori?.Trim(), newKategori, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Produk dengan nama dan kategori yang sama sudah ada!");

            dataProduk.Update(index, new ProdukModels { Nama = newName, Kategori = newKategori, Harga = harga });
        }

        public void Hapus(int index)
        {
            var list = dataProduk.GetAll();

            if (index < 0 || index >= list.Count)
                throw new Exception("Data tidak valid!");

            dataProduk.RemoveAt(index);
        }
    }
}
