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
            return _services.TambahProdukKeKeranjang(nama, harga);
        }

        public int AmbilGrandTotal()
        {
            return _services.HitungGrandTotal();
        }

        public int ProsesHitungKembalian(int uangDiterima)
        {
            return _services.HitungKembalian(uangDiterima);
        }
    }
}