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
using KategoriModel = TugasBesar.Core.Models.KategoriModels;

namespace TugasBesar.App.Views.Pegawai.Kategori
{
    public partial class ViewKategori : UserControl
    {
        private const string KolomId = "id";
        private const string KolomNama = "Nama";
        private const string KolomEdit = "Edit";
        private const string KolomHapus = "Hapus";

        private readonly IKategoriApi _kategoriApi;
        private readonly MasterDataCacheService _cache;
        int selectedIndex = -1;

        public ViewKategori(IKategoriApi kategoriApi, MasterDataCacheService cache)
        {
            InitializeComponent();
            _kategoriApi = kategoriApi;
            _cache = cache;

            dgvKategori.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvKategori.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvKategori.CellClick += dgvKategori_CellClick;

            ApplyLanguage();
            BuatKolomTetap();

            this.Load += ViewKategori_Load;
        }

        private async void ViewKategori_Load(object sender, EventArgs e)
        {
            await TampilkanData();
        }

        public void ApplyLanguage()
        {
            btnTambahKategori.Text = LocalizationService.GetString("btn_tambah");
            label1.Text = LocalizationService.GetString("lbl_nama_kategori");
            label2.Text = LocalizationService.GetString("lbl_nama_kategori");

            if (dgvKategori.Columns.Contains(KolomEdit))
                dgvKategori.Columns[KolomEdit].HeaderText = "Aksi";

            if (dgvKategori.Columns.Contains(KolomHapus))
                dgvKategori.Columns[KolomHapus].HeaderText = "Aksi";
        }

        private void BuatKolomTetap()
        {
            dgvKategori.AutoGenerateColumns = false;
            dgvKategori.Columns.Clear();

            dgvKategori.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = KolomId,
                DataPropertyName = "id",
                HeaderText = "id",
                Visible = false
            });

            dgvKategori.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = KolomNama,
                DataPropertyName = "nama",
                HeaderText = "Nama"
            });

            dgvKategori.Columns.Add(new DataGridViewButtonColumn
            {
                Name = KolomEdit,
                HeaderText = "Aksi",
                Text = LocalizationService.GetString("btn_edit"),
                UseColumnTextForButtonValue = true
            });

            dgvKategori.Columns.Add(new DataGridViewButtonColumn
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
            int lebarTotal = dgvKategori.RowHeadersWidth;
            foreach (DataGridViewColumn kolom in dgvKategori.Columns)
            {
                if (kolom.Visible)
                    lebarTotal += kolom.Width;
            }

            int tinggiTotal = dgvKategori.ColumnHeadersHeight;
            foreach (DataGridViewRow baris in dgvKategori.Rows)
            {
                if (baris.Visible)
                    tinggiTotal += baris.Height;
            }

            dgvKategori.Width = lebarTotal + 2;
            dgvKategori.Height = tinggiTotal + 2;
        }

        private async void btnTambahKategori_Click(object sender, EventArgs e)
        {
            try
            {
                var request = new TugasBesar.Core.DTO.Request.KategoriRequestDTO { Nama = tbNamaKategori.Text };
                await _kategoriApi.Tambah(request);
                MessageBox.Show("Kategori berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await TampilkanData();
                tbNamaKategori.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnEditKategori_Click(object sender, EventArgs e)
        {
            if (selectedIndex < 0)
            {
                MessageBox.Show(LocalizationService.GetString("msg_pilih_data"));
                return;
            }

            try
            {
                int id = _cache.DaftarKategori[selectedIndex].id;
                string oldName = _cache.DaftarKategori[selectedIndex].nama;

                if (oldName == tbNamaKategori.Text.Trim())
                {
                    MessageBox.Show("Tidak ada perubahan pada nama kategori.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var request = new TugasBesar.Core.DTO.Request.KategoriRequestDTO { Nama = tbNamaKategori.Text.Trim() };
                await _kategoriApi.Edit(id, request);
                MessageBox.Show("Kategori berhasil diubah!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await TampilkanData();
                tbNamaKategori.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnHapusKategori_Click(object sender, EventArgs e)
        {
            if (selectedIndex < 0)
            {
                MessageBox.Show(LocalizationService.GetString("msg_pilih_data"));
                return;
            }

            try
            {
                int id = _cache.DaftarKategori[selectedIndex].id;
                await _kategoriApi.Hapus(id);
                MessageBox.Show("Kategori berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await TampilkanData();
                tbNamaKategori.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task TampilkanData()
        {
            try
            {
                var response = await _kategoriApi.GetAll();
                if (response != null && response.Content != null)
                {
                    _cache.DaftarKategori = response.Content.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data kategori dari server: {ex.Message}");
            }

            dgvKategori.DataSource = _cache.DaftarKategori;

            if (_cache.DaftarKategori != null && _cache.DaftarKategori.Count > 0)
                dgvKategori.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            SesuaikanUkuranGrid();

            selectedIndex = -1;
        }

        private async void dgvKategori_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (e.RowIndex >= _cache.DaftarKategori.Count) return;

            var data = _cache.DaftarKategori[e.RowIndex];

            var modelData = new KategoriModels { id = data.id, nama = data.nama };

            if (dgvKategori.Columns[e.ColumnIndex].Name == KolomEdit)
            {
                FormEditKategori form = new FormEditKategori(modelData);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var request = new TugasBesar.Core.DTO.Request.KategoriRequestDTO { Nama = form.kategori?.nama };
                        await _kategoriApi.Edit(data.id, request);
                        await TampilkanData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else if (dgvKategori.Columns[e.ColumnIndex].Name == KolomHapus)
            {
                var confirm = MessageBox.Show(
                    "Yakin mau menghapus kategori ini?",
                    "Konfirmasi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        await _kategoriApi.Hapus(data.id);
                        MessageBox.Show("Kategori berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await TampilkanData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

    }
}