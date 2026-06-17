using System;
using System.Collections.Generic;
using System.Text;

namespace TugasBesar.Core.DTO.Response
{
    public class OperasionalResponseDTO
    {
        public int id { get; set; }

        public long IdUser { get; set; }
        public string NamaUser { get; set; }
        public string Nama { get; set; }
        public int Harga { get; set; }
    }
}