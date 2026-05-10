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
            try
            {
                var katalog = _services.DapatkanKatalog();
                return ActionResponse<List<ProdukModels>>.Success(katalog);
            }
            catch (Exception ex)
            {
                return ActionResponse<List<ProdukModels>>.Error("Gagal mengambil katalog: " + ex.Message);
            }
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
            catch (Exception ex)
            {
                return ActionResponse<List<KeranjangItem>>.Error("Terjadi kesalahan sistem.");
            }
        }

        public ActionResponse<int> AmbilGrandTotal()
        {
            try
            {
                int total = _services.HitungGrandTotal();
                return ActionResponse<int>.Success(total);
            }
            catch (Exception ex)
            {
                return ActionResponse<int>.Error("Gagal menghitung total: " + ex.Message);
            }
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
            catch (Exception ex)
            {
                return ActionResponse<int>.Error("Terjadi kesalahan sistem.");
            }
        }
    }
}