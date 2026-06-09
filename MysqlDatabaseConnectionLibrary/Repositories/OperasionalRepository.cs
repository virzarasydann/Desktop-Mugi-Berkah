using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.Models;
using TugasBesar.Core.Repositories.Interfaces;

namespace MysqlDatabaseConnectionLibrary.Repositories
{
    public class OperasionalRepository : BaseRepository<OperasionalModels>,IOperasionalRepository
    {
        public OperasionalRepository(AppDbContext context) : base(context)
        {


        }

        public async Task<OperasionalModels> GetOperasionalByIdAsync(int id)
        {

            return await _dbSet.FindAsync(id);
        }

    }
}
