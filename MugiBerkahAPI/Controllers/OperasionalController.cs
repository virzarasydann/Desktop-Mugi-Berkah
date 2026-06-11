using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasBesar.Core.Models;
using TugasBesar.Core.Services;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.Services.Interfaces;
using TugasBesar.Core.Controllers.Interfaces;

namespace MugiBerkahAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperasionalController : ControllerBase
    {
        private readonly IOperasionalServices _services;

        public OperasionalController(IOperasionalServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _services.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var data = await _services.GetAllById(id);

                if (data == null)
                    return NotFound(new { message = "Data operasional tidak ditemukan." });

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Tambah(
    [FromBody] OperasionalRequestDTO request)
        {
            try
            {
                await _services.Tambah(request);

                return Ok(new
                {
                    message = "Data operasional berhasil ditambahkan."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message,
                    detail = ex.InnerException?.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] OperasionalRequestDTO request)
        {
            try
            {
                await _services.Edit(id, request);

                return Ok(new
                {
                    message = "Data operasional berhasil diperbarui."
                });
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
                await _services.Hapus(id);

                return Ok(new
                {
                    message = "Data operasional berhasil dihapus."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

