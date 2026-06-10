using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TugasBesar.Core.DTO.Request
{
    public class KategoriRequestDTO
    {
        [Required(ErrorMessage = "Nama kategori tidak boleh kosong!")]
        public string Nama { get; set; }
    }
}
