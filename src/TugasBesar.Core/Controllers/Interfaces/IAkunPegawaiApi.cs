using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.Models;

namespace TugasBesar.Core.Controllers.Interfaces
{
    public interface IAkunPegawaiApi
    {
        [Get("/api/AkunPegawai")]
        Task<List<AkunPegawaiModels>> GetAllAkun();

        [Post("/api/AkunPegawai")]
        Task TambahAkun([Body] AkunRequestDTO request);

        [Put("/api/AkunPegawai/{id}")]
        Task UpdateAkun(int id, [Body] AkunRequestDTO request);

        [Delete("/api/AkunPegawai/{id}")]
        Task HapusAkun(int id);
    }
}