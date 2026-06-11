using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Models;

namespace TugasBesar.Core.Services.Interfaces
{
    public interface IOperasionalServices
    {
        public Task<IReadOnlyList<OperasionalModels>> GetAll();

        public Task<OperasionalResponseDTO> GetAllById(int id);

        public Task Tambah(OperasionalRequestDTO requestDTO);

        public Task Edit(int id, OperasionalRequestDTO requestDTO);

        public Task Hapus(int id);

    }
}
