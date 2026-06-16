using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.Models;
using TugasBesar.Core.Repositories.Interfaces;

namespace MysqlDatabaseConnectionLibrary.Repositories
{
    public class StatusRepository : BaseRepository<StatusModels>, IStatusRepository
    {
        public StatusRepository(AppDbContext context) : base(context)
        {
        }
    }
}
