using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.Models;
using TugasBesar.Core.Repositories.Interfaces;

namespace MysqlDatabaseConnectionLibrary.Repositories
{
    public class MetodePembayaranRepository : BaseRepository<MetodePembayaranModels>, IMetodePembayaranRepository
    {
        public MetodePembayaranRepository(AppDbContext context) : base(context)
        {
        }
    }
}
