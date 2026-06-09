using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.Models;

namespace TugasBesar.Core.DTO.Response
{
    public class TransaksiResponseDTO
    {
        public int id { get; set; }
        public string nama { get; set; }
        public decimal total_harga { get; set; } = 0.00m;
        public MetodePembayaran metode_pembayaran { get; set; }

        public DateTime created_at { get; set; } 
        public DateTime updated_at { get; set; } 

        public ICollection<TransaksiDetailsResponseDTO> TransaksiDetails { get; set; } = new List<TransaksiDetailsResponseDTO>();
    }
}
