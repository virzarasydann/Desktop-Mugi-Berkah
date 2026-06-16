using System.Collections.Generic;

namespace TugasBesar.Core.DTO.Request
{
    public class TransaksiRequestDTO
    {
        public long IdUser { get; set; }
        public required string NamaPembeli { get; set; }
        public int IdMetodePembayaran { get; set; }
        public int IdStatus { get; set; }
        public int? UangDiterima { get; set; }

        public List<KeranjangItem> Keranjang { get; set; } = new List<KeranjangItem>();
    }
}