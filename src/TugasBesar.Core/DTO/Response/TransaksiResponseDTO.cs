using System;
using System.Collections.Generic;

namespace TugasBesar.Core.DTO.Response
{
    public class TransaksiResponseDTO
    {
        public long IdTransaksi { get; set; }
        public long IdUser { get; set; }
        public required string NamaPembeli { get; set; }
        public int IdMetodePembayaran { get; set; }
        public int IdStatus { get; set; }
        public int TotalHarga { get; set; }
        public int? UangDiterima { get; set; }
        public int? UangKembalian { get; set; }
        public string? SnapToken { get; set; }
        public DateTime Tanggal { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<TransaksiDetailsResponseDTO> TransaksiDetails { get; set; } = new List<TransaksiDetailsResponseDTO>();
    }
}