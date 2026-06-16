using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasBesar.Core.DTO.Request
{
    public class KeranjangItem
    {
        public long IdProduk { get; set; }
        public string NamaProduk { get; set; }
        public int HargaSatuan { get; set; }
        public int Qty { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public int Subtotal => HargaSatuan * Qty;
    }
}
