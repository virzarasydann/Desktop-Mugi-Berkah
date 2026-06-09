using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.Models;
using TugasBesar.Core.Repositories.Interfaces;

namespace MysqlDatabaseConnectionLibrary.Repositories
{
    public class KategoriRepository : BaseRepository<KategoriModels>,IKategoriRepository
    {
        public KategoriRepository(AppDbContext context) : base(context)
        {


        }
        public async Task<KategoriModels>  GetKategoriByIdAsync(int id)
        {

            return await _dbSet.FindAsync(id);
        }
    }
}
