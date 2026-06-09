using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.Models;

namespace TugasBesar.Core.Repositories.Interfaces
{
    public interface IOperasionalRepository : IBaseRepository<OperasionalModels>
    {
        public Task<OperasionalModels> GetOperasionalByIdAsync(int id);
    }
}
