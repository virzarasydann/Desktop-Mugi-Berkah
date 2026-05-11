using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasBesar.Core.Models;
using TugasBesar.Localization;
using TugasBesar.Core.Services;
namespace TugasBesar.App.Views.Pegawai.Kategori
{
    public partial class FormEditKategori : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public KategoriModels kategori { get; set; }

        public FormEditKategori(KategoriModels data = null)
        {
            InitializeComponent();

            ApplyLanguage();

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

            ApplyLanguage();
        }

        public void ApplyLanguage()
        {
            this.Text = LocalizationService.GetString("title_edit_kategori");

            Nama.Text = LocalizationService.GetString("lbl_nama_kategori");

            btnSimpan.Text = LocalizationService.GetString("btn_simpan");
        }

        private void tbNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbNama.Text))
            {
                MessageBox.Show(LocalizationService.GetString("msg_nama_kategori_kosong"));
                return;
            }

            kategori.Nama = tbNama.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormEditKategori_Load(object sender, EventArgs e)
        {

        }

        private void Nama_Click(object sender, EventArgs e)
        {

        }
    }
}