using System.Threading.Tasks;
using TugasBesar.Core.DTO.Response;

namespace TugasBesar.Core.Services.Interfaces
{
    public interface IMidtransService
    {
        Task<MidtransResponseDTO> CreateTransactionAsync(string orderId, int grossAmount, string customerName);
    }
}
