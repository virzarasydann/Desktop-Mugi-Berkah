using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using TugasBesar.Core.Models;

namespace TugasBesar.Core.Services
{
    public class KategoriService
    {
        private DataGeneric<KategoriModels> dataKategori = DataManager.Kategori;

        public List<KategoriModels> GetAll()
        {
            return dataKategori.GetAll();
        }

        public void Tambah(string nama)
        {
            var list = dataKategori.GetAll();
            var newName = nama.Trim();

            if (list.Any(k => string.Equals(k.Nama?.Trim(), newName, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Nama kategori sudah ada!");

            dataKategori.Add(new KategoriModels { Nama = newName });
        }

        public void Edit(int index, string nama)
        {
            var list = dataKategori.GetAll();

            if (index < 0 || index >= list.Count)
                throw new Exception("Data tidak ditemukan!");

            var newName = nama.Trim();
            var existing = list[index];
            var existingName = (existing?.Nama ?? string.Empty).Trim();

            if (string.Equals(existingName, newName, StringComparison.OrdinalIgnoreCase))
                throw new Exception("Data masih sama!");

            if (list.Where((v, i) => i != index).Any(k => string.Equals(k.Nama?.Trim(), newName, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Nama kategori sudah ada!");

            dataKategori.Update(index, new KategoriModels { Nama = newName });
        }

        public void Hapus(int index)
        {
            var list = dataKategori.GetAll();

            if (index < 0 || index >= list.Count)
                throw new Exception("Data tidak valid!");

            dataKategori.RemoveAt(index);
        }
    }
}
