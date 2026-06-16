using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;

namespace TugasBesar.Core.Controllers.Interfaces
{
    public interface IAkunPegawaiApi
    {
        [Get("/api/AkunPegawai")]
        Task<List<AkunResponseDTO>> GetAllAkun();

        [Post("/api/AkunPegawai")]
        Task TambahAkun([Body] AkunRequestDTO request);

        [Put("/api/AkunPegawai/{id}")]
        Task UpdateAkun(long id, [Body] AkunRequestDTO request);

        [Delete("/api/AkunPegawai/{id}")]
        Task HapusAkun(long id);
    }
}