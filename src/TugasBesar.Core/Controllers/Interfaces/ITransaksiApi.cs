using Refit;
using System.Threading.Tasks;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;

namespace TugasBesar.Core.Controllers.Interfaces
{
    public interface ITransaksiApi
    {
        [Get("/api/Transaksi")]
        Task<List<TransaksiResponseDTO>> GetAll();

        [Post("/api/Transaksi")]
        Task<TugasBesar.Core.DTO.Response.TransaksiResultDTO> Tambah([Body] TransaksiRequestDTO request);
    }
}