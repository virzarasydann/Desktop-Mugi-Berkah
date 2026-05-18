using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TugasBesar.Core.Controllers;
using TugasBesar.Core.Models;
using TugasBesar.Core.Services;

namespace UnitTesting
{
    public class OperasionalControllerTest
    {
        private OperasionalController BuatController()
        {
            DataManager.Operasional = new DataGeneric<OperasionalModels>();
            return new OperasionalController();
        }

        public OperasionalControllerTest()
        {
            Trace.Listeners.Clear();
            Trace.Listeners.Add(new FailOnAssertTraceListener());
        }

        [Fact]
        public void GetAll_DataKosong_MengembalikanListKosong()
        {
            // Arrange
            var controller = BuatController();

            // Act
            List<OperasionalModels> result = (List<OperasionalModels>)controller.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);

            Debug.Assert(result != null, "Result tidak boleh null");
            Debug.Assert(result.Count == 0, "List harus kosong saat belum ada data");
        }

        [Fact]
        public void GetAll_SetelahTambahData_MengembalikanDataYangBenar()
        {
            // Arrange
            var controller = BuatController();
            controller.Tambah("Listrik", "500000");

            // Act
            List<OperasionalModels> result = (List<OperasionalModels>)controller.GetAll();

            // Assert
            Assert.Single(result);
            Assert.Equal("Listrik", result[0].Nama);
            Assert.Equal(500000, result[0].Harga);

            Debug.Assert(result.Count == 1, "Harus ada 1 data setelah ditambahkan");
            Debug.Assert(result[0].Nama == "Listrik", "Nama operasional tidak sesuai");
        }

        [Fact]
        public void Tambah_DataValid_BerhasilDitambahkan()
        {
            // Arrange
            var controller = BuatController();

            // Act
            controller.Tambah("Sewa Tempat", "1500000");
            List<OperasionalModels> result = (List<OperasionalModels>)controller.GetAll();

            // Assert
            Assert.Single(result);
            Assert.Equal("Sewa Tempat", result[0].Nama);
            Assert.Equal(1500000, result[0].Harga);

            Debug.Assert(result.Count == 1, "Harus ada 1 data setelah tambah");
            Debug.Assert(result[0].Harga == 1500000, "Harga tidak sesuai");
        }

        [Fact]
        public void Tambah_NamaKosong_LemparException()
        {
            // Arrange
            var controller = BuatController();

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => controller.Tambah("", "100000"));
            Assert.Contains("Nama tidak boleh kosong", ex.Message);

            Debug.Assert(ex != null, "Exception harus dilempar saat nama kosong");
        }

        [Fact]
        public void Tambah_NamaHanyaSpasi_LemparException()
        {
            // Arrange
            var controller = BuatController();

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => controller.Tambah("   ", "100000"));
            Assert.Contains("Nama tidak boleh kosong", ex.Message);

            Debug.Assert(ex.Message.Contains("Nama tidak boleh kosong"),
                "Pesan error nama spasi tidak sesuai");
        }

        [Fact]
        public void Tambah_HargaKosong_LemparException()
        {
            // Arrange
            var controller = BuatController();

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => controller.Tambah("Listrik", ""));
            Assert.Contains("Harga tidak boleh kosong", ex.Message);

            Debug.Assert(ex.Message.Contains("Harga tidak boleh kosong"),
                "Pesan error harga kosong tidak sesuai");
        }

        [Fact]
        public void Tambah_HargaBukanAngka_LemparException()
        {
            // Arrange
            var controller = BuatController();

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => controller.Tambah("Listrik", "abc"));
            Assert.Contains("Harga harus berupa angka", ex.Message);

            Debug.Assert(ex.Message.Contains("Harga harus berupa angka"),
                "Pesan error format harga tidak sesuai");
        }

        [Fact]
        public void Tambah_HargaNol_LemparException()
        {
            // Arrange
            var controller = BuatController();

            // Act & Assert
            // Service menolak harga <= 0
            var ex = Assert.Throws<Exception>(() => controller.Tambah("Listrik", "0"));
            Assert.Contains("Harga harus lebih dari 0", ex.Message);

            Debug.Assert(ex != null, "Exception harus dilempar saat harga nol");
        }

        [Fact]
        public void Tambah_HargaNegatif_LemparException()
        {
            // Arrange
            var controller = BuatController();

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => controller.Tambah("Listrik", "-5000"));
            Assert.Contains("Harga harus lebih dari 0", ex.Message);

            Debug.Assert(ex != null, "Exception harus dilempar saat harga negatif");
        }

        [Fact]
        public void Tambah_NamaMengandungAngka_LemparException()
        {
            // Arrange
            var controller = BuatController();

            // Act & Assert
            // Service memvalidasi nama tidak boleh mengandung angka
            var ex = Assert.Throws<Exception>(() => controller.Tambah("Listrik123", "500000"));
            Assert.Contains("Nama tidak boleh mengandung angka", ex.Message);

            Debug.Assert(ex.Message.Contains("Nama tidak boleh mengandung angka"),
                "Pesan error nama mengandung angka tidak sesuai");
        }

        [Fact]
        public void Tambah_DuaDataValid_KeduanyaTersimpan()
        {
            // Arrange
            var controller = BuatController();

            // Act
            controller.Tambah("Listrik", "500000");
            controller.Tambah("Air", "200000");
            List<OperasionalModels> result = (List<OperasionalModels>)controller.GetAll();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Listrik", result[0].Nama);
            Assert.Equal("Air", result[1].Nama);

            Debug.Assert(result.Count == 2, "Harus ada 2 data setelah dua kali tambah");
        }


        [Fact]
        public void Edit_DataValid_BerhasilDiperbarui()
        {
            // Arrange
            var controller = BuatController();
            controller.Tambah("Listrik", "500000");

            // Act
            controller.Edit(0, "Internet", "350000");
            List<OperasionalModels> result = (List<OperasionalModels>)controller.GetAll();

            // Assert
            Assert.Single(result);
            Assert.Equal("Internet", result[0].Nama);
            Assert.Equal(350000, result[0].Harga);

            Debug.Assert(result[0].Nama == "Internet", "Nama setelah edit tidak sesuai");
            Debug.Assert(result[0].Harga == 350000, "Harga setelah edit tidak sesuai");
        }

        [Fact]
        public void Edit_NamaKosong_LemparException()
        {
            // Arrange
            var controller = BuatController();
            controller.Tambah("Listrik", "500000");

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => controller.Edit(0, "", "500000"));
            Assert.Contains("Nama tidak boleh kosong", ex.Message);

            Debug.Assert(ex.Message.Contains("Nama tidak boleh kosong"),
                "Pesan error nama kosong saat edit tidak sesuai");
        }

        [Fact]
        public void Edit_NamaMengandungAngka_LemparException()
        {
            // Arrange
            var controller = BuatController();
            controller.Tambah("Listrik", "500000");

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => controller.Edit(0, "Listrik99", "500000"));
            Assert.Contains("Nama tidak boleh mengandung angka", ex.Message);

            Debug.Assert(ex.Message.Contains("Nama tidak boleh mengandung angka"),
                "Pesan error nama angka saat edit tidak sesuai");
        }

        [Fact]
        public void Edit_HargaBukanAngka_LemparException()
        {
            // Arrange
            var controller = BuatController();
            controller.Tambah("Listrik", "500000");

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => controller.Edit(0, "Listrik", "mahal"));
            Assert.Contains("Harga harus berupa angka", ex.Message);

            Debug.Assert(ex.Message.Contains("Harga harus berupa angka"),
                "Pesan error format harga saat edit tidak sesuai");
        }

        [Fact]
        public void Edit_HargaKosong_LemparException()
        {
            // Arrange
            var controller = BuatController();
            controller.Tambah("Listrik", "500000");

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => controller.Edit(0, "Listrik", ""));
            Assert.Contains("Harga tidak boleh kosong", ex.Message);

            Debug.Assert(ex.Message.Contains("Harga tidak boleh kosong"),
                "Pesan error harga kosong saat edit tidak sesuai");
        }

        [Fact]
        public void Edit_HargaNol_LemparException()
        {
            // Arrange
            var controller = BuatController();
            controller.Tambah("Listrik", "500000");

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => controller.Edit(0, "Listrik", "0"));
            Assert.Contains("Harga harus lebih dari 0", ex.Message);

            Debug.Assert(ex != null, "Exception harus dilempar saat harga nol pada edit");
        }

        [Fact]
        public void Edit_IndexTidakValid_LemparException()
        {
            // Arrange
            var controller = BuatController();
            controller.Tambah("Listrik", "500000");

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => controller.Edit(99, "Listrik", "500000"));
            Assert.Contains("Data tidak ditemukan", ex.Message);

            Debug.Assert(ex.Message.Contains("Data tidak ditemukan"),
                "Pesan error index tidak valid saat edit tidak sesuai");
        }

        [Fact]
        public void Edit_IndexNegatif_LemparException()
        {
            // Arrange
            var controller = BuatController();
            controller.Tambah("Listrik", "500000");

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => controller.Edit(-1, "Listrik", "500000"));
            Assert.Contains("Data tidak ditemukan", ex.Message);

            Debug.Assert(ex != null, "Exception harus dilempar saat index negatif pada edit");
        }

        [Fact]
        public void Hapus_IndexValid_DataTerhapus()
        {
            // Arrange
            var controller = BuatController();
            controller.Tambah("Listrik", "500000");
            controller.Tambah("Air", "200000");

            // Act
            controller.Hapus(0);
            List<OperasionalModels> result = (List<OperasionalModels>)controller.GetAll();

            // Assert
            Assert.Single(result);
            Assert.Equal("Air", result[0].Nama);

            Debug.Assert(result.Count == 1, "Harus tersisa 1 data setelah hapus");
            Debug.Assert(result[0].Nama == "Air", "Data yang tersisa tidak sesuai");
        }

        [Fact]
        public void Hapus_SatuData_ListMenjadiKosong()
        {
            // Arrange
            var controller = BuatController();
            controller.Tambah("Listrik", "500000");

            // Act
            controller.Hapus(0);
            List<OperasionalModels> result = (List<OperasionalModels>)controller.GetAll();

            // Assert
            Assert.Empty(result);

            Debug.Assert(result.Count == 0, "List harus kosong setelah satu-satunya data dihapus");
        }

        [Fact]
        public void Hapus_IndexTidakValid_LemparException()
        {
            // Arrange
            var controller = BuatController();
            controller.Tambah("Listrik", "500000");

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => controller.Hapus(99));
            Assert.Contains("Data tidak valid", ex.Message);

            Debug.Assert(ex.Message.Contains("Data tidak valid"),
                "Pesan error index tidak valid saat hapus tidak sesuai");
        }

        [Fact]
        public void Hapus_IndexNegatif_LemparException()
        {
            // Arrange
            var controller = BuatController();
            controller.Tambah("Listrik", "500000");

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => controller.Hapus(-1));
            Assert.Contains("Data tidak valid", ex.Message);

            Debug.Assert(ex != null, "Exception harus dilempar saat index negatif pada hapus");
        }
    }

    //public class FailOnAssertTraceListener : TraceListener
    //{
    //    public override void Write(string message) { }
    //    public override void WriteLine(string message) { }

    //    public override void Fail(string message)
    //    {
    //        throw new Exception($"Debug.Assert gagal: {message}");
    //    }

    //    public override void Fail(string message, string detailMessage)
    //    {
    //        throw new Exception($"Debug.Assert gagal: {message} | Detail: {detailMessage}");
    //    }
    //}
}