using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.Models;

namespace TugasBesar.Core.Repositories.Interfaces
{
    public interface IKategoriRepository : IBaseRepository<KategoriModels>
    {
        public Task<KategoriModels> GetKategoriByIdAsync(int id);
    }
}
