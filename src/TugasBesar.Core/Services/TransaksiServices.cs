using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Models;
using TugasBesar.Core.Repositories.Interfaces;
using TugasBesar.Core.Services.Interfaces;

namespace TugasBesar.Core.Services
{
    public class TransaksiServices : ITransaksiServices
    {
        private readonly ITransaksiRepository _transaksiRepo;
        private readonly ITransaksiDetailsRepository _transaksiDetailsRepo;
        private readonly IMidtransService _midtransService;

        public TransaksiServices(ITransaksiRepository transaksiRepo, ITransaksiDetailsRepository transaksiDetailsRepo, IMidtransService midtransService)
        {
            _transaksiRepo = transaksiRepo;
            _transaksiDetailsRepo = transaksiDetailsRepo;
            _midtransService = midtransService;
        }

        public async Task<IReadOnlyList<TransaksiResponseDTO>> GetAll()
        {
            return await _transaksiRepo.GetTransaksiByIdWithRelationAsync();
        }

        public async Task<MidtransResponseDTO> InsertTransactionWithRelation(TransaksiRequestDTO item)
        {
            try
            {
                int totalHarga = item.Keranjang.Sum(k => k.Subtotal);
                
                
                int? uangKembalian = item.UangDiterima.HasValue 
                    ? (item.UangDiterima.Value - totalHarga) 
                    : null;

                var transaksi = new TransaksiModels
                {
                    IdUser = item.IdUser,
                    NamaPembeli = item.NamaPembeli,
                    IdMetodePembayaran = item.IdMetodePembayaran,
                    IdStatus = item.IdStatus,
                    TotalHarga = totalHarga,
                    UangDiterima = item.UangDiterima,
                    UangKembalian = uangKembalian,
                    Tanggal = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                await _transaksiRepo.AddAsync(transaksi);

                foreach (var details in item.Keranjang)
                {
                    var transaksiDetails = new TransaksiDetailsModels
                    {
                        IdTransaksi = transaksi.IdTransaksi,
                        IdProduk = details.IdProduk,
                        Qty = details.Qty,
                        HargaSatuan = details.HargaSatuan,
                        Subtotal = details.Subtotal,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };

                    await _transaksiDetailsRepo.AddAsync(transaksiDetails);
                }

                if (item.IdMetodePembayaran == 2)
                {
                    string orderId = "ORDER-" + transaksi.IdTransaksi + "-" + DateTime.Now.Ticks;
                    return await _midtransService.CreateTransactionAsync(orderId, totalHarga, item.NamaPembeli ?? "Pelanggan");
                }

                return new MidtransResponseDTO { token = null, redirect_url = null };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}