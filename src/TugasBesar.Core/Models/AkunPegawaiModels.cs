using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasBesar.Core.Models
{
    public class AkunPegawaiModels
    {
        public long id { get; set; }
        public string nama { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string role { get; set; } = "PEGAWAI";
        public string nama_user { get; set; } = string.Empty;

        public ICollection<TransaksiModels> Transaksi { get; set; } = new List<TransaksiModels>();

        public ICollection<OperasionalModels> Operasional { get; set; } = new List<OperasionalModels>();
    }
}