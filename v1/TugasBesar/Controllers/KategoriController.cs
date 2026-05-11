using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TugasBesar.Models;
using TugasBesar.Services;

namespace TugasBesar.Controllers
{
    public class KategoriController
    {
        KategoriService service = new KategoriService();

        public List<KategoriModels> GetAll()
        {
            return service.GetAll();
        }

        public void Tambah(string nama)
        {
            if (string.IsNullOrWhiteSpace(nama))
                throw new Exception("Nama kategori tidak boleh kosong!");

            service.Tambah(nama);
        }

        public void Edit(int index, string nama)
        {
            if (string.IsNullOrWhiteSpace(nama))
                throw new Exception("Nama kategori tidak boleh kosong!");

            service.Edit(index, nama);
        }

        public void Hapus(int index)
        {
            service.Hapus(index);
        }
    }
}
