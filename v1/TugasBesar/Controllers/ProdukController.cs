using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TugasBesar.Models;
using TugasBesar.Services;

namespace TugasBesar.Controllers
{
    public class ProdukController
    {
        ProdukService service = new ProdukService();

        public List<ProdukModels> GetAll()
        {
            return service.GetAll();
        }

        public void Tambah(string nama, string kategori, string hargaText)
        {
            if (string.IsNullOrWhiteSpace(nama))
                throw new Exception("Nama produk tidak boleh kosong!");

            if (string.IsNullOrWhiteSpace(kategori))
                throw new Exception("Kategori produk tidak boleh kosong!");

            if (string.IsNullOrWhiteSpace(hargaText) || !int.TryParse(hargaText, out int harga))
                throw new Exception("Harga produk harus berupa angka yang valid!");

            service.Tambah(nama, kategori, harga);
        }

        public void Edit(int index, string nama, string kategori, string hargaText)
        {
            if (string.IsNullOrWhiteSpace(nama))
                throw new Exception("Nama produk tidak boleh kosong!");

            if (string.IsNullOrWhiteSpace(kategori))
                throw new Exception("Kategori produk tidak boleh kosong!");

            if (string.IsNullOrWhiteSpace(hargaText) || !int.TryParse(hargaText, out int harga))
                throw new Exception("Harga produk harus berupa angka yang valid!");

            service.Edit(index, nama, kategori, harga);
        }

        public void Hapus(int index)
        {
            service.Hapus(index);
        }
    }
}
