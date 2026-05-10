using System;
using System.Collections.Generic;
using TugasBesar.Core.Models;
using TugasBesar.Core.Services;
using ResponseMessageLibrary;   

namespace TugasBesar.Core.Controllers
{
    public class TransaksiControllers
    {
        private TransaksiServices _services;

        public TransaksiControllers()
        {
            _services = new TransaksiServices();
        }

        public ActionResponse<List<ProdukModels>> AmbilKatalog()
        {
           
                var katalog = _services.DapatkanKatalog();
                return ActionResponse<List<ProdukModels>>.Success(katalog);
           
        }

        public ActionResponse<List<KeranjangItem>> ProsesTambahKeranjang(string nama, int harga)
        {
            try
            {
                
               

                var keranjang = _services.TambahProdukKeKeranjang(nama, harga);
                return ActionResponse<List<KeranjangItem>>.Success(keranjang);
            }
            catch (ArgumentException ex)
            {
                return ActionResponse<List<KeranjangItem>>.Error(ex.Message);
            }
            
        }

        public ActionResponse<int> AmbilGrandTotal()
        {
            
                int total = _services.HitungGrandTotal();
                return ActionResponse<int>.Success(total);
           
        }

        public ActionResponse<int> ProsesHitungKembalian(int uangDiterima)
        {
            try
            {
              
                int kembalian = _services.HitungKembalian(uangDiterima);
                return ActionResponse<int>.Success(kembalian);
            }
            catch (ArgumentException ex)
            {
                return ActionResponse<int>.Error(ex.Message);
            }
           
        }
    }
}