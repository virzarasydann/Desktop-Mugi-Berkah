using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;

namespace TugasBesar.Core.Controllers.Interfaces
{
    public interface IStatusApi
    {
        [Get("/api/Status")]
        Task<ApiResponse<IReadOnlyList<StatusResponseDTO>>> GetAll();

        [Post("/api/Status")]
        Task Tambah([Body] StatusRequestDTO request);

        [Put("/api/Status/{id}")]
        Task Edit(int id, [Body] StatusRequestDTO request);

        [Delete("/api/Status/{id}")]
        Task Hapus(int id);
    }
}