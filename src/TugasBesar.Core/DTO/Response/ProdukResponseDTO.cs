using System;
using System.Collections.Generic;
using System.Text;

namespace TugasBesar.Core.DTO.Response
{
    public class ProdukResponseDTO
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public int Harga { get; set; }
        public int KategoriId { get; set; }
        public string NamaKategori { get; set; }
    }
}
