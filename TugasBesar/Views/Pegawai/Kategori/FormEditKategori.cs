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
using TugasBesar.Services;

namespace TugasBesar.Views.Pegawai.Kategori
{
    public partial class FormEditKategori : Form
    {
        public KategoriModels kategori { get; set; }

        public FormEditKategori(KategoriModels data = null)
        {
            InitializeComponent();

            if (data != null)  
            {
                kategori = data;
                tbNama.Text = data.Nama;
            }
            else
            {
                kategori = new KategoriModels();
            }
        }
        public FormEditKategori()
        {
            InitializeComponent();
        }

        private void tbNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbNama.Text))
            {
                MessageBox.Show("Nama kategori tidak boleh kosong!");
                return;
            }

            kategori.Nama = tbNama.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
