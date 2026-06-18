using ResponseMessageLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using TugasBesar.Core.Controllers.Interfaces;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.Models;
using TugasBesar.Core.Services;
using TugasBesar.Core.Services.Interfaces;
using TugasBesar.Localization;

namespace TugasBesar.App.Views.Pegawai.Transaksi
{
    public enum StatusTransaksi
    {
        Kosong,
        InputBarang,
        Pembayaran,
        SiapProses
    }

    public partial class ViewTransaksi : UserControl
    {
        private readonly ITransaksiApi _transaksiApi;
        private readonly MasterDataCacheService _cache;
        private TransactionInMemory _keranjang;
        private StatusTransaksi _statusSekarang;
        private Control[] _semuaKontrol;
        private Control[] _semuaTextbox;
        private Dictionary<StatusTransaksi, StatusTransaksi[]> _transisiValid;
        private Dictionary<StatusTransaksi, Control[]> _statusKeKontrolAktif;
        private MetodePembayaranModels _metodePembayaran;
        private int _uangDiterima;


        public ViewTransaksi(ITransaksiApi transaksiApi, MasterDataCacheService cache)
        {
            InitializeComponent();
            _transaksiApi = transaksiApi;
            _cache = cache;
            _keranjang = new TransactionInMemory();
            InisialisasiDaftarKontrol();
            InisialisasiMappingStatus();
            InisialisasiTransisi();
            InisialisasiDaftarTextbox();
            ApplyLanguage();
            
            TerapkanStatus(StatusTransaksi.Kosong);
            this.Load += ViewTransaksi_Load;

        }
        private async void ViewTransaksi_Load(object sender, EventArgs e)
        {

            try
            {
                LoadDataComboBox();
                await TampilkanKatalog();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat data: {ex.Message}");
            }
        }
        private bool UbahStatus(StatusTransaksi statusBaru)
        {

            if (_statusSekarang == statusBaru) return true;

            if (_transisiValid.TryGetValue(_statusSekarang, out var tujuan) && Array.Exists(tujuan, s => s == statusBaru))
            {

                TerapkanStatus(statusBaru);

                return true;
            }


            MessageBox.Show("Transisi tidak diizinkan.");
            return false;
        }

        private void TerapkanStatus(StatusTransaksi statusBaru)
        {
            _statusSekarang = statusBaru;


            foreach (var ctrl in _semuaKontrol)
                ctrl.Enabled = false;


            if (_statusKeKontrolAktif.TryGetValue(statusBaru, out var daftarAktif))
                foreach (var ctrl in daftarAktif) ctrl.Enabled = true;


        }

        private void InisialisasiDaftarKontrol()
        {
            _semuaKontrol = new Control[]
            {
                tbNamaPembeli,
                tbUangKembalian,
                tbUangDiterima,
                tbTotal,
                tbStatus,
                btnProsesPembayaran,
                btnLunas,
                btnBelumLunas,
                panelListProduk
            };
        }

        private void InisialisasiDaftarTextbox()
        {
            _semuaTextbox = new Control[]
            {
                tbNamaPembeli,
                tbUangKembalian,
                tbUangDiterima,
                tbTotal,
                tbStatus
            };
        }

        private void InisialisasiMappingStatus()
        {
            _statusKeKontrolAktif = new Dictionary<StatusTransaksi, Control[]>
            {
                { StatusTransaksi.Kosong,      new Control[] { panelListProduk } },
                { StatusTransaksi.InputBarang, new Control[] { panelListProduk ,tbNamaPembeli, tbUangDiterima, panelListProduk } },
                { StatusTransaksi.Pembayaran,  new Control[] { tbNamaPembeli, tbUangDiterima, btnLunas, btnBelumLunas } },
                { StatusTransaksi.SiapProses,  new Control[] { btnProsesPembayaran, btnLunas, btnBelumLunas } }

            };
        }

        private void InisialisasiTransisi()
        {
            _transisiValid = new Dictionary<StatusTransaksi, StatusTransaksi[]>
            {
                { StatusTransaksi.Kosong,      new[] { StatusTransaksi.InputBarang } },
                { StatusTransaksi.InputBarang, new[] { StatusTransaksi.Pembayaran, StatusTransaksi.Kosong } },
                 { StatusTransaksi.Pembayaran,  new[] { StatusTransaksi.SiapProses , StatusTransaksi.InputBarang } },
                { StatusTransaksi.SiapProses,  new[] { StatusTransaksi.Pembayaran, StatusTransaksi.Kosong } },

            };
        }

        public void ApplyLanguage()
        {
            label8.Text = LocalizationService.GetString("lbl_nama_pembeli");
            label9.Text = LocalizationService.GetString("lbl_metode_bayar");
            label11.Text = LocalizationService.GetString("lbl_jumlah_uang");
            label12.Text = LocalizationService.GetString("lbl_kembalian");
            label17.Text = LocalizationService.GetString("lbl_total");

            btnLunas.Text = LocalizationService.GetString("btn_lunas");
            btnBelumLunas.Text = LocalizationService.GetString("btn_belum_lunas");
            btnProsesPembayaran.Text = LocalizationService.GetString("btn_proses");
        }

        private async Task TampilkanKatalog()
        {
            panelListProduk.Controls.Clear();





            foreach (var produk in _cache.DaftarProduk)
            {
                CardProduk ucProduk = new CardProduk();
                ucProduk.NamaProduk = produk.Nama;
                ucProduk.Harga = produk.Harga;

                ucProduk.ProdukDiklik += (sender, e) =>
                {
                    var keranjangResponse = _keranjang.TambahProdukKeKeranjang(produk.Id,ucProduk.NamaProduk, ucProduk.Harga);
                    RenderUlangKeranjang(keranjangResponse);
                };

                panelListProduk.Controls.Add(ucProduk);
            }
        }

        private void RenderUlangKeranjang(List<KeranjangItem> daftarKeranjang)
        {
            UbahStatus(StatusTransaksi.InputBarang);
            panelListKeranjang.Controls.Clear();

            foreach (var item in daftarKeranjang)
            {
                CardKeranjang ucKeranjang = new CardKeranjang();
                ucKeranjang.NamaProduk = item.NamaProduk;
                ucKeranjang.HargaSatuan = item.HargaSatuan;
                ucKeranjang.Jumlah = item.Qty;
                panelListKeranjang.Controls.Add(ucKeranjang);

            }

            UpdateUIGrandTotal();
        }

        private void UpdateUIGrandTotal()
        {
            int totalDiKeranjang = _keranjang.HitungGrandTotal();

            tbTotal.Text = "Rp " + totalDiKeranjang.ToString("N0");
            string teksUangBersih = tbUangDiterima.Text.Replace("Rp ", "").Replace(".", "");
            int uangDiterima = 0;
            if (!string.IsNullOrWhiteSpace(teksUangBersih))
                int.TryParse(teksUangBersih, out uangDiterima);

            _uangDiterima = uangDiterima;
            HitungDanTampilkanKembalian(uangDiterima);
        }

        private void HitungDanTampilkanKembalian(int uangDiterima)
        {
            int totalKembalian = _keranjang.HitungKembalian(uangDiterima);




            if (totalKembalian < 0)
            {
                string msgKurang = LocalizationService.GetString("msg_uang_kurang");
                tbUangKembalian.Text = $"{msgKurang}: Rp " + Math.Abs(totalKembalian).ToString("N0");
                tbUangKembalian.ForeColor = Color.Red;
            }
            else
            {
                tbUangKembalian.Text = "Rp " + totalKembalian.ToString("N0");
                tbUangKembalian.ForeColor = Color.Black;
            }
        }

        private void tbUangDiterima_TextChanged(object sender, EventArgs e)
        {
            string teksBersih = tbUangDiterima.Text.Replace("Rp ", "").Replace(".", "");

            if (string.IsNullOrWhiteSpace(teksBersih))
            {
                UbahStatus(StatusTransaksi.InputBarang);
                HitungDanTampilkanKembalian(0);
                return;
            }

            int posisiKursor = tbUangDiterima.SelectionStart;
            int panjangAwal = tbUangDiterima.Text.Length;

            if (int.TryParse(teksBersih, out int uangDiterima))
            {
                UbahStatus(StatusTransaksi.Pembayaran);
                
                tbUangDiterima.TextChanged -= tbUangDiterima_TextChanged;
                tbUangDiterima.Text = "Rp " + uangDiterima.ToString("N0", new System.Globalization.CultureInfo("id-ID"));
                tbUangDiterima.SelectionStart = tbUangDiterima.Text.Length;
                tbUangDiterima.TextChanged += tbUangDiterima_TextChanged;
                
                HitungDanTampilkanKembalian(uangDiterima);
            }
            else
            {
                UbahStatus(StatusTransaksi.InputBarang);
            }

            int selisihKarakter = tbUangDiterima.Text.Length - panjangAwal;
            tbUangDiterima.SelectionStart = Math.Max(0, posisiKursor + selisihKarakter);
        }



        private async void btnProsesPembayaran_Click(object sender, EventArgs e)
        {


            UbahStatus(StatusTransaksi.Pembayaran);

            if (CbxMetodePembayaran.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih metode pembayaran terlebih dahulu.");
                return;
            }
            int idMetodeTerpilih = (int)CbxMetodePembayaran.SelectedValue;

            
            int idStatusTerpilih = 1;
            var statusTerpilih = _cache.DaftarStatus?.FirstOrDefault(s =>
                s.NamaStatus.Equals(tbStatus.Text, StringComparison.OrdinalIgnoreCase));

            if (statusTerpilih != null)
            {
                idStatusTerpilih = statusTerpilih.IdStatus;
            }

          
            var request = new TransaksiRequestDTO
            {
                IdUser = 1, 
                NamaPembeli = tbNamaPembeli.Text,
                IdMetodePembayaran = idMetodeTerpilih,
                IdStatus = idStatusTerpilih,
                UangDiterima = _uangDiterima,

                
                Keranjang = _keranjang.GetKeranjang()
            };

            var json = System.Text.Json.JsonSerializer.Serialize(request, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            Debug.WriteLine(json);

            try
            {
                var response = await _transaksiApi.Tambah(request);
                MessageBox.Show(response.message ?? "Transaksi Berhasil.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (response.midtrans != null && !string.IsNullOrEmpty(response.midtrans.redirect_url))
                {
                    Process.Start(new ProcessStartInfo(response.midtrans.redirect_url) { UseShellExecute = true });
                }
                var updatedData = await _transaksiApi.GetAll();
                _cache.DaftarTransaksi = updatedData;
                ResetAll();
                TerapkanStatus(StatusTransaksi.Kosong);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }


        }

        private void ResetAll()
        {
            panelListKeranjang.Controls.Clear();
            _keranjang.ResetKeranjang();
            foreach (var text in _semuaTextbox)
            {
                text.Text = string.Empty;
            }

        }
        private void tbTotal_TextChanged(object sender, EventArgs e) { UpdateUIGrandTotal(); }
        private void tbUangDiterima_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }
        private void btnLunas_Click(object sender, EventArgs e)
        {
            tbStatus.Text = "Lunas";
            UbahStatus(StatusTransaksi.SiapProses);
        }
        private void btnBelumLunas_Click(object sender, EventArgs e)
        {
            tbStatus.Text = "Belum Lunas";
            UbahStatus(StatusTransaksi.SiapProses);
        }

        private void labelTransaksiJudul_Click(object sender, EventArgs e)
        {

        }

        private void LoadDataComboBox()
        {
            Debug.WriteLine("AAAAAAAAAAAAAAAAA");
            foreach (var item in _cache.DaftarMetodePembayaran)
            {
                Debug.WriteLine("INI ADALAH ITEM", item.NamaMetode);
            }
            
        
            if (_cache.DaftarMetodePembayaran != null && _cache.DaftarMetodePembayaran.Any())
            {
            
                CbxMetodePembayaran.DataSource = _cache.DaftarMetodePembayaran;

               
                CbxMetodePembayaran.DisplayMember = "NamaMetode";

                
                CbxMetodePembayaran.ValueMember = "IdMetodePembayaran";


                CbxMetodePembayaran.DropDownStyle = ComboBoxStyle.DropDownList;

               
                CbxMetodePembayaran.SelectedIndex = 0;
            }
        }
    }
}