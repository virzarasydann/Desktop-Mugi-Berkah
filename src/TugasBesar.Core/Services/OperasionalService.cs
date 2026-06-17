using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Models;
using TugasBesar.Core.Repositories.Interfaces;
using TugasBesar.Core.Services.Interfaces;

namespace TugasBesar.Core.Services
{
    public class OperasionalService : IOperasionalService
    {
        private readonly IOperasionalRepository _operasionalRepo;

        public OperasionalService(IOperasionalRepository operasionalRepo)
        {
            _operasionalRepo = operasionalRepo;
        }

        public async Task<IReadOnlyList<OperasionalResponseDTO>> GetAll()
        {
            var data = await _operasionalRepo.GetAllAsync();

            return data
                .Select(MapToResponseDTO)
                .ToList();
        }

        public async Task<OperasionalResponseDTO> GetById(int id)
        {
            return await _operasionalRepo.GetOperasionalByIdAsync(id);
        }

        public async Task Tambah(OperasionalRequestDTO requestDTO)
        {
            ValidasiRequest(requestDTO);

            await _operasionalRepo.AddAsync(new OperasionalModels
            {
                Nama = requestDTO.Nama.Trim(),
                Harga = requestDTO.Harga
            });
        }

        public async Task Edit(int id, OperasionalRequestDTO requestDTO)
        {
            ValidasiRequest(requestDTO);

            var existing = await _operasionalRepo.GetByIdAsync(id);
            if (existing == null)
                throw new Exception("Data operasional tidak ditemukan!");

            existing.Nama = requestDTO.Nama.Trim();
            existing.Harga = requestDTO.Harga;

            await _operasionalRepo.UpdateAsync(existing);
        }

        public async Task Hapus(int id)
        {
            if (id <= 0)
                throw new Exception("Id operasional tidak valid!");

            var existing = await _operasionalRepo.GetByIdAsync(id);
            if (existing == null)
                throw new Exception("Data operasional tidak ditemukan!");

            await _operasionalRepo.DeleteAsync(id);
        }

        private static void ValidasiRequest(OperasionalRequestDTO requestDTO)
        {
            if (string.IsNullOrWhiteSpace(requestDTO.Nama))
                throw new Exception("Nama operasional tidak boleh kosong!");

            if (requestDTO.Nama.Any(char.IsDigit))
                throw new Exception("Nama operasional tidak boleh mengandung angka!");

            if (requestDTO.Harga <= 0)
                throw new Exception("Harga operasional harus lebih dari 0!");
        }

        private static OperasionalResponseDTO MapToResponseDTO(OperasionalModels model)
        {
            return new OperasionalResponseDTO
            {
                id = model.id,
                Nama = model.Nama,
                Harga = model.Harga
            };
        }
    }
}