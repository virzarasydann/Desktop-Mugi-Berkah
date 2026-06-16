using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Models;

namespace TugasBesar.Core.Services.Interfaces
{
    public interface IOperasionalService
    {
        Task<IReadOnlyList<OperasionalResponseDTO>> GetAll();

        Task<OperasionalResponseDTO> GetById(int id);

        Task Tambah(OperasionalRequestDTO requestDTO);

        Task Edit(int id, OperasionalRequestDTO requestDTO);

        Task Hapus(int id);

    }
}
