using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Models;

namespace TugasBesar.Core.Services
{
    public class MasterDataCacheService
    {
        public List<ProdukResponseDTO> DaftarProduk { get; set; } = new List<ProdukResponseDTO>();
        public List<KategoriResponseDTO> DaftarKategori { get; set; } = new List<KategoriResponseDTO>();

        
        public bool IsLoaded { get; set; } = false;
    }
}
