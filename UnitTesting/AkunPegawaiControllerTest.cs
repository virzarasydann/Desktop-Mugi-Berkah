using System;
using TugasBesar.Core.Controllers; 
using Xunit; 

namespace UnitTesting
{
    public class AkunPegawaiControllerTest
    {
        [Fact]
        public void TambahAkun_UsernameKosong_HarusGagal()
        {
            // 1. Arrange
            var controller = new AkunPegawaiController();
            string pesanHasil;

            // 2. Act
            bool sukses = controller.TambahAkun("", "password123", out pesanHasil);

            // 3. Assert
            Assert.False(sukses);
            Assert.Equal("Username dan Password wajib diisi!", pesanHasil);
        }

        [Fact]
        public void TambahAkun_DataLengkap_HarusSukses()
        {
            // 1. Arrange
            var controller = new AkunPegawaiController();
            string pesanHasil;
            string userTes = "tesuser" + DateTime.Now.Ticks.ToString();

            // 2. Act
            bool sukses = controller.TambahAkun(userTes, "rahasia123", out pesanHasil);

            // 3. Assert
            Assert.True(sukses);
            Assert.Equal("Akun berhasil ditambahkan!", pesanHasil);
        }
    }
}