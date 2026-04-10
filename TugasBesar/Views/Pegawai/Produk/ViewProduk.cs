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
        DataGeneric<ProdukModels> dataProduk = DataManager.Produk;
        int selectedIndex = -1;
        public ViewProduk()
        {
            InitializeComponent();

            dgvProduk.CellClick += dgvProduk_CellClick;

            TambahKolomButton();
            LoadKategori();
            TampilkanData();
        }

        private void TambahKolomButton()
        {
            if (!dgvProduk.Columns.Contains("Aksi"))
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Name = "Aksi";
                btn.HeaderText = "Aksi";
                btn.UseColumnTextForButtonValue = false;

                btn.DefaultCellStyle.NullValue = "Edit";

                dgvProduk.Columns.Add(btn);
            }
        }

        private void ViewProduk_Enter(object sender, EventArgs e)
        {
            LoadKategori();
            TampilkanData();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedIndex < 0)
            {
                MessageBox.Show("Pilih data dulu!");
                return;
            }

            dataProduk.RemoveAt(selectedIndex);

            TampilkanData();
            ClearInput();
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

            TampilkanData();
            ClearInput();
        }

        private void btnEditProduk_Click(object sender, EventArgs e)
        {

            if (selectedIndex < 0)
            {
                MessageBox.Show("Pilih data dulu!");
                return;
            }

            var data = dataProduk.GetAll()[selectedIndex];

            FormEditProduk form = new FormEditProduk(data);

            if (form.ShowDialog() == DialogResult.OK)
            {
                TampilkanData();
            }
        }

        private void btnSetTex_Click(object sender, EventArgs e)
        {
            
            TampilkanData();
            
        }

        private void TampilkanData()
        {
            dgvProduk.DataSource = null;

            var list = dataProduk.GetAll();

            if (list.Count == 0)
            {
                dgvProduk.DataSource = null;
                return;
            }

            dgvProduk.DataSource = list;

            TambahKolomButton();

            if (dgvProduk.Columns.Contains("Aksi"))
                dgvProduk.Columns["Aksi"].DisplayIndex = dgvProduk.Columns.Count - 1;
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

        private void dgvProduk_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       
        }

        private void dgvProduk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.RowIndex >= dataProduk.GetAll().Count) return; 

            selectedIndex = e.RowIndex;

            if (dgvProduk.Columns[e.ColumnIndex].Name == "Aksi")
            {
                var data = dataProduk.GetAll()[e.RowIndex];

                FormEditProduk form = new FormEditProduk(data);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    TampilkanData();
                }
            }
        }

        private void LoadKategori()
        {
            cmbKategoriProduk.Items.Clear();

            foreach (var item in DataManager.Kategori.GetAll())
            {
                cmbKategoriProduk.Items.Add(item.Nama);
            }
        }
    }
}
