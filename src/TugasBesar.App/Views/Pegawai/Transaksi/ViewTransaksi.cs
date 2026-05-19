using ResponseMessageLibrary;   
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using TugasBesar.Core.Controllers;
using TugasBesar.Core.Models;
using TugasBesar.Core.Services;
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
        private StatusTransaksi _statusSekarang;
        private Control[] _semuaKontrol;
        private Dictionary<StatusTransaksi, StatusTransaksi[]> _transisiValid;
        private Dictionary<StatusTransaksi, Control[]> _statusKeKontrolAktif;
        private TransaksiControllers _controller;

        public ViewTransaksi()
        {
            InitializeComponent();
            _controller = new TransaksiControllers();
            InisialisasiDaftarKontrol();
            InisialisasiMappingStatus();
            InisialisasiTransisi();
            ApplyLanguage();
            TampilkanKatalog();
            TerapkanStatus(StatusTransaksi.Kosong);
            
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

            btnCash.Text = LocalizationService.GetString("btn_cash");
            btnQris.Text = LocalizationService.GetString("btn_qris");
            btnLunas.Text = LocalizationService.GetString("btn_lunas");
            btnBelumLunas.Text = LocalizationService.GetString("btn_belum_lunas");
            btnProsesPembayaran.Text = LocalizationService.GetString("btn_proses");
        }

        private void TampilkanKatalog()
        {
            panelListProduk.Controls.Clear();
            var response = _controller.AmbilKatalog();

            if (!response.IsSuccess)
            {
                tbStatus.Text = response.Message;
                return;
            }

            foreach (var produk in response.Data)
            {
                CardProduk ucProduk = new CardProduk();
                ucProduk.NamaProduk = produk.Nama;
                ucProduk.Harga = produk.Harga;

                ucProduk.ProdukDiklik += (sender, e) =>
                {
                    var keranjangResponse = _controller.ProsesTambahKeranjang(ucProduk.NamaProduk, ucProduk.Harga);
                    if (keranjangResponse.IsSuccess)
                        RenderUlangKeranjang(keranjangResponse.Data);
                    else
                        tbStatus.Text = keranjangResponse.Message;
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
                ucKeranjang.Jumlah = item.Jumlah;
                panelListKeranjang.Controls.Add(ucKeranjang);
            }

            UpdateUIGrandTotal();
        }

        private void UpdateUIGrandTotal()
        {
            var totalResponse = _controller.AmbilGrandTotal();
            if (totalResponse.IsSuccess)
                tbTotal.Text = "Rp " + totalResponse.Data.ToString("N0");
            else
                tbTotal.Text = totalResponse.Message;

            string teksUangBersih = tbUangDiterima.Text.Replace("Rp ", "").Replace(".", "");
            int uangDiterima = 0;
            if (!string.IsNullOrWhiteSpace(teksUangBersih))
                int.TryParse(teksUangBersih, out uangDiterima);

            HitungDanTampilkanKembalian(uangDiterima);
        }

        private void HitungDanTampilkanKembalian(int uangDiterima)
        {
            var response = _controller.ProsesHitungKembalian(uangDiterima);

            if (!response.IsSuccess)
            {
                tbUangKembalian.Text = response.Message;
                tbUangKembalian.ForeColor = Color.Red;
                return;
            }

            int kembalian = response.Data;
            if (kembalian < 0)
            {
                string msgKurang = LocalizationService.GetString("msg_uang_kurang");
                tbUangKembalian.Text = $"{msgKurang}: Rp " + Math.Abs(kembalian).ToString("N0");
                tbUangKembalian.ForeColor = Color.Red;
            }
            else
            {
                tbUangKembalian.Text = "Rp " + kembalian.ToString("N0");
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
                tbUangDiterima.Text = "Rp " + uangDiterima.ToString("N0");
                HitungDanTampilkanKembalian(uangDiterima);
            }
            else
            {
                UbahStatus(StatusTransaksi.InputBarang);
            }

            int selisihKarakter = tbUangDiterima.Text.Length - panjangAwal;
            tbUangDiterima.SelectionStart = Math.Max(0, posisiKursor + selisihKarakter);
        }

       

        // Event handler lainnya tetap sama
        private void ViewTransaksi_Load(object sender, EventArgs e) { }
        private void btnProsesPembayaran_Click(object sender, EventArgs e) { UbahStatus(StatusTransaksi.Pembayaran); }
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

        private void panel2_Paint(object sender, PaintEventArgs e) { }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void btnQris_Click(object sender, EventArgs e)
        {

        }
    }
}