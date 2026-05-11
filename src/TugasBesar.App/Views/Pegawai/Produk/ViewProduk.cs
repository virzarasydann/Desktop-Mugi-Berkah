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
using TugasBesar.Core.Services;
using TugasBesar.App.Configuration;

namespace TugasBesar.App.Views.Pegawai.Produk
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
            var result = ProdukService.TryAdd(tbNamaProduk.Text, cmbKategoriProduk.Text, int.TryParse(tbHargaProduk.Text, out var h) ? h : -1, out var produk);

            if (string.IsNullOrEmpty(tbNamaProduk.Text) ||
                string.IsNullOrEmpty(cmbKategoriProduk.Text) ||
                string.IsNullOrEmpty(tbHargaProduk.Text))
            {
                MessageBox.Show(LocalizationService.GetString("msg_field_kosong"));
                return;
            }

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
                default:
                    MessageBox.Show(LocalizationService.GetString("msg_harga_angka"));
                    return;
            }
        }

        private void btnEditProduk_Click(object sender, EventArgs e)
        {
            if (selectedIndex < 0) return;

            var data = dataProduk.GetAll()[selectedIndex];

            FormEditProduk form = new FormEditProduk(data);

            if (form.ShowDialog() == DialogResult.OK)
            {
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
            // 1. JURUS SAPU JAGAT: Kosongkan data dan hancurkan semua kolom tanpa sisa!
            dgvProduk.DataSource = null;
            dgvProduk.Columns.Clear(); // <-- INI KUNCI UTAMANYA

            var list = dataProduk.GetAll();

            if (list == null || list.Count == 0)
            {
                return;
            }

            // 2. Masukkan data (Sistem akan membuat ulang kolom Nama, Kategori, Harga secara urut)
            dgvProduk.DataSource = list;

            // Sembunyikan kolom Id jika ada di modelmu
            if (dgvProduk.Columns.Contains("Id"))
            {
                dgvProduk.Columns["Id"].Visible = false;
            }

            // 3. Pasang tombolnya (Karena tabelnya baru, tombol pasti dipasang di paling kanan!)
            TambahKolomButton();
        }

        private void ClearInput()
        {
            tbNamaProduk.Text = "";
            cmbKategoriProduk.SelectedIndex = -1;
            tbHargaProduk.Text = "";
        }

        private void tbNamaProduk_TextChanged(object sender, EventArgs e) { }
        private void cmbKategoriProduk_SelectedIndexChanged(object sender, EventArgs e) { }
        private void tbHargaProduk_TextChanged(object sender, EventArgs e) { }
        private void dgvProduk_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

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

        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
    }
}