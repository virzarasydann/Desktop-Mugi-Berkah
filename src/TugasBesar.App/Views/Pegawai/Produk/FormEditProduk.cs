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
namespace TugasBesar.App.Views.Pegawai.Produk
{
    public partial class FormEditProduk : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProdukModels produk { get; set; }

        public FormEditProduk(ProdukModels data)
        {
            InitializeComponent();
            produk = data;

            ApplyLanguage();

            LoadKategori();

            tbNama.Text = data.Nama;
            cmbKategori.Text = data.Kategori;
            tbHarga.Text = data.Harga.ToString();
        }

        public void ApplyLanguage()
        {
            this.Text = LocalizationService.GetString("title_edit_produk");

            
            label1.Text = LocalizationService.GetString("lbl_nama_produk");
            label2.Text = LocalizationService.GetString("lbl_kategori_produk");
            label3.Text = LocalizationService.GetString("lbl_harga_produk");

            btnSimpan.Text = LocalizationService.GetString("btn_simpan");
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbNama.Text))
            {
                MessageBox.Show(LocalizationService.GetString("msg_nama_kosong"));
                return;
            }

            if (string.IsNullOrEmpty(cmbKategori.Text))
            {
                MessageBox.Show(LocalizationService.GetString("msg_kategori_kosong"));
                return;
            }

            if (!int.TryParse(tbHarga.Text, out int harga))
            {
                MessageBox.Show(LocalizationService.GetString("msg_harga_angka"));
                return;
            }

            if (produk == null)
            {
                MessageBox.Show(LocalizationService.GetString("msg_data_tidak_ditemukan"));
                return;
            }

            produk.Nama = tbNama.Text.Trim();
            produk.Kategori = cmbKategori.Text.Trim();
            produk.Harga = harga;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void LoadKategori()
        {
            cmbKategori.Items.Clear();

            foreach (var item in DataManager.Kategori.GetAll())
            {
                cmbKategori.Items.Add(item.Nama);
            }


        }

        private void tbHarga_TextChanged(object sender, EventArgs e) { }
        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e) { }
        private void tbNama_TextChanged(object sender, EventArgs e) { }
        private void FormEditProduk_Load(object sender, EventArgs e) { }
    }
}