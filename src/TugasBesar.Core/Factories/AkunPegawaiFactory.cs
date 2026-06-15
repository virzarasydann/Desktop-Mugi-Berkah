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
        /// Membuat instansi AkunPegawaiModels dengan melakukan trimming username dan validasi null/kosong.
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
                password = password
            };
        }
    }
}
