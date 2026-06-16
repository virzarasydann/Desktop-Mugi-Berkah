using Refit;
using System.Threading.Tasks;
using TugasBesar.Core.DTO.Request;

namespace TugasBesar.Core.Controllers.Interfaces
{
    public interface ITransaksiApi
    {
        [Get("/api/Transaksi")]
        Task<dynamic> GetAll();

        [Post("/api/Transaksi")]
        Task<TugasBesar.Core.DTO.Response.TransaksiResultDTO> Tambah([Body] TransaksiRequestDTO request);
    }
}