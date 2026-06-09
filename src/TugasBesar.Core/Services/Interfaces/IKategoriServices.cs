using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Models;

namespace TugasBesar.Core.Services.Interfaces
{
    public interface IKategoriServices
    {
        public Task<IReadOnlyList<KategoriResponseDTO>> GetAll();
        

        public  Task Tambah(string nama);
        

        public Task Edit(int id, string nama);



        public Task Hapus(int id);
       
    }
}
