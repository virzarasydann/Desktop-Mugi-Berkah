using ResponseMessageLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Models;
namespace TugasBesar.Core.Services.Interfaces
{
    public interface ITransaksiServices
    {

        public Task<MidtransResponseDTO> InsertTransactionWithRelation(TransaksiRequestDTO item);

        public Task<IReadOnlyList<TransaksiResponseDTO>> GetAll();

    }
}
