//using TugasBesar.App.Views.Admin.AkunPegawai;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasBesar.App.Views.Pegawai.Transaksi;
using TugasBesar.Core.Controllers.Interfaces;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Services;
//using TugasBesar.App.Views.Pegawai.Produk;
//using TugasBesar.App.Views.Pegawai.Kategori;
using TugasBesar.App.Views.Pegawai.Operasional;
using TugasBesar.Localization;

namespace TugasBesar.App.Views.Pegawai
{
    public partial class BaseFormPegawai : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IProdukApi _produkApi;
        private readonly IKategoriApi _kategoriApi;
        private readonly MasterDataCacheService _cache;

        public BaseFormPegawai(
            IServiceProvider serviceProvider,
            IProdukApi produkApi,
            IKategoriApi kategoriApi,
            MasterDataCacheService cache)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _produkApi = produkApi;
            _kategoriApi = kategoriApi;
            _cache = cache;

            ApplyLanguage();
            this.Load += BaseFormPegawai_Load;
        }

        private async void BaseFormPegawai_Load(object sender, EventArgs e)
        {
            if (!_cache.IsLoaded)
            {
               
                var taskProduk = _produkApi.GetAll();
                var taskKategori = _kategoriApi.GetAll();

                await Task.WhenAll(taskProduk, taskKategori);

                var resProduk = taskProduk.Result;
                if (resProduk.IsSuccessStatusCode)
                    _cache.DaftarProduk = resProduk.Content?.ToList() ?? new List<ProdukResponseDTO>();

                var resKategori = taskKategori.Result;
                if (resKategori.IsSuccessStatusCode)
                    _cache.DaftarKategori = resKategori.Content?.ToList() ?? new List<KategoriResponseDTO>();

                _cache.IsLoaded = true;
            }

            PindahLayar(_serviceProvider.GetRequiredService<ViewTransaksi>());
        }

        private void ApplyLanguage()
        {
            buttonTransaksi.Text = LocalizationService.GetString("nav_transaksi");
            buttonProduk.Text = LocalizationService.GetString("nav_produk");
            buttonKategori.Text = LocalizationService.GetString("nav_kategori");
            buttonOperasional.Text = LocalizationService.GetString("nav_operasional");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //PindahLayar(new ViewProduk());
            //PindahLayar(_serviceProvider.GetRequiredService<ViewProduk>());
        }

        private void PindahLayar(UserControl layar)
        {
            panelContent.Controls.Clear();
            layar.Dock = DockStyle.Fill;
            panelContent.Controls.Add(layar);
        }

        

        private void buttonTransaksi_Click(object sender, EventArgs e)
        {
            //PindahLayar(new ViewTransaksi());
            PindahLayar(_serviceProvider.GetRequiredService<ViewTransaksi>());
        }

        private void buttonKategori_Click(object sender, EventArgs e)
        {
            //PindahLayar(new ViewKategori());
            //PindahLayar(_serviceProvider.GetRequiredService<ViewKategori>());
        }

        private void buttonOperasional_Click(object sender, EventArgs e)
        {
            //PindahLayar(new ViewOperasional());
            PindahLayar(_serviceProvider.GetRequiredService<ViewOperasional>());
        }

        private void panelContent_Paint(object sender, PaintEventArgs e) { }


        private void cmbLanguageUtama_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set bahasa di sistem
            if (cmbLanguageUtama.SelectedItem.ToString() == "Indonesia")
            {
                LocalizationService.SetLanguage("id");
            }
            else if (cmbLanguageUtama.SelectedItem.ToString() == "English")
            {
                LocalizationService.SetLanguage("en");
            }

            // menenrjemankan tombol di Navbarnya
            ApplyLanguage();

            // Terjemah halaman yang tampil layar
            if (panelContent.Controls.Count > 0)
            {
                var layarAktif = panelContent.Controls[0];

                if (layarAktif is ViewTransaksi tampilanTransaksi)
                    tampilanTransaksi.ApplyLanguage();
                //else if (layarAktif is ViewProduk tampilanProduk)
                //    tampilanProduk.ApplyLanguage();
                //else if (layarAktif is ViewKategori tampilanKategori)
                //    tampilanKategori.ApplyLanguage();
                //else if (layarAktif is ViewOperasional tampilanOperasional)
                //    tampilanOperasional.ApplyLanguage();
                //else if (layarAktif is ViewTambahAkunPegawai tampilanAdmin)
                //    tampilanAdmin.ApplyLanguage(); // <-- Ini yang akan menerjemahkan halaman Admin
            }
        }
    }
}

