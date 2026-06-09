//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using TugasBesar.Core.Models;
//using TugasBesar.Core.Repositories.Interfaces;
//using TugasBesar.Core.Services;

//namespace MugiBerkahAPI.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AkunPegawaiController : ControllerBase
//    {
//        private readonly IAkunPegawaiService _akunService;

//        // Constructor Injection untuk Loose Coupling
//        public AkunPegawaiController(IAkunPegawaiService akunService)
//        {
//            _akunService = akunService;
//        }

//        [HttpGet]
//        public IActionResult GetAllAkun()
//        {
//            return Ok(_akunService.AmbilSemuaAkun());
//        }

//        public class AkunRequest
//        {
//            public string Username { get; set; }
//            public string Password { get; set; }
//        }

//        [HttpPost]
//        public IActionResult TambahAkun([FromBody] AkunRequest request)
//        {
//            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
//            {
//                return BadRequest(new { message = "Username dan Password wajib diisi!" });
//            }

//            AkunPegawaiModels akunBaru = new AkunPegawaiModels
//            {
//                Username = request.Username,
//                Password = request.Password,
//                Role = "Pegawai",
//                NamaLengkap = request.Username
//            };

//            _akunService.TambahAkun(akunBaru);
//            return Ok(new { message = "Akun berhasil ditambahkan!" });
//        }

//        [HttpPut("{id}")]
//        public IActionResult UpdateAkun(int id, [FromBody] AkunRequest request)
//        {
//            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
//                return BadRequest(new { message = "Username dan Password tidak boleh kosong!" });

//            AkunPegawaiModels akunEdit = new AkunPegawaiModels
//            {
//                Id = id,
//                Username = request.Username,
//                Password = request.Password,
//                Role = "Pegawai",
//                NamaLengkap = request.Username
//            };

//            bool sukses = _akunService.UpdateAkun(akunEdit);
//            if (sukses)
//                return Ok(new { message = "Akun berhasil diubah!" });
//            else
//                return NotFound(new { message = "Gagal mengubah akun. Data tidak ditemukan." });
//        }

//        [HttpDelete("{id}")]
//        public IActionResult HapusAkun(int id)
//        {
//            bool sukses = _akunService.HapusAkun(id);
//            if (sukses)
//                return Ok(new { message = "Akun berhasil dihapus!" });
//            else
//                return NotFound(new { message = "Gagal menghapus akun. Data tidak ditemukan." });
//        }
//    }
//}