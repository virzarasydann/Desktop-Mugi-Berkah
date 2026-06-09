using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.Models;
using TugasBesar.Core.Repositories.Interfaces;

namespace MysqlDatabaseConnectionLibrary.Repositories
{
    public class TransaksiDetailsRepository : BaseRepository<TransaksiDetailsModels>, ITransaksiDetailsRepository
    {
        public TransaksiDetailsRepository(AppDbContext context) : base(context)
        {


        }
        public async Task<TransaksiDetailsModels> GetTransaksiDetailsByIdAsync(int id)
        {

            return await _dbSet.FindAsync(id);
        }

        //public async Task<TransaksiDetailsModels> GetTransaksiByIdWithRelationAsync(int id)
        //{

        //    return await _dbSet.Include(t => t.TransaksiDetails)
        //        .FirstOrDefaultAsync(t => t.id == id);
        //}
    }
}
