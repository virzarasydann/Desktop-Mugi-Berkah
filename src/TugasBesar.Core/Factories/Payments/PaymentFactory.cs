using TugasBesar.Core.Services.Interfaces;

namespace TugasBesar.Core.Factories.Payments
{
    public class PaymentFactory
    {
        private readonly IMidtransService _midtransService;

        public PaymentFactory(IMidtransService midtransService)
        {
            _midtransService = midtransService;
        }

        public IPaymentProcessor CreateProcessor(int idMetodePembayaran)
        {
            return idMetodePembayaran switch
            {
                1 => new MidtransPaymentProcessor(_midtransService),
                _ => new DefaultPaymentProcessor()
            };
        }
    }
}