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
            dgvProduk.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProduk.CellClick += dgvProduk_CellClick;

            
            LoadKategori();
            TampilkanData();
        }

        private void TambahKolomButton()
        {
            if (!dgvProduk.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
                btnEdit.Name = "Edit";
                btnEdit.HeaderText = "Edit";
                btnEdit.Text = "Edit";
                btnEdit.UseColumnTextForButtonValue = true;

                dgvProduk.Columns.Add(btnEdit);
            }

            if (!dgvProduk.Columns.Contains("Hapus"))
            {
                DataGridViewButtonColumn btnHapus = new DataGridViewButtonColumn();
                btnHapus.Name = "Hapus";
                btnHapus.HeaderText = "Hapus";
                btnHapus.Text = "Hapus";
                btnHapus.UseColumnTextForButtonValue = true;

                dgvProduk.Columns.Add(btnHapus);
            }
        }

        private void ViewProduk_Enter(object sender, EventArgs e)
        {
            LoadKategori();
            TampilkanData();
        }


        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void btnTambahProduk_Click(object sender, EventArgs e)
        {
            var result = ProdukService.TryAdd(tbNamaProduk.Text, cmbKategoriProduk.Text, int.TryParse(tbHargaProduk.Text, out var h) ? h : -1, out var produk);

            switch (result)
            {
                case ProdukResult.Invalid:
                    MessageBox.Show("Semua field harus diisi dan harga harus angka >= 0!");
                    break;
                case ProdukResult.Duplicate:
                    MessageBox.Show("Produk dengan nama dan kategori yang sama sudah ada!");
                    break;
                case ProdukResult.Success:
                    TampilkanData();
                    ClearInput();
                    break;
            }
        }

        private void btnEditProduk_Click(object sender, EventArgs e)
        {
            var data = dataProduk.GetAll()[selectedIndex];

            FormEditProduk form = new FormEditProduk(data);

            if (form.ShowDialog() == DialogResult.OK)
            {
                // Use service to enforce DBC
                var result = ProdukService.TryUpdate(selectedIndex, data.Nama, data.Kategori, data.Harga, out var updated);

                switch (result)
                {
                    case ProdukResult.Invalid:
                        MessageBox.Show("Data produk tidak valid!");
                        break;
                    case ProdukResult.Unchanged:
                        MessageBox.Show("Data masih sama!");
                        break;
                    case ProdukResult.Duplicate:
                        MessageBox.Show("Produk dengan nama dan kategori yang sama sudah ada!");
                        break;
                    case ProdukResult.Success:
                        TampilkanData();
                        break;
                }
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

            if (dgvProduk.Columns.Contains("Edit"))
                dgvProduk.Columns["Edit"].DisplayIndex = dgvProduk.Columns.Count - 2;

            if (dgvProduk.Columns.Contains("Hapus"))
                dgvProduk.Columns["Hapus"].DisplayIndex = dgvProduk.Columns.Count - 1;
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
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (e.RowIndex >= dataProduk.GetAll().Count) return;

            selectedIndex = e.RowIndex;

            var data = dataProduk.GetAll()[e.RowIndex];

            if (dgvProduk.Columns[e.ColumnIndex].Name == "Edit")
            {
                FormEditProduk form = new FormEditProduk(data);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    TampilkanData();
                }
            }

            else if (dgvProduk.Columns[e.ColumnIndex].Name == "Hapus")
            {
                var confirm = MessageBox.Show(
                    "Yakin mau hapus data ini?",
                    "Konfirmasi",
                    MessageBoxButtons.YesNo
                );

                if (confirm == DialogResult.Yes)
                {
                    dataProduk.RemoveAt(e.RowIndex);
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
