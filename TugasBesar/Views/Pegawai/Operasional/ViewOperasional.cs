using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasBesar.Services;

namespace TugasBesar.Views.Pegawai.Operasional
{
    public partial class ViewOperasional : UserControl
    {
        public ViewOperasional()
        {
            InitializeComponent();

            ApplyLanguage();
        }

        public void ApplyLanguage()
        {
            btnTambahOperasional.Text = LocalizationService.GetString("btn_tambah");
            btnSetText.Text = LocalizationService.GetString("btn_refresh");

         
            btnEditOperasional.Text = LocalizationService.GetString("btn_edit");

           
            label2.Text = LocalizationService.GetString("lbl_nama_operasional");
            label3.Text = LocalizationService.GetString("lbl_biaya_operasional");
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void btnTambahOperasional_Click(object sender, EventArgs e) { }

        private void btnEditOperasional_Click(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }

        private void tbNamaOperasional_TextChanged(object sender, EventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }

        private void tbHargaOperasional_TextChanged(object sender, EventArgs e) { }

        private void label5_Click(object sender, EventArgs e) { }

        private void label4_Click(object sender, EventArgs e) { }

        private void label6_Click(object sender, EventArgs e) { }

        private void btnSetText_Click(object sender, EventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}