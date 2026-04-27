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

namespace TugasBesar.Views.Pegawai.Produk
{
    public partial class FormEditProduk : Form
    {
        public ProdukModels produk { get; set; }

        public FormEditProduk(ProdukModels data)
        {
            InitializeComponent();

            produk = data; 

            LoadKategori();

            tbNama.Text = data.Nama;
            cmbKategori.Text = data.Kategori;
            tbHarga.Text = data.Harga.ToString();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(tbNama.Text))
            {
                MessageBox.Show("Nama produk tidak boleh kosong!");
                return;
            }

            if (string.IsNullOrEmpty(cmbKategori.Text))
            {
                MessageBox.Show("Kategori harus dipilih!");
                return;
            }

            if (!int.TryParse(tbHarga.Text, out int harga))
            {
                MessageBox.Show("Harga harus berupa angka!");
                return;
            }

            if (produk == null)
            {
                MessageBox.Show("Data produk tidak ditemukan!");
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

        private void tbHarga_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormEditProduk_Load(object sender, EventArgs e)
        {

        }
    }
}
