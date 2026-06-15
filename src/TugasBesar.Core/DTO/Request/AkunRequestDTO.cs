using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TugasBesar.Core.DTO.Request
{
    public class AkunRequestDTO
    {
        [Required(ErrorMessage = "Nama/Username wajib diisi!")]
        public string name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password wajib diisi!")]
        public string password { get; set; } = string.Empty;
    }
}
