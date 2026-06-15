using System;
using System.Collections.Generic;
using System.Text;

namespace TugasBesar.Core.DTO.Response
{
    public class AkunResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
