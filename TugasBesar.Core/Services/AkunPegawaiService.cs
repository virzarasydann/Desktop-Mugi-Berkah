using System;
using System.Collections.Generic;
using System.Linq;
using TugasBesar.Core.Models;

namespace TugasBesar.Core.Services
{
    public class AkunPegawaiService
    {
        // List sementara pengganti database
        private static List<AkunPegawaiModels> _tabelAkunPegawai = new List<AkunPegawaiModels>();
        private static int _lastId = 0;

        public void TambahAkun(AkunPegawaiModels akun)
        {
            _lastId++;
            akun.Id = _lastId;
            _tabelAkunPegawai.Add(akun);
        }

        public List<AkunPegawaiModels> AmbilSemuaAkun()
        {
            return _tabelAkunPegawai;
        }

        public bool UpdateAkun(AkunPegawaiModels akunUpdate)
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