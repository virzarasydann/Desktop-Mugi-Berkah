using System;
using System.Collections.Generic;
using System.Diagnostics;
using TugasBesar.Core.Controllers;
using TugasBesar.Core.Models;
using ResponseMessageLibrary;
using Xunit;

namespace UnitTesting
{
    public class TransaksiControllersTest
    {
        public TransaksiControllersTest()
        {
            Trace.Listeners.Clear();
            Trace.Listeners.Add(new FailOnAssertTraceListener());
        }

        [Fact]
        public void AmbilKatalog_HarusMengembalikanLimaProduk_Sukses()
        {
            // Arrange
            var controller = new TransaksiControllers();

            // Act
            ActionResponse<List<ProdukModels>> response = controller.AmbilKatalog();

            // Assert
            Assert.True(response.IsSuccess, "Response harus sukses");
            Assert.NotNull(response.Data);
            Assert.Equal(5, response.Data.Count);

            Debug.Assert(response.IsSuccess, "IsSuccess harus true");
            Debug.Assert(response.Data != null, "Data tidak boleh null");
            Debug.Assert(response.Data.Count == 5, $"Jumlah katalog harus 5, ditemukan {response.Data.Count}");
        }

        [Fact]
        public void ProsesTambahKeranjang_ProdukValid_HarusSuksesDanKeranjangBertambah()
        {
            var controller = new TransaksiControllers();

            ActionResponse<List<KeranjangItem>> response = controller.ProsesTambahKeranjang("Karburator Astrea", 150000);

            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Data);
            Assert.Single(response.Data);
            Assert.Equal("Karburator Astrea", response.Data[0].NamaProduk);
            Assert.Equal(1, response.Data[0].Jumlah);

            Debug.Assert(response.Data.Count == 1, "Harus ada 1 item di keranjang");
            Debug.Assert(response.Data[0].NamaProduk == "Karburator Astrea", "Nama produk salah");
        }

        [Fact]
        public void ProsesTambahKeranjang_ProdukSamaDuaKali_JumlahBertambahMenjadiDua()
        {
            var controller = new TransaksiControllers();

            controller.ProsesTambahKeranjang("Kampas Rem Depan", 45000);
            var response = controller.ProsesTambahKeranjang("Kampas Rem Depan", 45000);

            Assert.True(response.IsSuccess);
            Assert.Single(response.Data);
            Assert.Equal(2, response.Data[0].Jumlah);

            Debug.Assert(response.Data.Count == 1, "Hanya boleh 1 entry produk yang sama");
            Debug.Assert(response.Data[0].Jumlah == 2, "Jumlah harus bertambah menjadi 2");
        }

        [Fact]
        public void ProsesTambahKeranjang_NamaKosong_MengembalikanError()
        {
            var controller = new TransaksiControllers();

            ActionResponse<List<KeranjangItem>> response = controller.ProsesTambahKeranjang("", 1000);

            Assert.False(response.IsSuccess);
            Assert.Contains("Nama produk tidak boleh kosong", response.Message);
            Assert.Null(response.Data); // data harus null jika error

            Debug.Assert(!response.IsSuccess, "Response harus gagal");
            Debug.Assert(response.Message.Contains("Nama produk tidak boleh kosong"),
                "Pesan error tidak sesuai");
        }

        [Fact]
        public void ProsesTambahKeranjang_HargaNegatif_MengembalikanError()
        {
            var controller = new TransaksiControllers();

            var response = controller.ProsesTambahKeranjang("Oli", -5000);

            Assert.False(response.IsSuccess);
            Assert.Contains("Harga tidak boleh negatif", response.Message);
            Assert.Null(response.Data);

            Debug.Assert(!response.IsSuccess, "Response harus gagal");
            Debug.Assert(response.Message.Contains("Harga tidak boleh negatif"),
                "Pesan error harga negatif salah");
        }

        [Fact]
        public void AmbilGrandTotal_SetelahMenambahItem_MenghitungTotalBenar()
        {
            var controller = new TransaksiControllers();
            controller.ProsesTambahKeranjang("Busi Standar", 15000);
            controller.ProsesTambahKeranjang("Busi Standar", 15000); // jumlah 2
            controller.ProsesTambahKeranjang("Oli Mesin 0.8L", 55000);

            ActionResponse<int> response = controller.AmbilGrandTotal();

            Assert.True(response.IsSuccess);
            Assert.Equal(85000, response.Data);
            Debug.Assert(response.Data == 85000, $"Total harus 85000, tapi dapat {response.Data}");
        }

        [Fact]
        public void AmbilGrandTotal_KeranjangKosong_HasilNol()
        {
            var controller = new TransaksiControllers();

            var response = controller.AmbilGrandTotal();

            Assert.True(response.IsSuccess);
            Assert.Equal(0, response.Data);
            Debug.Assert(response.Data == 0, "Total keranjang kosong harus 0");
        }

        [Fact]
        public void ProsesHitungKembalian_UangDiterimaCukup_KembalianBenar()
        {
            var controller = new TransaksiControllers();
            controller.ProsesTambahKeranjang("Karburator Astrea", 150000);
            controller.ProsesTambahKeranjang("Pelampung Tangki", 35000);

            ActionResponse<int> response = controller.ProsesHitungKembalian(200000);

            Assert.True(response.IsSuccess);
            Assert.Equal(15000, response.Data);
            Debug.Assert(response.Data == 15000, $"Kembalian seharusnya 15000, tapi {response.Data}");
        }

        [Fact]
        public void ProsesHitungKembalian_UangDiterimaNegatif_MengembalikanError()
        {
            var controller = new TransaksiControllers();

            var response = controller.ProsesHitungKembalian(-10000);

            Assert.False(response.IsSuccess);
            Assert.Contains("Harga tidak boleh negatif", response.Message);
            Assert.Equal(0, response.Data); // default int

            Debug.Assert(!response.IsSuccess, "Response harus gagal");
            Debug.Assert(response.Message.Contains("Harga tidak boleh negatif"),
                "Pesan error tidak sesuai");
        }
    }

    public class FailOnAssertTraceListener : TraceListener
    {
        public override void Write(string message) { }
        public override void WriteLine(string message) { }

        public override void Fail(string message)
        {
            throw new Exception($"Debug.Assert gagal: {message}");
        }

        public override void Fail(string message, string detailMessage)
        {
            throw new Exception($"Debug.Assert gagal: {message} | Detail: {detailMessage}");
        }
    }
}