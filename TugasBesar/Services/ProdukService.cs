using System;
using System.Linq;
using System.Diagnostics;
using TugasBesar.Models;

namespace TugasBesar.Services
{
    public enum ProdukResult
    {
        Success,
        Duplicate,
        Unchanged,
        NotFound,
        Invalid
    }

    public static class ProdukService
    {
        private static DataGeneric<ProdukModels> repo => DataManager.Produk;

        public static ProdukResult TryAdd(string name, string kategori, int harga, out ProdukModels produk)
        {
            produk = null;

            Debug.Assert(repo != null, "DataManager.Produk belum diinisialisasi (null)");
            Debug.Assert(repo.GetAll() != null, "Daftar produk (repo.GetAll()) bernilai null");

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(kategori) || harga < 0)
                return ProdukResult.Invalid;

            var newName = name.Trim();
            var newKategori = kategori.Trim();

            if (repo.GetAll().Any(p => string.Equals(p.Nama?.Trim(), newName, StringComparison.OrdinalIgnoreCase)
                                      && string.Equals(p.Kategori?.Trim(), newKategori, StringComparison.OrdinalIgnoreCase)))
                return ProdukResult.Duplicate;

            produk = new ProdukModels { Nama = newName, Kategori = newKategori, Harga = harga };
            repo.Add(produk);
            return ProdukResult.Success;
        }

        public static ProdukResult TryUpdate(int index, string name, string kategori, int harga, out ProdukModels updated)
        {
            updated = null;

            Debug.Assert(repo != null, "DataManager.Produk belum diinisialisasi (null)");
            var all = repo.GetAll();
            Debug.Assert(all != null, "Daftar produk (repo.GetAll()) bernilai null");

            if (index < 0 || index >= all.Count)
                return ProdukResult.NotFound;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(kategori) || harga < 0)
                return ProdukResult.Invalid;

            var newName = name.Trim();
            var newKategori = kategori.Trim();

            var existing = all[index];
            var existingName = (existing?.Nama ?? string.Empty).Trim();
            var existingKategori = (existing?.Kategori ?? string.Empty).Trim();
            var existingHarga = existing?.Harga ?? 0;

            if (string.Equals(existingName, newName, StringComparison.OrdinalIgnoreCase)
                && string.Equals(existingKategori, newKategori, StringComparison.OrdinalIgnoreCase)
                && existingHarga == harga)
                return ProdukResult.Unchanged;

            if (all.Where((v, i) => i != index).Any(p => string.Equals(p.Nama?.Trim(), newName, StringComparison.OrdinalIgnoreCase)
                                                        && string.Equals(p.Kategori?.Trim(), newKategori, StringComparison.OrdinalIgnoreCase)))
                return ProdukResult.Duplicate;

            updated = new ProdukModels { Nama = newName, Kategori = newKategori, Harga = harga };
            repo.Update(index, updated);
            return ProdukResult.Success;
        }
    }
}
