using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;

namespace TugasBesar.Core.Services.Interfaces
{
    public interface IStatusServices
    {
        Task<IReadOnlyList<StatusResponseDTO>> GetAll();
        Task Tambah(StatusRequestDTO request);
        Task Edit(int id, StatusRequestDTO request);
        Task Hapus(int id);
    }
}
