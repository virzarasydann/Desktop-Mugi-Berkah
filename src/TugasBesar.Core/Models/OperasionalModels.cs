using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasBesar.Core.Models
{
    public class OperasionalModels
    {
        public int id { get; set; }
        public string Nama { get; set; }
        public int Harga { get; set; }


        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.Now;
    }
}
