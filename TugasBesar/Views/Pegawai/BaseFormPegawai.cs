using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasBesar.Views.Pegawai.Transaksi;
using TugasBesar.Views.Pegawai.Produk;
using TugasBesar.Views.Pegawai.Kategori;
using TugasBesar.Views.Pegawai.Operasional;
using TugasBesar.Services;

namespace TugasBesar.Views.Pegawai
{
    public partial class BaseFormPegawai : Form
    {
        public BaseFormPegawai()
        {
            InitializeComponent();

            ApplyLanguage();

            PindahLayar(new ViewTransaksi());
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
            PindahLayar(new ViewProduk());
        }

        private void PindahLayar(UserControl layar)
        {
            panelContent.Controls.Clear();
            layar.Dock = DockStyle.Fill;
            panelContent.Controls.Add(layar);
        }

        private void BaseFormPegawai_Load(object sender, EventArgs e) { }

        private void buttonTransaksi_Click(object sender, EventArgs e)
        {
            PindahLayar(new ViewTransaksi());
        }

        private void buttonKategori_Click(object sender, EventArgs e)
        {
            PindahLayar(new ViewKategori());
        }

        private void buttonOperasional_Click(object sender, EventArgs e)
        {
            PindahLayar(new ViewOperasional());
        }

        private void panelContent_Paint(object sender, PaintEventArgs e) { }


        private void cmbLanguageUtama_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLanguageUtama.SelectedItem.ToString() == "Indonesia")
            {
                LocalizationService.SetLanguage("id");
            }
            else if (cmbLanguageUtama.SelectedItem.ToString() == "English")
            {
                LocalizationService.SetLanguage("en");
            }

            ApplyLanguage();

            if (panelContent.Controls.Count > 0)
            {
                var layarAktif = panelContent.Controls[0];

                if (layarAktif is ViewTransaksi tampilanTransaksi)
                {
                    tampilanTransaksi.ApplyLanguage();
                }
                else if (layarAktif is ViewProduk tampilanProduk)
                {
                    tampilanProduk.ApplyLanguage();
                }
                else if (layarAktif is ViewKategori tampilanKategori)
                {
                    tampilanKategori.ApplyLanguage();
                }
            }
        }
    }
}

