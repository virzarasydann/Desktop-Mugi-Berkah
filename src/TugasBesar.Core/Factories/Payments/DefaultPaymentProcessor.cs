using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Models;

namespace TugasBesar.Core.Factories.Payments
{
    public class DefaultPaymentProcessor : IPaymentProcessor
    {
        public Task<MidtransResponseDTO> ProcessPaymentAsync(TransaksiModels transaksi)
        {
            
            return Task.FromResult(new MidtransResponseDTO { token = null, redirect_url = null });
        }
    }
}
