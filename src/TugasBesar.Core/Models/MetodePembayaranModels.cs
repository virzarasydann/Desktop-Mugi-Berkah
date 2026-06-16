using System;
using System.Collections.Generic;
using System.Text;

namespace TugasBesar.Core.Models
{
    public  class MetodePembayaranModels
    {
        public int IdMetodePembayaran { get; set; }
        public required string NamaMetode { get; set; }

        public ICollection<TransaksiModels> Transaksi { get; set; } = new List<TransaksiModels>();
    }
}
