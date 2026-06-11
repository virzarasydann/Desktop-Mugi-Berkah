using System;
using System.Collections.Generic;
using System.Text;

namespace TugasBesar.Core.Models
{
    public enum MetodePembayaran
    {
        cash,
        qris
    }
    public class TransaksiModels
    {
        public int id { get; set; }
        public string nama { get; set; }
        public decimal total_harga { get; set; } = 0.00m;
        public MetodePembayaran metode_pembayaran { get; set; }

        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.Now;

        public ICollection<TransaksiDetailsModels> TransaksiDetails { get; set; } = new List<TransaksiDetailsModels>();


    }
}
