using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.DTO.Request;

namespace TugasBesar.Core.Services
{
    public class TransactionInMemory
    {
        private List<KeranjangItem> _keranjang = new List<KeranjangItem>();

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
