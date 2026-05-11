using System;
using System.Collections.Generic;
using TugasBesar.Core.Controllers;
using TugasBesar.Core.Models;
using TugasBesar.Core.Services;
using Xunit;

namespace UnitTesting
{
    public class ProdukControllerTest
    {
        private ProdukController BuatController()
        {
            DataManager.Produk = new DataGeneric<ProdukModels>();
            return new ProdukController();
        }

        [Fact]
        public void Tambah_DataValid_BerhasilDitambahkan()
        {
            var controller = BuatController();
            controller.Tambah("Nasi Goreng", "Makanan", "15000");

            var allData = controller.GetAll();
            Assert.Single(allData);
            Assert.Equal("Nasi Goreng", allData[0].Nama);
            Assert.Equal("Makanan", allData[0].Kategori);
            Assert.Equal(15000, allData[0].Harga);
        }

        [Fact]
        public void Tambah_InputKosong_LemparException()
        {
            var controller = BuatController();

            var ex1 = Assert.Throws<Exception>(() => controller.Tambah("", "Makanan", "15000"));
            Assert.Contains("Nama produk tidak boleh kosong", ex1.Message);

            var ex2 = Assert.Throws<Exception>(() => controller.Tambah("Nasi", "", "15000"));
            Assert.Contains("Kategori produk tidak boleh kosong", ex2.Message);
        }

        [Fact]
        public void Tambah_HargaTidakValid_LemparException()
        {
            var controller = BuatController();

            var ex1 = Assert.Throws<Exception>(() => controller.Tambah("Nasi", "Makanan", "BukanAngka"));
            Assert.Contains("Harga produk harus berupa angka yang valid", ex1.Message);

            var ex2 = Assert.Throws<Exception>(() => controller.Tambah("Nasi", "Makanan", "-5000"));
            Assert.Contains("Harga harus lebih dari atau sama dengan 0", ex2.Message);
        }

        [Fact]
        public void Tambah_ProdukDuplikat_LemparException()
        {
            var controller = BuatController();
            controller.Tambah("Nasi Goreng", "Makanan", "15000");

            var ex = Assert.Throws<Exception>(() => controller.Tambah("  nasi goreng  ", "  makanan  ", "20000"));
            Assert.Contains("Produk dengan nama dan kategori yang sama sudah ada", ex.Message);
        }

        [Fact]
        public void Edit_DataValid_BerhasilDiperbarui()
        {
            var controller = BuatController();
            controller.Tambah("Nasi Goreng", "Makanan", "15000");

            controller.Edit(0, "Nasi Gila", "Makanan", "18000");

            var allData = controller.GetAll();
            Assert.Single(allData);
            Assert.Equal("Nasi Gila", allData[0].Nama);
            Assert.Equal(18000, allData[0].Harga);
        }

        [Fact]
        public void Edit_IndexTidakValid_LemparException()
        {
            var controller = BuatController();
            controller.Tambah("Nasi Goreng", "Makanan", "15000");

            var ex = Assert.Throws<Exception>(() => controller.Edit(1, "Nasi Gila", "Makanan", "18000"));
            Assert.Contains("Data tidak ditemukan", ex.Message);
        }

        [Fact]
        public void Edit_DataSamaPersis_LemparException()
        {
            var controller = BuatController();
            controller.Tambah("Nasi Goreng", "Makanan", "15000");

            var ex = Assert.Throws<Exception>(() => controller.Edit(0, "  nasi goreng  ", "  makanan  ", "15000"));
            Assert.Contains("Data masih sama", ex.Message);
        }

        [Fact]
        public void Edit_DuplikatDenganProdukLain_LemparException()
        {
            var controller = BuatController();
            controller.Tambah("Es Teh", "Minuman", "5000");
            controller.Tambah("Es Jeruk", "Minuman", "6000");

            var ex = Assert.Throws<Exception>(() => controller.Edit(1, "es teh", "minuman", "5000"));
            Assert.Contains("Produk dengan nama dan kategori yang sama sudah ada", ex.Message);
        }
        
        [Fact]
        public void Hapus_DataValid_BerhasilDihapus()
        {
            var controller = BuatController();
            controller.Tambah("Es Teh", "Minuman", "5000");
            controller.Tambah("Es Jeruk", "Minuman", "6000");
            
            controller.Hapus(0);
            
            var allData = controller.GetAll();
            Assert.Single(allData);
            Assert.Equal("Es Jeruk", allData[0].Nama);
        }
    }
}
