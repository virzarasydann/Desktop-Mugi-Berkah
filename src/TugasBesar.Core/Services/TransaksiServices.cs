using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Factories;
using TugasBesar.Core.Factories.Payments;
using TugasBesar.Core.Repositories.Interfaces;
using TugasBesar.Core.Services.Interfaces;

namespace TugasBesar.Core.Services
{
    public class TransaksiServices : ITransaksiServices
    {
        private readonly ITransaksiRepository _transaksiRepo;
        private readonly ITransaksiDetailsRepository _transaksiDetailsRepo;
        private readonly PaymentFactory _paymentFactory;

        
        public TransaksiServices(
            ITransaksiRepository transaksiRepo,
            ITransaksiDetailsRepository transaksiDetailsRepo,
            PaymentFactory paymentFactory)
        {
            _transaksiRepo = transaksiRepo;
            _transaksiDetailsRepo = transaksiDetailsRepo;
            _paymentFactory = paymentFactory;
        }

        public async Task<IReadOnlyList<TransaksiResponseDTO>> GetAll()
        {
            return await _transaksiRepo.GetTransaksiByIdWithRelationAsync();
        }

        public async Task<MidtransResponseDTO> InsertTransactionWithRelation(TransaksiRequestDTO item)
        {
            try
            {
                
                var (transaksi, details) = TransactionFactory.Create(item);

                
                await _transaksiRepo.AddAsync(transaksi);

             
                foreach (var detail in details)
                {
                    detail.IdTransaksi = transaksi.IdTransaksi; 
                    await _transaksiDetailsRepo.AddAsync(detail);
                }

                
                var paymentProcessor = _paymentFactory.CreateProcessor(item.IdMetodePembayaran);
                return await paymentProcessor.ProcessPaymentAsync(transaksi);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}