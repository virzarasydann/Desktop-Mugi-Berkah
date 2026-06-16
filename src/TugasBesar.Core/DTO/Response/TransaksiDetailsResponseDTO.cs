using System;

namespace TugasBesar.Core.DTO.Response
{
    public class TransaksiDetailsResponseDTO
    {
        public long IdDetail { get; set; }
        public long IdTransaksi { get; set; }
        public long IdProduk { get; set; }
        public int Qty { get; set; }
        public int HargaSatuan { get; set; }
        public int Subtotal { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}