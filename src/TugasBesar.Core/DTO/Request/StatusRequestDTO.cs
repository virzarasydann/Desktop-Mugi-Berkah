using System.ComponentModel.DataAnnotations;

namespace TugasBesar.Core.DTO.Request
{
    public class StatusRequestDTO
    {
        [Required(ErrorMessage = "Nama status tidak boleh kosong!")]
        public required string NamaStatus { get; set; }
    }
}