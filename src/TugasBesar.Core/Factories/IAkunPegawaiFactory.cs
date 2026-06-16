using TugasBesar.Core.Models;

namespace TugasBesar.Core.Factories
{
    /// <summary>
    /// Antarmuka untuk Factory pembuat objek AkunPegawaiModels.
    /// </summary>
    public interface IAkunPegawaiFactory
    {
        /// <summary>
        /// Membuat instansi baru dari AkunPegawaiModels dengan validasi dasar.
        /// </summary>
        AkunPegawaiModels Create(string nama, string password);
    }
}
