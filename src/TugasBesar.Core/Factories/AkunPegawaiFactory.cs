using System;
using TugasBesar.Core.Models;

namespace TugasBesar.Core.Factories
{
    /// <summary>
    /// Kelas konkret Factory yang mengimplementasikan IAkunPegawaiFactory.
    /// Berfungsi memusatkan logika instansiasi dan validasi dasar pembuatan AkunPegawaiModels.
    /// </summary>
    public class AkunPegawaiFactory : IAkunPegawaiFactory
    {
        /// <summary>
        /// Membuat instansi AkunPegawaiModels dengan melakukan trimming username,
        /// mengisi nama_user, dan menetapkan default role ke "kasir" (enum database).
        /// </summary>
        public AkunPegawaiModels Create(string nama, string password)
        {
            if (string.IsNullOrWhiteSpace(nama))
                throw new ArgumentException("Nama pegawai tidak boleh kosong.");
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password tidak boleh kosong.");

            return new AkunPegawaiModels
            {
                nama = nama.Trim(),
                nama_user = nama.Trim(),
                password = password,
                role = "PEGAWAI"
            };
        }
    }
}
