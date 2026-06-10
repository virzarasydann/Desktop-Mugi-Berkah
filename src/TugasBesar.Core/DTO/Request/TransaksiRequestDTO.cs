using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.Models;

namespace TugasBesar.Core.DTO.Request
{
    public class TransaksiRequestDTO
    {
        public string NamaPelanggan { get; set; }
        public MetodePembayaran MetodePembayaran { get; set; }
        public int UangDiterima { get; set; }

        
        public List<KeranjangItem> Keranjang { get; set; }
    }
}
