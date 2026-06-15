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
        /// <param name="nama">Username/nama akun pegawai</param>
        /// <param name="password">Password akun pegawai</param>
        /// <returns>Objek AkunPegawaiModels yang siap digunakan</returns>
        AkunPegawaiModels Create(string nama, string password);
    }
}
