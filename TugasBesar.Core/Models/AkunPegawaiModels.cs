using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TugasBesar.Core.Models
{
    public class AkunPegawaiModels
    {
        public int Id { get; set; }
        public string NamaLengkap { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}