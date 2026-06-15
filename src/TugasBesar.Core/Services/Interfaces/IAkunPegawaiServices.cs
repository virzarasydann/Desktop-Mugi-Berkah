using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.Models;

namespace TugasBesar.Core.Services.Interfaces
{
    public interface IAkunPegawaiServices
    {
        Task<IReadOnlyList<AkunPegawaiModels>> GetAll();
        Task Tambah(AkunRequestDTO request);
        Task Edit(int id, AkunRequestDTO request);
        Task Hapus(int id);
    }
}
