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
        Task Tambah([Body] TransaksiRequestDTO request);
    }
}