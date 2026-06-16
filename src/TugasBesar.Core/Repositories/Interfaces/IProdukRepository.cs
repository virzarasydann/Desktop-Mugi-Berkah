using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Models;

namespace TugasBesar.Core.Repositories.Interfaces
{
    public interface IProdukRepository : IBaseRepository<ProdukModels>
    {
        public  Task<IReadOnlyList<ProdukResponseDTO>> GetAllProdukWithRelation();
        public Task<ProdukModels> GetProdukByIdAsync(int id);
    }
}
