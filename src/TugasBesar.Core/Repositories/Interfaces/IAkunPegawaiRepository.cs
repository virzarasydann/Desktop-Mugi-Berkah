using System.Threading.Tasks;
using TugasBesar.Core.Models;

namespace TugasBesar.Core.Repositories.Interfaces
{
    /// <summary>
    /// Antarmuka repositori untuk manajemen data AkunPegawaiModels.
    /// </summary>
    public interface IAkunPegawaiRepository : IBaseRepository<AkunPegawaiModels>
    {
        Task<AkunPegawaiModels> GetByIdAsync(long id);
        Task DeleteAsync(long id);
    }
}
