using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using TugasBesar.Core.Models;
using TugasBesar.Core.DTO.Request;

namespace TugasBesar.Core.Controllers.Interfaces
{
    public interface IOperasionalApi
    {
        [Get("/api/Operasional")]
        Task<IReadOnlyList<OperasionalModels>> GetAll();

        [Post("/api/Operasional")]
        Task Tambah([Body] OperasionalRequestDTO request);

        [Put("/api/Operasional/{index}")]
        Task Edit(int index, [Body] OperasionalRequestDTO request);

        [Delete("/api/Operasional/{index}")]
        Task Hapus(int index);
    }
}