using System;
using System.Collections.Generic;
using System.Linq;
using TugasBesar.Models;

namespace TugasBesar.Services
{
    public class TransaksiServices
    {
        
        private List<KeranjangItem> _keranjang = new List<KeranjangItem>();

        public List<ProdukModels> DapatkanKatalog()
        {
            return new List<ProdukModels>()
            {
                new ProdukModels { Nama = "Karburator Astrea", Harga = 150000 },
                new ProdukModels { Nama = "Pelampung Tangki", Harga = 35000 },
                new ProdukModels { Nama = "Kampas Rem Depan", Harga = 45000 },
                new ProdukModels { Nama = "Busi Standar", Harga = 15000 },
                new ProdukModels { Nama = "Oli Mesin 0.8L", Harga = 55000 }
            };
        }

        public List<KeranjangItem> TambahProdukKeKeranjang(string namaProduk, int harga)
        {
            if (string.IsNullOrWhiteSpace(namaProduk))
                throw new ArgumentException("Nama produk tidak boleh kosong.");
            if (harga < 0)
                throw new ArgumentException("Harga tidak boleh negatif.");

            var itemSudahAda = _keranjang.FirstOrDefault(k => k.NamaProduk == namaProduk);

            if (itemSudahAda != null)
            {
                itemSudahAda.Jumlah += 1; 
            }
            else
            {
                _keranjang.Add(new KeranjangItem
                {
                    NamaProduk = namaProduk,
                    HargaSatuan = harga,
                    Jumlah = 1
                });
            }

            return _keranjang; 
        }

        public int HitungGrandTotal()
        {
            int totalKeseluruhan = 0;
            foreach (var item in _keranjang)
            {
                totalKeseluruhan += item.Subtotal;
            }
            return totalKeseluruhan;
        }

        
        public int HitungKembalian(int uangDiterima)
        {
            if (uangDiterima < 0)
                throw new ArgumentException("Harga tidak boleh negatif.");
            int grandTotal = HitungGrandTotal();
            return uangDiterima - grandTotal;
        }
    }
}