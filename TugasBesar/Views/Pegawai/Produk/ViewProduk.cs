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
    public partial class ViewProduk : UserControl
    {
        DataGeneric<ProdukModels> dataProduk = new DataGeneric<ProdukModels>();
        int selectedIndex = -1;
        public ViewProduk()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectedIndex = 0;

            if (dataProduk.GetAll().Count == 0)
            {
                MessageBox.Show("Data kosong!");
                return;
            }

            dataProduk.RemoveAt(selectedIndex);

            MessageBox.Show("Produk berhasil dihapus!");

            TampilkanData();
        }

        private void btnTambahProduk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbNamaProduk.Text) ||
                string.IsNullOrEmpty(cmbKategoriProduk.Text) ||
                string.IsNullOrEmpty(tbHargaProduk.Text))
            {
                MessageBox.Show("Semua field harus diisi!");
                return;
            }

            if (!int.TryParse(tbHargaProduk.Text, out int harga))
            {
                MessageBox.Show("Harga harus angka!");
                return;
            }

            ProdukModels produk = new ProdukModels()
            {
                Nama = tbNamaProduk.Text,
                Kategori = cmbKategoriProduk.Text,
                Harga = harga
            };

            dataProduk.Add(produk);

            MessageBox.Show("Produk berhasil ditambahkan!");

            TampilkanData();
            ClearInput();
        }

        private void btnEditProduk_Click(object sender, EventArgs e)
        {
            selectedIndex = 0;

            if (dataProduk.GetAll().Count == 0)
            {
                MessageBox.Show("Data kosong!");
                return;
            }

            if (!int.TryParse(tbHargaProduk.Text, out int harga))
            {
                MessageBox.Show("Harga harus angka!");
                return;
            }

            ProdukModels produk = new ProdukModels()
            {
                Nama = tbNamaProduk.Text,
                Kategori = cmbKategoriProduk.Text,
                Harga = harga
            };

            dataProduk.Update(selectedIndex, produk);

            MessageBox.Show("Produk berhasil diupdate!");

            TampilkanData();
            ClearInput();
        }

        private void btnSetTex_Click(object sender, EventArgs e)
        {
            
            TampilkanData();
            
        }

        private void TampilkanData()
        {
            tableLayoutPanel1.Controls.Clear();

            var list = dataProduk.GetAll();
            tableLayoutPanel1.RowCount = list.Count + 1;

            tableLayoutPanel1.Controls.Add(new Label() { Text = "Nama Produk", AutoSize = true }, 0, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Kategori Produk", AutoSize = true }, 1, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Harga Produk", AutoSize = true }, 2, 0);

            int row = 1;

            foreach (var item in list)
            {
                tableLayoutPanel1.Controls.Add(new Label() { Text = item.Nama }, 0, row);
                tableLayoutPanel1.Controls.Add(new Label() { Text = item.Kategori }, 1, row);
                tableLayoutPanel1.Controls.Add(new Label() { Text = item.Harga.ToString() }, 2, row);
                row++;
            }
        }

        private void ClearInput()
        {
            tbNamaProduk.Text = "";
            cmbKategoriProduk.SelectedIndex = -1;
            tbHargaProduk.Text = "";
        }

        private void tbNamaProduk_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbKategoriProduk_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void tbHargaProduk_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
