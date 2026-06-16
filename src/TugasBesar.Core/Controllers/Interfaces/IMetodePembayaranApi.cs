using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;

namespace TugasBesar.Core.Controllers.Interfaces
{
    public interface IMetodePembayaranApi
    {
        [Get("/api/MetodePembayaran")]
        Task<ApiResponse<IReadOnlyList<MetodePembayaranResponseDTO>>> GetAll();

        [Post("/api/MetodePembayaran")]
        Task Tambah([Body] MetodePembayaranRequestDTO request);

        [Put("/api/MetodePembayaran/{id}")]
        Task Edit(int id, [Body] MetodePembayaranRequestDTO request);

        [Delete("/api/MetodePembayaran/{id}")]
        Task Hapus(int id);
    }
}