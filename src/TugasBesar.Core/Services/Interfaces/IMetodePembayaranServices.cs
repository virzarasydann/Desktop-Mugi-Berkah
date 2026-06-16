using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;

namespace TugasBesar.Core.Services.Interfaces
{
    public interface IMetodePembayaranServices
    {
        Task<IReadOnlyList<MetodePembayaranResponseDTO>> GetAll();
        
        Task Tambah(MetodePembayaranRequestDTO request);
        Task Edit(int id, MetodePembayaranRequestDTO request);
        Task Hapus(int id);
    }
}
