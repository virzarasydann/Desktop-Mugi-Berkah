using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TugasBesar.Core.Models;
using TugasBesar.Core.Services;

namespace TugasBesar.Core.Controllers
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
            var aturanValidasi = new (string Nilai, string PesanError)[]
            {
                (nama, "Nama produk tidak boleh kosong!"),
                (kategori, "Kategori produk tidak boleh kosong!")
            };

            foreach (var aturan in aturanValidasi)
            {
                if (string.IsNullOrWhiteSpace(aturan.Nilai))
                    throw new Exception(aturan.PesanError);
            }

            if (string.IsNullOrWhiteSpace(hargaText) || !int.TryParse(hargaText, out int harga))
                throw new Exception("Harga produk harus berupa angka yang valid!");

            service.Tambah(nama, kategori, harga);
        }

        public void Edit(int index, string nama, string kategori, string hargaText)
        {
            var aturanValidasi = new (string Nilai, string PesanError)[]
            {
                (nama, "Nama produk tidak boleh kosong!"),
                (kategori, "Kategori produk tidak boleh kosong!")
            };

            foreach (var aturan in aturanValidasi)
            {
                if (string.IsNullOrWhiteSpace(aturan.Nilai))
                    throw new Exception(aturan.PesanError);
            }

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