using Refit;
using System.Threading.Tasks;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;

namespace TugasBesar.Core.Controllers.Interfaces
{
    public interface IKategoriApi
    {
        [Get("/api/Kategori")]
        Task<ApiResponse<IReadOnlyList<KategoriResponseDTO>>> GetAll();

        [Post("/api/Kategori")]
        Task Tambah([Body] KategoriRequestDTO request);

        [Put("/api/Kategori/{id}")]
        Task Edit(int id, [Body] KategoriRequestDTO request);

        [Delete("/api/Kategori/{id}")]
        Task Hapus(int id);
    }
}