using System;
using System.Collections.Generic;
using TugasBesar.Core.Models;
using TugasBesar.Core.Services;

namespace TugasBesar.Core.Controllers
{
    public class AkunPegawaiController
    {
        private AkunPegawaiService _akunService;

        public AkunPegawaiController()
        {
            // Controller ini yang sekarang berhak memanggil Service
            _akunService = new AkunPegawaiService();
        }

        // 1. Fungsi untuk mengambil data ke tabel
        public List<AkunPegawaiModels> GetAllAkun()
        {
            return _akunService.AmbilSemuaAkun();
        }

        // 2. Fungsi untuk menambah data
        // Menggunakan "out string pesan" agar Controller bisa menitipkan pesan error/sukses ke View
        public bool TambahAkun(string username, string password, out string pesan)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                pesan = "Username dan Password wajib diisi!";
                return false; // Mengembalikan false berarti gagal
            }

            AkunPegawaiModels akunBaru = new AkunPegawaiModels
            {
                Username = username,
                Password = password,
                Role = "Pegawai",
                NamaLengkap = username
            };

            _akunService.TambahAkun(akunBaru);
            pesan = "Akun berhasil ditambahkan!";
            return true; // Mengembalikan true berarti sukses
        }

        // 3. Fungsi untuk mengedit data
        public bool UpdateAkun(int id, string username, string password, out string pesan)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                pesan = "Username dan Password tidak boleh kosong!";
                return false;
            }

            AkunPegawaiModels akunEdit = new AkunPegawaiModels
            {
                Id = id,
                Username = username,
                Password = password,
                Role = "Pegawai",
                NamaLengkap = username
            };

            bool sukses = _akunService.UpdateAkun(akunEdit);
            if (sukses)
            {
                pesan = "Akun berhasil diubah!";
                return true;
            }
            else
            {
                pesan = "Gagal mengubah akun. Data tidak ditemukan.";
                return false;
            }
        }

        // 4. Fungsi untuk menghapus data
        public bool HapusAkun(int id, out string pesan)
        {
            bool sukses = _akunService.HapusAkun(id);
            if (sukses)
            {
                pesan = "Akun berhasil dihapus!";
                return true;
            }
            else
            {
                pesan = "Gagal menghapus akun. Data tidak ditemukan.";
                return false;
            }
        }
    }
}