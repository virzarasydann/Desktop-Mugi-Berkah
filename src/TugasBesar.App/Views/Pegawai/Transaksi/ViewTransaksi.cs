using ResponseMessageLibrary;   
using System;
using System.Collections.Generic;
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
        private StatusTransaksi _statusSekarang = StatusTransaksi.Kosong;
        private TransaksiControllers _controller;

        public ViewTransaksi()
        {
            InitializeComponent();
            _controller = new TransaksiControllers();

            ApplyLanguage();
            TampilkanKatalog();
            UbahStatus(StatusTransaksi.Kosong);
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

        private void UbahStatus(StatusTransaksi statusBaru)
        {
            _statusSekarang = statusBaru;
            switch (_statusSekarang)
            {
                case StatusTransaksi.Kosong:
                    tbNamaPembeli.Enabled = false;
                    tbUangKembalian.Enabled = false;
                    tbUangDiterima.Enabled = false;
                    tbTotal.Enabled = false;
                    tbStatus.Enabled = false;
                    btnProsesPembayaran.Enabled = false;
                    btnLunas.Enabled = false;
                    btnBelumLunas.Enabled = false;
                    panelListProduk.Enabled = true;
                    break;
                case StatusTransaksi.InputBarang:
                    tbNamaPembeli.Enabled = true;
                    tbUangDiterima.Enabled = true;
                    btnProsesPembayaran.Enabled = false;
                    panelListProduk.Enabled = true;
                    break;
                case StatusTransaksi.Pembayaran:
                    btnProsesPembayaran.Enabled = false;
                    btnLunas.Enabled = true;
                    btnBelumLunas.Enabled = true;
                    break;
                case StatusTransaksi.SiapProses:
                    btnProsesPembayaran.Enabled = true;
                    break;
            }
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