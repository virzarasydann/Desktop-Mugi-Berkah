using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasBesar.Core.Models
{
    public class ProdukModels
    {
        public int id { get; set; }
        public string nama { get; set; }

        public int kategori_id { get; set; }
        public int harga { get; set; }

        public KategoriModels Kategori { get; set; }


    }

  
}
