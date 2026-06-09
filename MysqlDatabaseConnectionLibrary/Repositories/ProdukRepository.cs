using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Models;
using TugasBesar.Core.Repositories.Interfaces;

namespace MysqlDatabaseConnectionLibrary.Repositories
{
    public class ProdukRepository : BaseRepository<ProdukModels>,IProdukRepository
    {
        public ProdukRepository(AppDbContext context) : base(context)
        {


        }
        public async Task<IReadOnlyList<ProdukResponseDTO>> GetAllProdukWithRelation()
        {
            return await _dbSet
                .Include(p => p.Kategori)
                .Select(p => new ProdukResponseDTO
                {
                    Id = p.id,
                    Nama = p.nama,
                    Harga = p.harga,
                    KategoriId = p.kategori_id,
                    NamaKategori = p.Kategori != null ? p.Kategori.nama : null
                })
                .ToListAsync();
        }
        public async Task<ProdukModels>  GetProdukByIdAsync(int id)
        {

            return await _dbSet.FindAsync(id);
        }
    }
}
