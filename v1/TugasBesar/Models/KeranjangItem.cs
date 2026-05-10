using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasBesar.Models
{
    public class KeranjangItem
    {
        public string NamaProduk { get; set; }
        public int HargaSatuan { get; set; }
        public int Jumlah { get; set; }
        public int Subtotal => HargaSatuan * Jumlah;
    }
}
