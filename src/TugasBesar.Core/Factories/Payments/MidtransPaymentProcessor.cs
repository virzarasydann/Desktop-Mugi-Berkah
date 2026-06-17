using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Models;
using TugasBesar.Core.Services.Interfaces;

namespace TugasBesar.Core.Factories.Payments
{
    public class MidtransPaymentProcessor : IPaymentProcessor
    {
        private readonly IMidtransService _midtransService;

        public MidtransPaymentProcessor(IMidtransService midtransService)
        {
            _midtransService = midtransService;
        }

        public async Task<MidtransResponseDTO> ProcessPaymentAsync(TransaksiModels transaksi)
        {
            string orderId = "ORDER-" + transaksi.IdTransaksi + "-" + DateTime.Now.Ticks;
            return await _midtransService.CreateTransactionAsync(orderId, transaksi.TotalHarga, transaksi.NamaPembeli ?? "Pelanggan");
        }
    }
}
