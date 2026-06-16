using System;
using System.Collections.Generic;
using System.Text;

namespace TugasBesar.Core.DTO.Response
{
    /// <summary>
    /// Data Transfer Object untuk mengirimkan data akun pegawai ke client secara aman.
    /// </summary>
    public class AkunResponseDTO
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
