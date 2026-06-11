using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Models;

namespace TugasBesar.Core.Controllers.Interfaces
{
    public interface IOperasionalApi
    {
        [Get("/api/Operasional")]
        Task<IReadOnlyList<OperasionalResponseDTO>> GetAll();

        [Post("/api/Operasional")]
        Task Tambah([Body] OperasionalRequestDTO request);

        [Put("/api/Operasional/{id}")]
        Task Edit(int id, [Body] OperasionalRequestDTO request);

        [Delete("/api/Operasional/{id}")]
        Task Hapus(int id);
    }
}