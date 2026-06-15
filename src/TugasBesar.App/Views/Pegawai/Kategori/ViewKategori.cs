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
        private readonly IKategoriApi _kategoriApi;
        private readonly MasterDataCacheService _cache;
        int selectedIndex = -1;

        public ViewKategori(IKategoriApi kategoriApi, MasterDataCacheService cache)
        {
            InitializeComponent();
            _kategoriApi = kategoriApi;
            _cache = cache;

            ApplyLanguage();

            dgvKategori.CellClick += dgvKategori_CellClick;
            this.Load += ViewKategori_Load;
        }

        private async void ViewKategori_Load(object sender, EventArgs e)
        {
            await TampilkanData();
        }

        public void ApplyLanguage()
        {
            btnTambahKategori.Text = LocalizationService.GetString("btn_tambah");
            btnSetText.Text = LocalizationService.GetString("btn_refresh");
            label1.Text = LocalizationService.GetString("lbl_nama_kategori");
            label2.Text = LocalizationService.GetString("lbl_nama_kategori");


            if (dgvKategori.Columns.Contains("Edit"))
            {
                dgvKategori.Columns["Edit"].HeaderText = LocalizationService.GetString("btn_edit");
            }
            if (dgvKategori.Columns.Contains("Hapus"))
            {
                dgvKategori.Columns["Hapus"].HeaderText = LocalizationService.GetString("btn_hapus");
            }
        }

        private void TambahKolomButton()
        {
            if (!dgvKategori.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
                btnEdit.Name = "Edit";
                btnEdit.HeaderText = LocalizationService.GetString("btn_edit");
                btnEdit.Text = LocalizationService.GetString("btn_edit");
                btnEdit.UseColumnTextForButtonValue = true;

                dgvKategori.Columns.Add(btnEdit);
            }

            if (!dgvKategori.Columns.Contains("Hapus"))
            {
                DataGridViewButtonColumn btnHapus = new DataGridViewButtonColumn();
                btnHapus.Name = "Hapus";
                btnHapus.HeaderText = LocalizationService.GetString("btn_hapus");
                btnHapus.Text = LocalizationService.GetString("btn_hapus");
                btnHapus.UseColumnTextForButtonValue = true;

                dgvKategori.Columns.Add(btnHapus);
            }
        }


        private async void btnTambahKategori_Click(object sender, EventArgs e)
        {
            try
            {
                var request = new TugasBesar.Core.DTO.Request.KategoriRequestDTO { Nama = tbNamaKategori.Text };
                await _kategoriApi.Tambah(request);
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
                var request = new TugasBesar.Core.DTO.Request.KategoriRequestDTO { Nama = tbNamaKategori.Text };
                await _kategoriApi.Edit(id, request);
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
                await TampilkanData();
                tbNamaKategori.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnSetText_Click(object sender, EventArgs e)
        {
            await TampilkanData();
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

            dgvKategori.Columns.Clear();

            dgvKategori.DataSource = null;

            var list = _cache.DaftarKategori;

            if (list == null || list.Count == 0)
            {
                dgvKategori.DataSource = null;
                return;
            }

            dgvKategori.DataSource = list;

            TambahKolomButton();

            if (dgvKategori.Columns.Contains("Edit"))
                dgvKategori.Columns["Edit"].DisplayIndex = dgvKategori.Columns.Count - 2;

            if (dgvKategori.Columns.Contains("Hapus"))
                dgvKategori.Columns["Hapus"].DisplayIndex = dgvKategori.Columns.Count - 1;

            selectedIndex = -1;

            if (dgvKategori.Columns.Contains("Nama"))
            {
                dgvKategori.Columns["Nama"].DisplayIndex = 0;
            }

            // 2. Paksa tombol Edit (Ubah) berada di sebelah kanannya Nama
            if (dgvKategori.Columns.Contains("Edit"))
            {
                dgvKategori.Columns["Edit"].DisplayIndex = 1;
            }

            // 3. Paksa tombol Hapus berada di urutan paling akhir (paling kanan)
            if (dgvKategori.Columns.Contains("Hapus"))
            {
                dgvKategori.Columns["Hapus"].DisplayIndex = 2;
            }
        }

        private async void dgvKategori_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (e.RowIndex >= _cache.DaftarKategori.Count) return;

            var data = _cache.DaftarKategori[e.RowIndex];

            // Map response DTO back to Model for the edit form
            var modelData = new KategoriModels { id = data.id, nama = data.nama };

            if (dgvKategori.Columns[e.ColumnIndex].Name == "Edit")
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
            else if (dgvKategori.Columns[e.ColumnIndex].Name == "Hapus")
            {
                var confirm = MessageBox.Show(
                    LocalizationService.GetString("msg_hapus_kategori_konfirmasi"),
                    LocalizationService.GetString("title_konfirmasi"),
                    MessageBoxButtons.YesNo
                );

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        await _kategoriApi.Hapus(data.id);
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