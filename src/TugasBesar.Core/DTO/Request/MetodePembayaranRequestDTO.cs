using System.ComponentModel.DataAnnotations;

namespace TugasBesar.Core.DTO.Request
{
    public class MetodePembayaranRequestDTO
    {
        [Required(ErrorMessage = "Nama metode pembayaran tidak boleh kosong!")]
        public required string NamaMetode { get; set; }
    }
}