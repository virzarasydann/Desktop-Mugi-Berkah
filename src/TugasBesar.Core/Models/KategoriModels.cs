using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasBesar.Core.Models
{
    public class KategoriModels
    {
        public int id { get; set; }
        public required string nama { get; set; }

        public ICollection<ProdukModels> Produk { get; set; }
    }
}
