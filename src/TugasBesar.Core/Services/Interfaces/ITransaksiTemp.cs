using ResponseMessageLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.Models;

namespace TugasBesar.Core.Services.Interfaces
{
    public interface ITransaksiTemp
    {
        public ActionResponse<List<ProdukModels>> AmbilKatalog();


        public ActionResponse<List<KeranjangItem>> ProsesTambahKeranjang(string nama, int harga);


        public ActionResponse<int> AmbilGrandTotal();


        public ActionResponse<int> ProsesHitungKembalian(int uangDiterima);
    }
}
