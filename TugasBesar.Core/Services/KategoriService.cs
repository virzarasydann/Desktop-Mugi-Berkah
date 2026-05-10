using System;
using System.Linq;
using System.Diagnostics;
using TugasBesar.Core.Models;

namespace TugasBesar.Core.Services
{
    public enum KategoriResult
    {
        Success,
        Duplicate,
        Unchanged,
        NotFound,
        Invalid
    }

    public static class KategoriService
    {
        private static DataGeneric<KategoriModels> repo => DataManager.Kategori;

        public static KategoriResult TryAdd(string name, out KategoriModels kategori)
        {
            kategori = null;

            Debug.Assert(repo != null, "DataManager.Kategori belum diinisialisasi (null)");
            Debug.Assert(repo.GetAll() != null, "Daftar kategori (repo.GetAll()) bernilai null");

            if (string.IsNullOrWhiteSpace(name))
                return KategoriResult.Invalid;

            var newName = name.Trim();

            if (repo.GetAll().Any(k => string.Equals(k.Nama?.Trim(), newName, StringComparison.OrdinalIgnoreCase)))
                return KategoriResult.Duplicate;

            kategori = new KategoriModels { Nama = newName };
            repo.Add(kategori);
            return KategoriResult.Success;
        }

        public static KategoriResult TryUpdate(int index, string name, out KategoriModels updated)
        {
            updated = null;

            var all = repo.GetAll();

            Debug.Assert(repo != null, "DataManager.Kategori belum diinisialisasi (null)");
            Debug.Assert(all != null, "Daftar kategori (repo.GetAll()) bernilai null");

            if (index < 0 || index >= all.Count)
                return KategoriResult.NotFound;

            if (string.IsNullOrWhiteSpace(name))
                return KategoriResult.Invalid;

            var newName = name.Trim();
            var existing = all[index];
            var existingName = (existing?.Nama ?? string.Empty).Trim();

            if (string.Equals(existingName, newName, StringComparison.OrdinalIgnoreCase))
                return KategoriResult.Unchanged;

            if (all.Where((v, i) => i != index).Any(k => string.Equals(k.Nama?.Trim(), newName, StringComparison.OrdinalIgnoreCase)))
                return KategoriResult.Duplicate;

            updated = new KategoriModels { Nama = newName };
            repo.Update(index, updated);
            return KategoriResult.Success;
        }
    }
}
