using Microsoft.AspNetCore.Mvc;
using System;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.Services.Interfaces;
using TugasBesar.Core.Controllers.Interfaces;
namespace MugiBerkahAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdukController : ControllerBase
    {
        private readonly IProdukServices _service;

        public ProdukController(IProdukServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task< IActionResult> GetAll()
        {
            try
            {
                var data = await _service.GetAllProdukWithRelation();
                return Ok(data);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Tambah([FromBody] ProdukRequestDTO request)
        {
            try
            {
                await _service.Tambah(request);
                return Ok(new { message = "Produk berhasil ditambahkan." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] ProdukRequestDTO request)
        {
            try
            {
                await  _service.Edit(id, request);
                return Ok(new { message = "Produk berhasil diubah." });
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
               await  _service.Hapus(id);
                return Ok(new { message = "Produk berhasil dihapus." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}