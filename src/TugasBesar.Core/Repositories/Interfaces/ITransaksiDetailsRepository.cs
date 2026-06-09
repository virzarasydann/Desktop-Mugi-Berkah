using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.Models;

namespace TugasBesar.Core.Repositories.Interfaces
{
    public interface ITransaksiDetailsRepository : IBaseRepository<TransaksiDetailsModels>
    {

        public Task<TransaksiDetailsModels> GetTransaksiDetailsByIdAsync(int id);
    }
}
