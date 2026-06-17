using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Models;

namespace TugasBesar.Core.Factories.Payments
{
    public interface IPaymentProcessor
    {
        Task<MidtransResponseDTO> ProcessPaymentAsync(TransaksiModels transaksi);
    }
}
