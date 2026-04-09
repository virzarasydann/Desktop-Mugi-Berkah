using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasBesar.Models;

namespace TugasBesar.Views.Pegawai.Transaksi
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
        public ViewTransaksi()
        {
            
            InitializeComponent();
            TampilkanKatalog();
            UbahStatus(StatusTransaksi.Kosong);
        }

        private int _grandTotalAngka = 0;
        private void TampilkanKatalog()
        {
           
            List<ProdukModels> listProdukModels = new List<ProdukModels>()
            {
                new ProdukModels { Nama = "Karburator Astrea", Harga = 150000 },
                new ProdukModels { Nama = "Pelampung Tangki", Harga = 35000 },
                new ProdukModels { Nama = "Kampas Rem Depan", Harga = 45000 },
                new ProdukModels { Nama = "Busi Standar", Harga = 15000 },
                new ProdukModels { Nama = "Oli Mesin 0.8L", Harga = 55000 }
            };

            
            panelListProduk.Controls.Clear();

            
            foreach (var ProdukModels in listProdukModels)
            {
                CardProduk ucProduk = new CardProduk();
                
                
                ucProduk.NamaProduk = ProdukModels.Nama;
                ucProduk.Harga = ProdukModels.Harga;
                ucProduk.ProdukDiklik += (sender, e) =>
                {

                    CardKeranjang ucKeranjang = new CardKeranjang();
                    ucKeranjang.NamaProduk = ucProduk.NamaProduk;
                    ucKeranjang.Harga = ucProduk.Harga;
                    ucKeranjang.HargaSatuan = ucProduk.Harga;
                    tampilkanKeranjang(ucKeranjang);
                    
                };

                panelListProduk.Controls.Add(ucProduk);
            }
        }

        private void tampilkanKeranjang(CardKeranjang keranjangBaru)
        {
            UbahStatus(StatusTransaksi.InputBarang);
            foreach (Control komponen in panelListKeranjang.Controls)
            {
                
                if (komponen is CardKeranjang)
                {
                    
                    CardKeranjang keranjangLama = (CardKeranjang)komponen;

                   
                    if (keranjangLama.NamaProduk == keranjangBaru.NamaProduk)
                    {
                     
                        keranjangLama.Jumlah += 1;

                        HitungGrandTotal();
                        return;
                    }
                }
            }

           
            keranjangBaru.Jumlah = 1;
            tbTotal.Text = "0";
            
            panelListKeranjang.Controls.Add(keranjangBaru);
            HitungGrandTotal();
        }

        private void HitungGrandTotal()
        {
            int totalKeseluruhan = 0;

            
            foreach (Control komponen in panelListKeranjang.Controls)
            {
                if (komponen is CardKeranjang)
                {
                    CardKeranjang keranjang = (CardKeranjang)komponen;

                    
                    int subtotalKartu = keranjang.HargaSatuan * keranjang.Jumlah;

                    
                    totalKeseluruhan += subtotalKartu;
                }
            }

            _grandTotalAngka = totalKeseluruhan;
            tbTotal.Text = "Rp " + totalKeseluruhan.ToString("N0");
        }

        private void UbahStatus(StatusTransaksi statusBaru)
        {
            _statusSekarang = statusBaru;

            
            switch (_statusSekarang)
            {
                case StatusTransaksi.Kosong:
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
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ViewTransaksi_Load(object sender, EventArgs e)
        {

        }

        private void panelListProduk_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelListKeranjang_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProsesPembayaran_Click(object sender, EventArgs e)
        {
            UbahStatus(StatusTransaksi.Pembayaran);
        }

        private void tbUangDiterima_TextChanged(object sender, EventArgs e)
        {
            string teksBersih = tbUangDiterima.Text.Replace("Rp ", "").Replace(".", "");

            if (string.IsNullOrWhiteSpace(teksBersih))
            {
                UbahStatus(StatusTransaksi.InputBarang);
                HitungKembalian();
                return;
            }

            int posisiKursor = tbUangDiterima.SelectionStart;
            int panjangAwal = tbUangDiterima.Text.Length;

           
            if (int.TryParse(teksBersih, out int uangDiterima))
            {
              
                UbahStatus(StatusTransaksi.Pembayaran);
                tbUangDiterima.Text = "Rp " + uangDiterima.ToString("N0");
            }
            else
            {
                
                UbahStatus(StatusTransaksi.InputBarang);
            }

            int selisihKarakter = tbUangDiterima.Text.Length - panjangAwal;
            tbUangDiterima.SelectionStart = Math.Max(0, posisiKursor + selisihKarakter);

            HitungKembalian();
        }
        private void HitungKembalian()
        {
            int uangDiterima = 0;
            

            
            int.TryParse(tbUangDiterima.Text.Replace("Rp ", "").Replace(".", ""), out uangDiterima);

           
           

          
            int kembalian = uangDiterima - _grandTotalAngka;

            
            if (kembalian < 0)
            {
                tbUangKembalian.Text = "Uang Kurang: Rp " + Math.Abs(kembalian).ToString("N0");
                tbUangKembalian.ForeColor = Color.Red;
            }
            else
            {
                tbUangKembalian.Text = "Rp " + kembalian.ToString("N0");
                tbUangKembalian.ForeColor = Color.Black;
            }
        }
        private void tbTotal_TextChanged(object sender, EventArgs e)
        {
            HitungKembalian();
        }

        private void tbUangDiterima_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                
                e.Handled = true;
            }
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
    }
}
