using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.Services.Interfaces;

namespace MugiBerkahAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusServices _service;

        public StatusController(IStatusServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Tambah([FromBody] StatusRequestDTO request)
        {
            try
            {
                await _service.Tambah(request);
                return Ok(new { message = "Status berhasil ditambahkan." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] StatusRequestDTO request)
        {
            try
            {
                await _service.Edit(id, request);
                return Ok(new { message = "Status berhasil diubah." });
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
                return Ok(new { message = "Status berhasil dihapus." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}