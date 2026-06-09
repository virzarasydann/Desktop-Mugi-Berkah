using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc; 
using TugasBesar.Core.Models;
using TugasBesar.Core.Services;
using ResponseMessageLibrary;
using TugasBesar.Core.Services.Interfaces;
using TugasBesar.Core.DTO.Request;

namespace MugiBerkahAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransaksiController : ControllerBase 
    {
        private readonly ITransaksiServices _services; 

        public TransaksiController(ITransaksiServices services)
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

        [HttpPost]
        public async Task<IActionResult> Tambah([FromBody] TransaksiRequestDTO request)
        {
            try
            {
                await _services.InsertTransactionWithRelation(request);
                return Ok(new { message = "Transaksi berhasil ditambahkan." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        
    }
}