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
        private readonly IProdukApi _produkApi;
        private readonly MasterDataCacheService _cache;
        int selectedIndex = -1;

        public ViewProduk(IProdukApi produkApi, MasterDataCacheService cache)
        {
            InitializeComponent();
            _produkApi = produkApi;
            _cache = cache;

            dgvProduk.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProduk.CellClick += dgvProduk_CellClick;

            ApplyLanguage();

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
                    harga = int.Parse(tbHargaProduk.Text) 
                };
                await _produkApi.Tambah(request);
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
            
            // Map back to old model for FormEditProduk compatibility
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

        private async void btnSetTex_Click(object sender, EventArgs e)
        {
            await TampilkanData();
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

            dgvProduk.DataSource = null;
            dgvProduk.Columns.Clear(); 

            var list = _cache.DaftarProduk;

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


        private async void dgvProduk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (e.RowIndex >= _cache.DaftarProduk.Count) return;

            selectedIndex = e.RowIndex;

            var data = _cache.DaftarProduk[e.RowIndex];
            var modelData = new ProdukModels { id = data.Id, nama = data.Nama, Kategori = new KategoriModels { id = data.KategoriId, nama = data.NamaKategori }, harga = data.Harga };

            if (dgvProduk.Columns[e.ColumnIndex].Name == "Edit")
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
                        await TampilkanData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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
                        await _produkApi.Hapus(data.Id);
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

    }
}