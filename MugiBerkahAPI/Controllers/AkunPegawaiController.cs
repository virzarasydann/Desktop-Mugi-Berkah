using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Services.Interfaces;

namespace MugiBerkahAPI.Controllers
{
    /// <summary>
    /// Controller REST API untuk mengelola data akun pegawai (users).
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AkunPegawaiController : ControllerBase
    {
        private readonly IAkunPegawaiServices _service;

        public AkunPegawaiController(IAkunPegawaiServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _service.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Tambah([FromBody] AkunRequestDTO request)
        {
            try
            {
                await _service.Tambah(request);
                return Ok(new { message = "Akun pegawai berhasil ditambahkan." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(long id, [FromBody] AkunRequestDTO request)
        {
            try
            {
                await _service.Edit(id, request);
                return Ok(new { message = "Akun pegawai berhasil diubah." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Hapus(long id)
        {
            try
            {
                await _service.Hapus(id);
                return Ok(new { message = "Akun pegawai berhasil dihapus." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            try
            {
                var response = await _service.Login(request);
                if (!response.IsSuccess)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new LoginResponseDTO { IsSuccess = false, Message = ex.Message });
            }
        }
    }
}