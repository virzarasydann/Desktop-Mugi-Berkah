using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using TugasBesar.Core.Controllers.Interfaces;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasBesar.Core.Models;
using TugasBesar.Core.Services;
using TugasBesar.Core.Controllers;
using TugasBesar.Localization;

namespace TugasBesar.App.Views.Pegawai.Produk
{
    public partial class ViewProduk : UserControl
    {
        private const string KolomId = "id";
        private const string KolomNama = "Nama";
        private const string KolomKategori = "NamaKategori";
        private const string KolomHarga = "Harga";
        private const string KolomEdit = "Edit";
        private const string KolomHapus = "Hapus";

        private readonly IProdukApi _produkApi;
        private readonly MasterDataCacheService _cache;
        int selectedIndex = -1;

        public ViewProduk(IProdukApi produkApi, MasterDataCacheService cache)
        {
            InitializeComponent();
            _produkApi = produkApi;
            _cache = cache;

            dgvProduk.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProduk.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvProduk.CellClick += dgvProduk_CellClick;

            cmbKategoriProduk.DropDownStyle = ComboBoxStyle.DropDownList;
            tbHargaProduk.TextChanged += tbHargaProduk_TextChanged;
            tbHargaProduk.KeyPress += tbHargaProduk_KeyPress;

            ApplyLanguage();
            BuatKolomTetap();

            this.Load += ViewProduk_Load;
        }

        private async void ViewProduk_Load(object sender, EventArgs e)
        {
            LoadKategori();
            await TampilkanData();
        }

        public void ApplyLanguage()
        {
            label2.Text = LocalizationService.GetString("lbl_nama_produk");
            label3.Text = LocalizationService.GetString("lbl_kategori_produk");
            label4.Text = LocalizationService.GetString("lbl_harga_produk");

            btnTambahProduk.Text = LocalizationService.GetString("btn_tambah");

            if (dgvProduk.Columns.Contains(KolomEdit))
                dgvProduk.Columns[KolomEdit].HeaderText = "Aksi";

            if (dgvProduk.Columns.Contains(KolomHapus))
                dgvProduk.Columns[KolomHapus].HeaderText = "Aksi";
        }

        private void BuatKolomTetap()
        {
            dgvProduk.AutoGenerateColumns = false;
            dgvProduk.Columns.Clear();

            dgvProduk.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = KolomId,
                DataPropertyName = "Id",
                HeaderText = "id",
                Visible = false
            });

            dgvProduk.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = KolomNama,
                DataPropertyName = "Nama",
                HeaderText = "Nama"
            });

            dgvProduk.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = KolomKategori,
                DataPropertyName = "NamaKategori",
                HeaderText = "Kategori"
            });

            dgvProduk.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = KolomHarga,
                DataPropertyName = "Harga",
                HeaderText = "Harga"
            });

            dgvProduk.Columns.Add(new DataGridViewButtonColumn
            {
                Name = KolomEdit,
                HeaderText = "Aksi",
                Text = LocalizationService.GetString("btn_edit"),
                UseColumnTextForButtonValue = true
            });

            dgvProduk.Columns.Add(new DataGridViewButtonColumn
            {
                Name = KolomHapus,
                HeaderText = "Aksi",
                Text = LocalizationService.GetString("btn_hapus"),
                UseColumnTextForButtonValue = true
            });

            SesuaikanUkuranGrid();
        }

        private void SesuaikanUkuranGrid()
        {
            int lebarTotal = dgvProduk.RowHeadersWidth;
            foreach (DataGridViewColumn kolom in dgvProduk.Columns)
            {
                if (kolom.Visible)
                    lebarTotal += kolom.Width;
            }

            int tinggiTotal = dgvProduk.ColumnHeadersHeight;
            foreach (DataGridViewRow baris in dgvProduk.Rows)
            {
                if (baris.Visible)
                    tinggiTotal += baris.Height;
            }

            dgvProduk.Width = lebarTotal + 2;
            dgvProduk.Height = tinggiTotal + 2;
        }

        private async void ViewProduk_Enter(object sender, EventArgs e)
        {
            LoadKategori();
            await TampilkanData();
        }

        private async void btnTambahProduk_Click(object sender, EventArgs e)
        {
            try
            {
                var kategori = _cache.DaftarKategori.FirstOrDefault(k => k.nama == cmbKategoriProduk.Text);
                if (kategori == null) throw new Exception("Kategori tidak valid!");

                var request = new TugasBesar.Core.DTO.Request.ProdukRequestDTO
                {
                    nama = tbNamaProduk.Text,
                    kategori_id = kategori.id,
                    harga = int.Parse(tbHargaProduk.Text.Replace("Rp ", "").Replace(".", ""))
                };
                await _produkApi.Tambah(request);
                MessageBox.Show("Produk berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await TampilkanData();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnEditProduk_Click(object sender, EventArgs e)
        {
            if (selectedIndex < 0) return;

            var data = _cache.DaftarProduk[selectedIndex];

            var modelData = new ProdukModels { id = data.Id, nama = data.Nama, Kategori = new KategoriModels { id = data.KategoriId, nama = data.NamaKategori }, harga = data.Harga };

            var categories = _cache.DaftarKategori?.Select(k => k.nama).ToList();
            FormEditProduk form = new FormEditProduk(modelData, categories);

            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var kategori = _cache.DaftarKategori.FirstOrDefault(k => k.nama == form.produk.Kategori?.nama);
                    if (kategori == null) throw new Exception("Kategori tidak valid!");

                    var request = new TugasBesar.Core.DTO.Request.ProdukRequestDTO
                    {
                        nama = form.produk.nama,
                        kategori_id = kategori.id,
                        harga = form.produk.harga
                    };
                    await _produkApi.Edit(data.Id, request);
                    await TampilkanData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private async Task TampilkanData()
        {
            try
            {
                var response = await _produkApi.GetAll();
                if (response != null && response.Content != null)
                {
                    _cache.DaftarProduk = response.Content.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data produk: {ex.Message}");
            }

            dgvProduk.DataSource = _cache.DaftarProduk;

            if (_cache.DaftarProduk != null && _cache.DaftarProduk.Count > 0)
                dgvProduk.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            SesuaikanUkuranGrid();
        }

        private void ClearInput()
        {
            tbNamaProduk.Text = "";
            cmbKategoriProduk.SelectedIndex = -1;
            tbHargaProduk.Text = "";
        }

        private async void dgvProduk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (e.RowIndex >= _cache.DaftarProduk.Count) return;

            selectedIndex = e.RowIndex;

            var data = _cache.DaftarProduk[e.RowIndex];
            var modelData = new ProdukModels { id = data.Id, nama = data.Nama, Kategori = new KategoriModels { id = data.KategoriId, nama = data.NamaKategori }, harga = data.Harga };

            if (dgvProduk.Columns[e.ColumnIndex].Name == KolomEdit)
            {
                var categories = _cache.DaftarKategori?.Select(k => k.nama).ToList();
                FormEditProduk form = new FormEditProduk(modelData, categories);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var kategori = _cache.DaftarKategori.FirstOrDefault(k => k.nama == form.produk.Kategori?.nama);
                        if (kategori == null) throw new Exception("Kategori tidak valid!");

                        var request = new TugasBesar.Core.DTO.Request.ProdukRequestDTO
                        {
                            nama = form.produk.nama,
                            kategori_id = kategori.id,
                            harga = form.produk.harga
                        };
                        await _produkApi.Edit(data.Id, request);
                        MessageBox.Show("Produk berhasil diubah!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await TampilkanData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else if (dgvProduk.Columns[e.ColumnIndex].Name == KolomHapus)
            {
                var confirm = MessageBox.Show(
                    "Yakin mau menghapus produk ini?",
                    "Konfirmasi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        await _produkApi.Hapus(data.Id);
                        MessageBox.Show("Produk berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await TampilkanData();
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

            if (_cache.DaftarKategori != null)
            {
                foreach (var item in _cache.DaftarKategori)
                {
                    cmbKategoriProduk.Items.Add(item.nama);
                }
            }
        }

        private void tbHargaProduk_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbHargaProduk.Text)) return;

            string value = tbHargaProduk.Text.Replace("Rp ", "").Replace(".", "");
            if (decimal.TryParse(value, out decimal harga))
            {
                tbHargaProduk.TextChanged -= tbHargaProduk_TextChanged;
                tbHargaProduk.Text = "Rp " + harga.ToString("N0", new System.Globalization.CultureInfo("id-ID"));
                tbHargaProduk.SelectionStart = tbHargaProduk.Text.Length;
                tbHargaProduk.TextChanged += tbHargaProduk_TextChanged;
            }
        }

        private void tbHargaProduk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}