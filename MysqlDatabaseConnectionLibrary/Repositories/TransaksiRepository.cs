using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Models;
using TugasBesar.Core.Repositories.Interfaces;

namespace MysqlDatabaseConnectionLibrary.Repositories
{
    public class TransaksiRepository : BaseRepository<TransaksiModels>, ITransaksiRepository
    {
        public TransaksiRepository(AppDbContext context) : base(context)
        {


        }
        public async Task<TransaksiModels> GetTransaksiByIdAsync(int id)
        {

            return await _dbSet.FindAsync(id);
        }

        public async Task<IReadOnlyList<TransaksiResponseDTO>> GetTransaksiByIdWithRelationAsync()
        {
            return await _dbSet
            .Include(p => p.TransaksiDetails)
            .Select(p => new TransaksiResponseDTO
            {
                id = p.id,
                nama = p.nama,
                total_harga = p.total_harga,
                metode_pembayaran = p.metode_pembayaran,
                TransaksiDetails = p.TransaksiDetails.Select(d => new TransaksiDetailsResponseDTO
                {
                    id = d.id,
                    transaksi_id = d.transaksi_id,
                    produk_nama = d.produk_nama,
                    quantity = d.quantity,
                    harga = d.harga,
                    created_at = d.created_at,
                    updated_at = d.updated_at
                   
                }).ToList()
            })
            .ToListAsync();
        }
    }
}
