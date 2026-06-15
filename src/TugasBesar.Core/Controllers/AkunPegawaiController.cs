using System;
using System.Collections.Generic;
using System.Linq;
using TugasBesar.Core.Models;
using TugasBesar.Core.Services;

namespace TugasBesar.Core.Controllers
{
    public class AkunPegawaiController
    {
        private static List<AkunPegawaiModels> _testDb = new List<AkunPegawaiModels>();
        private static int _lastId = 0;

        public List<AkunPegawaiModels> GetAllAkun()
        {
            return _testDb;
        }

        public bool TambahAkun(string username, string password, out string pesan)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                pesan = "Username dan Password wajib diisi!";
                return false;
            }

            _lastId++;
            _testDb.Add(new AkunPegawaiModels
            {
                id = _lastId,
                nama = username,
                password = password
            });

            pesan = "Akun berhasil ditambahkan!";
            return true;
        }

        public bool UpdateAkun(int id, string username, string password, out string pesan)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                pesan = "Username dan Password tidak boleh kosong!";
                return false;
            }

            var existing = _testDb.FirstOrDefault(a => a.id == id);
            if (existing == null)
            {
                pesan = "Gagal mengubah akun. Data tidak ditemukan.";
                return false;
            }

            existing.nama = username;
            existing.password = password;
            pesan = "Akun berhasil diubah!";
            return true;
        }

        public bool HapusAkun(int id, out string pesan)
        {
            var existing = _testDb.FirstOrDefault(a => a.id == id);
            if (existing == null)
            {
                pesan = "Gagal menghapus akun. Data tidak ditemukan.";
                return false;
            }

            _testDb.Remove(existing);
            pesan = "Akun berhasil dihapus!";
            return true;
        }
    }
}
