using System;
using System.Collections.Generic;
using System.Text;

namespace TugasBesar.Core.Models
{
   
    public class TransaksiDetailsModels
    {
        public long IdDetail { get; set; }
        public long IdTransaksi { get; set; }
        public long IdProduk { get; set; }
        public int Qty { get; set; }
        public int HargaSatuan { get; set; }
        public int Subtotal { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        
        public TransaksiModels Transaksi { get; set; } = null!;

    }
}
