using System.Collections.Generic;
using System.Threading.Tasks;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;

namespace TugasBesar.Core.Services.Interfaces
{
    /// <summary>
    /// Antarmuka untuk layanan bisnis manajemen AkunPegawai.
    /// </summary>
    public interface IAkunPegawaiServices
    {
        Task<IReadOnlyList<AkunResponseDTO>> GetAll();
        Task Tambah(AkunRequestDTO request);
        Task Edit(long id, AkunRequestDTO request);
        Task Hapus(long id);
    }
}
