using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Models;

namespace TugasBesar.Core.Repositories.Interfaces
{
    public interface ITransaksiRepository : IBaseRepository<TransaksiModels>
    {
        public Task<TransaksiModels> GetTransaksiByIdAsync(int id);
        public Task<IReadOnlyList<TransaksiResponseDTO>> GetTransaksiByIdWithRelationAsync();

    }
}
