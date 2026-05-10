using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TugasBesar.Core.Models;
using TugasBesar.Core.Services;
using System.Threading.Tasks;

namespace TugasBesar.Core.Controllers
{
    public class OperasionalController
    {
            OperasionalService service = new OperasionalService();

            public List<OperasionalModels> GetAll()
            {
                return service.GetAll();
            }

            public void Tambah(string nama, string hargaText)
            {
            if (string.IsNullOrWhiteSpace(nama))
                throw new Exception("Nama tidak boleh kosong!");

            if (string.IsNullOrWhiteSpace(hargaText) || !int.TryParse(hargaText, out int harga))
                throw new Exception("Harga tidak boleh kosong! atau Harga harus berupa angka!");

            //if (!int.TryParse(hargaText, out int harga))
            //        throw new Exception("Harga harus berupa angka!");


            service.Tambah(nama, harga);
            }
            public void Edit(int index, string nama, string hargaText)
            {
             if (string.IsNullOrWhiteSpace(nama))
                    throw new Exception("Nama tidak boleh kosong!");

            if (nama.Any(char.IsDigit))
                throw new Exception("Nama tidak boleh mengandung angka!");

            if (string.IsNullOrWhiteSpace(hargaText) || !int.TryParse(hargaText, out int harga))
                throw new Exception("Harga tidak boleh kosong! atau Harga harus berupa angka!");


            service.Edit(index, nama, harga);
            }

            public void Hapus(int index)
            {
                service.Hapus(index);
            }
        }
    }

    