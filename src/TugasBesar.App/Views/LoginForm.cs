using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasBesar.App.Views.Admin;

//using TugasBesar.App.Views.Admin.AkunPegawai;
using TugasBesar.App.Views.Pegawai;
using TugasBesar.Core.Controllers.Interfaces;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Services;
using TugasBesar.Localization;

namespace TugasBesar.App.Views
{
    public partial class LoginForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IProdukApi _produkApi;
        private readonly IKategoriApi _kategoriApi;
        private readonly IMetodePembayaranApi _metodePembayaranApi;
        private readonly IStatusApi _statusApi;
        private readonly MasterDataCacheService _cache;


        public LoginForm(IServiceProvider serviceProvider, IProdukApi produkApi,
            IKategoriApi kategoriApi,
            IMetodePembayaranApi metodePembayaranApi,
            IStatusApi statusApi,
            MasterDataCacheService cache)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _produkApi = produkApi;
            _kategoriApi = kategoriApi;
            _metodePembayaranApi = metodePembayaranApi;
            _statusApi = statusApi;
            _cache = cache;

            cmbLanguage.Items.Clear();
            cmbLanguage.Items.Add("Indonesia");
            cmbLanguage.Items.Add("English");
            cmbLanguage.SelectedIndex = 0;
            button1.Enabled = false;
            button1.Text = "Menyiapkan Data...";
            this.Load += LoginForm_Load;
        }

        private void ApplyLanguage()
        {
            this.Text = LocalizationService.GetString("login_title");
            button1.Text = LocalizationService.GetString("btn_login");


            textBoxUsername.Text = LocalizationService.GetString("placeholder_username");
            textBoxPassword.Text = LocalizationService.GetString("placeholder_password");
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLanguage.SelectedItem.ToString() == "Indonesia")
            {
                LocalizationService.SetLanguage("id");
            }
            else if (cmbLanguage.SelectedItem.ToString() == "English")
            {
                LocalizationService.SetLanguage("en");
            }

            ApplyLanguage();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBoxUsername.Text;
            String password = textBoxPassword.Text;

            //var formPegawai = _serviceProvider.GetRequiredService<BaseFormPegawai>();
            var formPegawai = _serviceProvider.GetRequiredService<BaseFormAdmin>();
            formPegawai.FormClosed += (s, args) => this.Close();

            this.Hide();
            formPegawai.Show();
        }

        private async void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (!_cache.IsLoaded)
                {
                    // Retry mechanism: tunggu API siap (max 10x percobaan, jeda 2 detik)
                    int maxRetries = 10;
                    for (int attempt = 1; attempt <= maxRetries; attempt++)
                    {
                        try
                        {
                            button1.Text = $"Menunggu API... ({attempt}/{maxRetries})";

                            var taskProduk = _produkApi.GetAll();
                            var taskKategori = _kategoriApi.GetAll();
                            var taskMetodePembayaran = _metodePembayaranApi.GetAll();
                            var taskStatus = _statusApi.GetAll();

                            await Task.WhenAll(taskProduk, taskKategori, taskMetodePembayaran, taskStatus);

                            var resProduk = taskProduk.Result;
                            if (resProduk.IsSuccessStatusCode)
                                _cache.DaftarProduk = resProduk.Content?.ToList() ?? new List<ProdukResponseDTO>();

                            var resKategori = taskKategori.Result;
                            if (resKategori.IsSuccessStatusCode)
                                _cache.DaftarKategori = resKategori.Content?.ToList() ?? new List<KategoriResponseDTO>();

                            var resMetodePembayaran = taskMetodePembayaran.Result;
                            Debug.WriteLine(resMetodePembayaran);
                            if (resMetodePembayaran.IsSuccessStatusCode)
                                _cache.DaftarMetodePembayaran = resMetodePembayaran.Content?.ToList() ?? new List<MetodePembayaranResponseDTO>();

                            var resStatus = taskStatus.Result;
                            if (resStatus.IsSuccessStatusCode)
                                _cache.DaftarStatus = resStatus.Content?.ToList() ?? new List<StatusResponseDTO>();

                            _cache.IsLoaded = true;
                            button1.Enabled = true;
                            button1.Text = LocalizationService.GetString("btn_login");
                            return; // Berhasil, keluar dari loop
                        }
                        catch (Exception) when (attempt < maxRetries)
                        {
                            // API belum siap, tunggu 2 detik lalu coba lagi
                            await Task.Delay(2000);
                        }
                    }

                    // Jika semua percobaan gagal
                    throw new Exception("API tidak dapat dihubungi setelah beberapa percobaan.");
                }
                else
                {
                    
                    button1.Enabled = true;
                    button1.Text = LocalizationService.GetString("btn_login");
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"Terjadi Error Koneksi Sistem:\n{ex.Message}\n\nStack Trace:\n{ex.StackTrace}");
            }

        }
    }
}