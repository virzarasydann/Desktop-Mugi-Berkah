using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TugasBesar.Core.DTO.Request
{
    public class ProdukRequestDTO
    {
        [Required(ErrorMessage = "Nama produk tidak boleh kosong!")]
        public string nama { get; set; }

        [Required(ErrorMessage = "Kategori produk tidak boleh kosong!")]
        public int kategori_id { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Harga harus lebih dari atau sama dengan 0!")]
        public int harga { get; set; }
    }
}
