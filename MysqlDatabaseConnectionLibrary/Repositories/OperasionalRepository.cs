using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TugasBesar.Core.Models;
using TugasBesar.Core.Repositories.Interfaces;
using TugasBesar.Core.DTO.Response;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MysqlDatabaseConnectionLibrary.Repositories
{
    public class OperasionalRepository
        : BaseRepository<OperasionalModels>, IOperasionalRepository
    {
        public OperasionalRepository(AppDbContext context)
            : base(context)
        {
        }

        public async Task<OperasionalResponseDTO> GetOperasionalByIdAsync(int id)
        {
            return await _dbSet
                .Where(x => x.id == id)
                .Select(x => new OperasionalResponseDTO
                {
                    id = x.id,
                    Nama = x.Nama,
                    Harga = x.Harga,
                    IdUser = x.IdUser,
                    NamaUser = x.User.nama_user
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<OperasionalModels>> GetAllWithUserAsync()
        {
            return await _dbSet
                .Include(x => x.User)
                .ToListAsync();
        }
    }
}