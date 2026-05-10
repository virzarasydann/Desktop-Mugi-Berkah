using System;
using System.Collections.Generic;
using TugasBesar.Models;
using TugasBesar.Services;

namespace TugasBesar.Controllers
{
    public class TransaksiControllers
    {
        private TransaksiServices _services;

        public TransaksiControllers()
        {
            _services = new TransaksiServices();
        }

        public List<ProdukModels> AmbilKatalog()
        {
            return _services.DapatkanKatalog();
        }

        public List<KeranjangItem> ProsesTambahKeranjang(string nama, int harga)
        {
            if (string.IsNullOrWhiteSpace(nama))
                throw new ArgumentException("Nama produk tidak boleh kosong.");
            if (harga < 0)
                throw new ArgumentException("Harga tidak boleh negatif.");
            return _services.TambahProdukKeKeranjang(nama, harga);
        }

        public int AmbilGrandTotal()
        {
            return _services.HitungGrandTotal();
        }

        public int ProsesHitungKembalian(int uangDiterima)
        {
            if (uangDiterima < 0)
                throw new ArgumentException("Harga tidak boleh negatif.");
            return _services.HitungKembalian(uangDiterima);
        }
    }
}