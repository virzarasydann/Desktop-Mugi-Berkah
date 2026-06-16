using System.Threading.Tasks;
using TugasBesar.Core.Models;
using TugasBesar.Core.Repositories.Interfaces;

namespace MysqlDatabaseConnectionLibrary.Repositories
{
    /// <summary>
    /// Repositori konkret untuk melakukan query database tabel 'users' menggunakan EF Core.
    /// </summary>
    public class AkunPegawaiRepository : BaseRepository<AkunPegawaiModels>, IAkunPegawaiRepository
    {
        public AkunPegawaiRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<AkunPegawaiModels> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
