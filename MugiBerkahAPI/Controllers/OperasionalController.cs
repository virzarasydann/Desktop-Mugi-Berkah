using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.Services.Interfaces;

namespace MugiBerkahAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperasionalController : ControllerBase
    {
        private readonly IOperasionalService _operasionalService;

        public OperasionalController(IOperasionalService operasionalService)
        {
            _operasionalService = operasionalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _operasionalService.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var data = await _operasionalService.GetById(id);

                if (data == null)
                    return NotFound(new { message = "Data operasional tidak ditemukan." });

                return Ok(data);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Tambah([FromBody] OperasionalRequestDTO request)
        {
            try
            {
                await _operasionalService.Tambah(request);
                return Ok(new { message = "Data operasional berhasil ditambahkan." });
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] OperasionalRequestDTO request)
        {
            try
            {
                await _operasionalService.Edit(id, request);
                return Ok(new { message = "Data operasional berhasil diperbarui." });
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Hapus(int id)
        {
            try
            {
                await _operasionalService.Hapus(id);
                return Ok(new { message = "Data operasional berhasil dihapus." });
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        private IActionResult HandleError(Exception ex)
        {
            return BadRequest(new
            {
                message = ex.Message,
                detail = ex.InnerException?.Message
            });
        }
    }
}