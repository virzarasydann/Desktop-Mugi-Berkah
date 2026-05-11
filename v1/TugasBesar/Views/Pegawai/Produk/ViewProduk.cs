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
using TugasBesar.Controllers;

namespace TugasBesar.Views.Pegawai.Produk
{
    public partial class ViewProduk : UserControl
    {
        DataGeneric<ProdukModels> dataProduk = DataManager.Produk;
        ProdukController _produkController = new ProdukController();
        int selectedIndex = -1;

        public ViewProduk()
        {
            InitializeComponent();
            dgvProduk.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProduk.CellClick += dgvProduk_CellClick;

            ApplyLanguage();

            LoadKategori();
            TampilkanData();
        }

        public void ApplyLanguage()
        {
            label2.Text = LocalizationService.GetString("lbl_nama_produk");
            label3.Text = LocalizationService.GetString("lbl_kategori_produk");
            label4.Text = LocalizationService.GetString("lbl_harga_produk");

            btnTambahProduk.Text = LocalizationService.GetString("btn_tambah");
            btnSetTex.Text = LocalizationService.GetString("btn_refresh");

            if (dgvProduk.Columns.Contains("Edit"))
            {
                dgvProduk.Columns["Edit"].HeaderText = LocalizationService.GetString("btn_edit");
            }
            if (dgvProduk.Columns.Contains("Hapus"))
            {
                dgvProduk.Columns["Hapus"].HeaderText = LocalizationService.GetString("btn_hapus");
            }
        }

        private void TambahKolomButton()
        {
            if (!dgvProduk.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
                btnEdit.Name = "Edit";
                btnEdit.HeaderText = LocalizationService.GetString("btn_edit");
                btnEdit.Text = LocalizationService.GetString("btn_edit");
                btnEdit.UseColumnTextForButtonValue = true;

                dgvProduk.Columns.Add(btnEdit);
            }

            if (!dgvProduk.Columns.Contains("Hapus"))
            {
                DataGridViewButtonColumn btnHapus = new DataGridViewButtonColumn();
                btnHapus.Name = "Hapus";
                btnHapus.HeaderText = LocalizationService.GetString("btn_hapus");
                btnHapus.Text = LocalizationService.GetString("btn_hapus");
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
            try
            {
                _produkController.Tambah(tbNamaProduk.Text, cmbKategoriProduk.Text, tbHargaProduk.Text);
                TampilkanData();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditProduk_Click(object sender, EventArgs e)
        {
            if (selectedIndex < 0) return;

            var data = dataProduk.GetAll()[selectedIndex];

            FormEditProduk form = new FormEditProduk(data);

            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _produkController.Edit(selectedIndex, data.Nama, data.Kategori, data.Harga.ToString());
                    TampilkanData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    LocalizationService.GetString("msg_hapus_konfirmasi"),
                    LocalizationService.GetString("title_konfirmasi"),
                    MessageBoxButtons.YesNo
                );

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        _produkController.Hapus(e.RowIndex);
                        TampilkanData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }
    }
}