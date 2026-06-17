using System;
using System.Collections.Generic;
using System.Text;

namespace TugasBesar.Core.DTO.Request
{
    public class OperasionalRequestDTO
    {
        public int id { get; set; }
        public int IdUser { get; set; }
        public string NamaUser { get; set; }
        public string Nama { get; set; }
        public int Harga { get; set; }
    }
}
