using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Models;

namespace TugasBesar.Core.Services.Interfaces
{
    public interface IProdukServices
    {

        public Task<IReadOnlyList<ProdukModels>> GetAll();

        public  Task<IReadOnlyList<ProdukResponseDTO>> GetAllProdukWithRelation();
        

        public  Task Tambah(ProdukRequestDTO request);


        public Task Edit(int id, ProdukRequestDTO request);


        public Task Hapus(int id);
       
    }
}
