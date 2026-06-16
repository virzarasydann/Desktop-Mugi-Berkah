using System;
using System.Collections.Generic;
using System.Text;

namespace TugasBesar.Core.Models
{
    public class StatusModels
    {
        public int IdStatus { get; set; }
        public required string NamaStatus { get; set; }

        public ICollection<TransaksiModels> Transaksi { get; set; } = new List<TransaksiModels>();
    }
}
