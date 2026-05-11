using System;
using System.Collections.Generic;
using TugasBesar.Core.Controllers;
using TugasBesar.Core.Models;
using TugasBesar.Core.Services;
using Xunit;

namespace UnitTesting
{
    public class KategoriControllerTest
    {
        private KategoriController BuatController()
        {
            DataManager.Kategori = new DataGeneric<KategoriModels>();
            return new KategoriController();
        }

        [Fact]
        public void Tambah_DataValid_BerhasilDitambahkan()
        {
            var controller = BuatController();
            controller.Tambah("Makanan");

            var allData = controller.GetAll();
            Assert.Single(allData);
            Assert.Equal("Makanan", allData[0].Nama);
        }

        [Fact]
        public void Tambah_NamaNullAtauKosong_LemparException()
        {
            var controller = BuatController();

            var ex1 = Assert.Throws<Exception>(() => controller.Tambah(""));
            Assert.Contains("Nama kategori tidak boleh kosong", ex1.Message);

            var ex2 = Assert.Throws<Exception>(() => controller.Tambah("   "));
            Assert.Contains("Nama kategori tidak boleh kosong", ex2.Message);
        }

        [Fact]
        public void Tambah_NamaDuplikat_LemparException()
        {
            var controller = BuatController();
            controller.Tambah("Minuman");

            var ex = Assert.Throws<Exception>(() => controller.Tambah(" minuman "));
            Assert.Contains("Nama kategori sudah ada", ex.Message);
        }

        [Fact]
        public void Edit_DataValid_BerhasilDiperbarui()
        {
            var controller = BuatController();
            controller.Tambah("Makanan");

            controller.Edit(0, "Cemilan");

            var allData = controller.GetAll();
            Assert.Single(allData);
            Assert.Equal("Cemilan", allData[0].Nama);
        }

        [Fact]
        public void Edit_IndexTidakValid_LemparException()
        {
            var controller = BuatController();
            controller.Tambah("Makanan");

            var ex = Assert.Throws<Exception>(() => controller.Edit(1, "Minuman"));
            Assert.Contains("Data tidak ditemukan", ex.Message);
        }

        [Fact]
        public void Edit_NamaNullAtauKosong_LemparException()
        {
            var controller = BuatController();
            controller.Tambah("Makanan");

            var ex1 = Assert.Throws<Exception>(() => controller.Edit(0, ""));
            Assert.Contains("Nama kategori tidak boleh kosong", ex1.Message);
        }

        [Fact]
        public void Edit_NamaSamaPersisAtauBedaSpasiCase_LemparException()
        {
            var controller = BuatController();
            controller.Tambah("Makanan");

            var ex = Assert.Throws<Exception>(() => controller.Edit(0, "  makanan  "));
            Assert.Contains("Data masih sama", ex.Message);
        }

        [Fact]
        public void Edit_NamaDuplikatDenganItemLain_LemparException()
        {
            var controller = BuatController();
            controller.Tambah("Makanan");
            controller.Tambah("Minuman");

            var ex = Assert.Throws<Exception>(() => controller.Edit(1, "makanan"));
            Assert.Contains("Nama kategori sudah ada", ex.Message);
        }
        
        [Fact]
        public void Hapus_DataValid_BerhasilDihapus()
        {
            var controller = BuatController();
            controller.Tambah("Makanan");
            controller.Tambah("Minuman");
            
            controller.Hapus(0);
            
            var allData = controller.GetAll();
            Assert.Single(allData);
            Assert.Equal("Minuman", allData[0].Nama);
        }
        
        [Fact]
        public void Hapus_IndexTidakValid_LemparException()
        {
            var controller = BuatController();
            controller.Tambah("Makanan");
            
            var ex = Assert.Throws<Exception>(() => controller.Hapus(5));
            Assert.Contains("Data tidak valid", ex.Message);
        }
    }
}
