using System;
using System.Collections.Generic;
using System.Text;

namespace TugasBesar.Core.Models
{
   
    public class TransaksiDetailsModels
    {
        public int id { get; set; }
        public int transaksi_id { get; set; }
        public string produk_nama { get; set; }
        public int quantity { get; set; }

        public decimal harga { get; set; } = 0.00m;
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.Now;

        public TransaksiModels Transaksi { get; set; } = null!;

    }
}
