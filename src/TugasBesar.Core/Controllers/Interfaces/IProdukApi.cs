using Refit;
using System.Threading.Tasks;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;
namespace TugasBesar.Core.Controllers.Interfaces
{
    public interface IProdukApi
    {
        [Get("/api/Produk")]
        Task<ApiResponse<IReadOnlyList<ProdukResponseDTO>>> GetAll();

        [Post("/api/Produk")]
        Task Tambah([Body] ProdukRequestDTO request);

        [Put("/api/Produk/{id}")]
        Task Edit(int id, [Body] ProdukRequestDTO request);

        [Delete("/api/Produk/{id}")]
        Task Hapus(int id);
    }
}