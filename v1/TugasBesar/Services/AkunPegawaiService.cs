using System;
using System.Collections.Generic;
using System.Linq;
using TugasBesar.Models;

namespace TugasBesar.Services
{
    public class AkunPegawaiService
    {
        // List sementara pengganti database
        private static List<AkunPegawai> _tabelAkunPegawai = new List<AkunPegawai>();
        private static int _lastId = 0;

        public void TambahAkun(AkunPegawai akun)
        {
            _lastId++;
            akun.Id = _lastId;
            _tabelAkunPegawai.Add(akun);
        }

        public List<AkunPegawai> AmbilSemuaAkun()
        {
            return _tabelAkunPegawai;
        }

        public bool UpdateAkun(AkunPegawai akunUpdate)
        {
            var akunLama = _tabelAkunPegawai.FirstOrDefault(a => a.Id == akunUpdate.Id);
            if (akunLama != null)
            {
                akunLama.NamaLengkap = akunUpdate.NamaLengkap;
                akunLama.Username = akunUpdate.Username;
                akunLama.Password = akunUpdate.Password;
                akunLama.Role = akunUpdate.Role;
                return true;
            }
            return false;
        }

        public bool HapusAkun(int id)
        {
            var akun = _tabelAkunPegawai.FirstOrDefault(a => a.Id == id);
            if (akun != null)
            {
                _tabelAkunPegawai.Remove(akun);
                return true;
            }
            return false;
        }
    }
}