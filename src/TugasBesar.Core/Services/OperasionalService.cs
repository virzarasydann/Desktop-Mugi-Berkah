using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasBesar.Core.Models;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Repositories.Interfaces;
using TugasBesar.Core.Services.Interfaces;

namespace TugasBesar.Core.Services
{
    public class OperasionalService : IOperasionalServices
    {

        private IOperasionalRepository _OperasionalRepo;

        public async Task<IReadOnlyList<OperasionalModels>> GetAll()
        {
            return await _OperasionalRepo.GetAllAsync();
        }

        public OperasionalService(IOperasionalRepository OperasionalRepo)
        {
            _OperasionalRepo = OperasionalRepo;
        }

        //private DataGeneric<OperasionalModels> dataOperasional = DataManager.Operasional;

        public async Task<OperasionalResponseDTO> GetAllById(int id)
        {
            return await _OperasionalRepo.GetOperasionalByIdAsync(id);
        }

        //public List<OperasionalModels> GetAll()
        //{
        //    return dataOperasional.GetAll();
        //}

        public async Task Tambah(OperasionalRequestDTO requestDTO)
        {
            if (string.IsNullOrWhiteSpace(requestDTO.Nama))
                throw new Exception("Nama operasional tidak boleh kosong!");

            if (requestDTO.Nama.Any(char.IsDigit))
                throw new Exception("Nama tidak boleh mengandung angka!");

            if (requestDTO.Harga <= 0)
                throw new Exception("Harga harus lebih dari 0!");

            await _OperasionalRepo.AddAsync(new OperasionalModels
            {
                Nama = requestDTO.Nama.Trim(),
                Harga = requestDTO.Harga
            });

            
        }

        public async Task Edit(int id, OperasionalRequestDTO requestDTO)
        {
            //var list = _OperasionalRepo();

            //if (_OperasionalRepo.GetAllAsync.index < 0 || requestDTO.index >= list.Count)
            //    throw new Exception("Data tidak ditemukan!");

            if (string.IsNullOrWhiteSpace(requestDTO.Nama))
                throw new Exception("Nama tidak boleh kosong!");

            if (requestDTO.Nama.Any(char.IsDigit))
                throw new Exception("Nama tidak boleh mengandung angka!");

            if (requestDTO.Harga <= 0)
                throw new Exception("Harga harus lebih dari 0!");

            var existing = await _OperasionalRepo.GetByIdAsync(id);
            if (existing == null)
                throw new Exception("Data tidak ditemukan!");

            existing.Nama = requestDTO.Nama.Trim();
            existing.Harga = requestDTO.Harga;

            await _OperasionalRepo.UpdateAsync(existing);
        }

        public async Task Hapus(int id)
        {
            if (id < 0)
                throw new Exception("Data tidak valid!");

            var findOperasional = await _OperasionalRepo.GetByIdAsync(id);
            if (findOperasional == null)
            {
                throw new Exception("Operasional Tidak ditemukan");
            }
            await _OperasionalRepo.DeleteAsync(id);
        }
    }
}
