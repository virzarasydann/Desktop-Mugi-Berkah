using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TugasBesar.Core.Models;
using TugasBesar.Core.Repositories.Interfaces;

namespace MysqlDatabaseConnectionLibrary.Repositories
{
    public class AkunPegawaiRepository : BaseRepository<AkunPegawaiModels>, IAkunPegawaiRepository
    {
        public AkunPegawaiRepository(AppDbContext context) : base(context)
        {
        }
    }
}
