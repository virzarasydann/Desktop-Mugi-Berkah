using System;
using System.Collections.Generic;
using System.Text;

namespace TugasBesar.Core.Models
{
    //public enum MetodePembayaranModels
    //{
    //    cash,
    //    qris
    //}
    public class TransaksiModels
    {
        public long IdTransaksi { get; set; }
        public long IdUser { get; set; }
        public required string NamaPembeli { get; set; }
        public int IdMetodePembayaran { get; set; }
        public int? UangDiterima { get; set; }
        public int? UangKembalian { get; set; }
        public int TotalHarga { get; set; }
        public int IdStatus { get; set; }
        public string? SnapToken { get; set; }
        public DateTime Tanggal { get; set; } = DateTime.Now;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

       
        public UsersModels User { get; set; } = null!;
        public MetodePembayaranModels MetodePembayaran { get; set; } = null!;
        public StatusModels Status { get; set; } = null!;
        public ICollection<TransaksiDetailsModels> TransaksiDetails { get; set; } = new List<TransaksiDetailsModels>();


    }
}
