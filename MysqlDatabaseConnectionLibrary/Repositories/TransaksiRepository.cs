using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return await _dbSet.FindAsync((long)id);
        }

        public async Task<IReadOnlyList<TransaksiResponseDTO>> GetTransaksiByIdWithRelationAsync()
        {
            return await _dbSet
            .Include(p => p.TransaksiDetails)
            .Select(p => new TransaksiResponseDTO
            {
                IdTransaksi = p.IdTransaksi,
                IdUser = p.IdUser,
                NamaPembeli = p.NamaPembeli,
                IdMetodePembayaran = p.IdMetodePembayaran,
                IdStatus = p.IdStatus,
                TotalHarga = p.TotalHarga,
                UangDiterima = p.UangDiterima,
                UangKembalian = p.UangKembalian,
                Tanggal = p.Tanggal,
                TransaksiDetails = p.TransaksiDetails.Select(d => new TransaksiDetailsResponseDTO
                {
                    IdDetail = d.IdDetail,
                    IdTransaksi = d.IdTransaksi,
                    IdProduk = d.IdProduk,
                    Qty = d.Qty,
                    HargaSatuan = d.HargaSatuan,
                    Subtotal = d.Subtotal,
                    CreatedAt = d.CreatedAt,
                    UpdatedAt = d.UpdatedAt
                }).ToList()
            })
            .ToListAsync();
        }
    }
}