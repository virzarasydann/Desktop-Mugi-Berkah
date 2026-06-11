using System;
using System.Collections.Generic;
using System.Linq;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Models;
using TugasBesar.Core.Repositories.Interfaces;
using TugasBesar.Core.Services.Interfaces;

namespace TugasBesar.Core.Services
{
    public class TransaksiServices : ITransaksiServices
    {
        
        
        private ITransaksiRepository _TransaksiRepo;
        private ITransaksiDetailsRepository _TransaksiDetailsRepo;

        public TransaksiServices(ITransaksiRepository TransaksiRepo, ITransaksiDetailsRepository TransaksiDetailsRepo)
        {
            _TransaksiRepo = TransaksiRepo;
            _TransaksiDetailsRepo = TransaksiDetailsRepo;

        }

        //public List<ProdukModels> DapatkanKatalog()
        //{
        //    return new List<ProdukModels>()
        //    {
        //        new ProdukModels { Nama = "Karburator Astrea", Harga = 150000 },
        //        new ProdukModels { Nama = "Pelampung Tangki", Harga = 35000 },
        //        new ProdukModels { Nama = "Kampas Rem Depan", Harga = 45000 },
        //        new ProdukModels { Nama = "Busi Standar", Harga = 15000 },
        //        new ProdukModels { Nama = "Oli Mesin 0.8L", Harga = 55000 }
        //    };
        //}

        public async Task<IReadOnlyList<TransaksiResponseDTO>> GetAll()
        {
            return await _TransaksiRepo.GetTransaksiByIdWithRelationAsync();
        }

        public async Task InsertTransactionWithRelation(TransaksiRequestDTO item)
        {
            try
            {
                int totalHarga = item.Keranjang.Sum(k => k.Subtotal);

                var transaksi = new TransaksiModels
                {
                    nama = item.NamaPelanggan,
                    total_harga = totalHarga,
                    metode_pembayaran = item.MetodePembayaran

                };
                await _TransaksiRepo.AddAsync(transaksi);

                foreach (var details in item.Keranjang)
                {
                    var transaksiDetails = new TransaksiDetailsModels
                    {
                        transaksi_id = transaksi.id,
                        produk_nama = details.NamaProduk,
                        quantity = details.Jumlah,
                        harga = details.HargaSatuan

                    };

                    await _TransaksiDetailsRepo.AddAsync(transaksiDetails);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }


        
    }
}