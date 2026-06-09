using Microsoft.AspNetCore.Mvc;
using System;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.Services.Interfaces;

namespace MugiBerkahAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KategoriController : ControllerBase
    {
        private readonly IKategoriServices _service;

        public KategoriController(IKategoriServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var data = await _service.GetAll();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Tambah([FromBody] KategoriRequestDTO request)
        {
            try
            {
                await _service.Tambah(request.Nama);
                return Ok(new { message = "Kategori berhasil ditambahkan." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] KategoriRequestDTO request)
        {
            try
            {
                await _service.Edit(id, request.Nama);
                return Ok(new { message = "Kategori berhasil diubah." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Hapus(int id)
        {
            try
            {
                await _service.Hapus(id);
                return Ok(new { message = "Kategori berhasil dihapus." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}