using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasBesar.Core.Models;

namespace TugasBesar.Core.Services
{
    public class OperasionalService
    {
        private DataGeneric<OperasionalModels> dataOperasional = DataManager.Operasional;

        public IReadOnlyList<OperasionalModels> GetAll()
        {
            return dataOperasional.GetAll();
        }

        //public List<OperasionalModels> GetAll()
        //{
        //    return dataOperasional.GetAll();
        //}

        public void Tambah(string nama, int harga)
        {
            if (string.IsNullOrWhiteSpace(nama))
                throw new Exception("Nama operasional tidak boleh kosong!");

            if (nama.Any(char.IsDigit))
                throw new Exception("Nama tidak boleh mengandung angka!");

            if (harga <= 0)
                throw new Exception("Harga harus lebih dari 0!");

            dataOperasional.Add(new OperasionalModels()
            {
                Nama = nama.Trim(),
                Harga = harga
            });
        }

        public void Edit(int index, string nama, int harga)
        {
            var list = dataOperasional.GetAll();

            if (index < 0 || index >= list.Count)
                throw new Exception("Data tidak ditemukan!");

            if (string.IsNullOrWhiteSpace(nama))
                throw new Exception("Nama tidak boleh kosong!");

            if (nama.Any(char.IsDigit))
                throw new Exception("Nama tidak boleh mengandung angka!");

            if (harga <= 0)
                throw new Exception("Harga harus lebih dari 0!");

            dataOperasional.Update(index, new OperasionalModels()
            {
                Nama = nama.Trim(),
                Harga = harga
            });
        }

        public void Hapus(int index)
        {
            var list = dataOperasional.GetAll();

            if (index < 0 || index >= list.Count)
                throw new Exception("Data tidak valid!");

            dataOperasional.RemoveAt(index);
        }
    }
}
