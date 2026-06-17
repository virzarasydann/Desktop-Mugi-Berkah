using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Refit;
using TugasBesar.Core.Controllers.Interfaces;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.Services;

namespace TugasBesar.App.Views.Admin.MetodePembayaran
{
    public partial class ViewMetodePembayaran : UserControl
    {
        private readonly IMetodePembayaranApi _metodePembayaranApi;
        private readonly MasterDataCacheService _cache;

        public ViewMetodePembayaran(MasterDataCacheService cache, IMetodePembayaranApi metodePembayaranApi)
        {
            _metodePembayaranApi = metodePembayaranApi;
            _cache = cache;
            InitializeComponent();

            this.Load += ViewMetodePembayaran_Load;
        }

        private async void ViewMetodePembayaran_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async void TbNamaMetode_TextChanged(object sender, EventArgs e)
        {

        }

        private async Task LoadData()
        {
            try
            {
                if (_cache.IsLoaded && _cache.DaftarMetodePembayaran.Any())
                {
                    BindDataToGrid(_cache.DaftarMetodePembayaran);
                    return;
                }

                var response = await _metodePembayaranApi.GetAll();
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content;
                    if (data != null)
                    {
                        _cache.DaftarMetodePembayaran = data.ToList();
                        _cache.IsLoaded = true;
                        BindDataToGrid(data);
                    }
                }
                else
                {
                    MessageBox.Show("Gagal memuat data metode pembayaran.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDataToGrid(IEnumerable<MetodePembayaranResponseDTO> data)
        {
            DgvMetodePembayaran.Columns.Clear();
            DgvMetodePembayaran.DataSource = null;

            var list = data.ToList();
            DgvMetodePembayaran.AllowUserToAddRows = false; 
            DgvMetodePembayaran.ReadOnly = true;
            DgvMetodePembayaran.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn
            {
                Name = "IdMetodePembayaran",
                DataPropertyName = "IdMetodePembayaran",
                Visible = false
            };
            DgvMetodePembayaran.Columns.Add(idColumn);

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn
            {
                Name = "NamaMetode",
                DataPropertyName = "NamaMetode",
                HeaderText = "Nama Metode",
                Width = 200
            };
            DgvMetodePembayaran.Columns.Add(nameColumn);

            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                Width = 60
            };
            DgvMetodePembayaran.Columns.Add(editButton);

            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn
            {
                Name = "Hapus",
                HeaderText = "",
                Text = "Hapus",
                UseColumnTextForButtonValue = true,
                Width = 60
            };
            DgvMetodePembayaran.Columns.Add(deleteButton);

            DgvMetodePembayaran.DataSource = list;
        }

        private async void BtnTambahMetode_Click(object sender, EventArgs e)
        {
            string namaMetode = TbNamaMetode.Text.Trim();
            if (string.IsNullOrEmpty(namaMetode))
            {
                MessageBox.Show("Nama metode pembayaran tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var request = new MetodePembayaranRequestDTO { NamaMetode = namaMetode };
                await _metodePembayaranApi.Tambah(request);

                MessageBox.Show("Metode pembayaran berhasil ditambahkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TbNamaMetode.Clear();

                _cache.IsLoaded = false;
                await LoadData();
            }
            catch (ApiException ex)
            {
                MessageBox.Show($"Gagal menambah: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void DgvMetodePembayaran_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var grid = sender as DataGridView;
            string columnName = grid.Columns[e.ColumnIndex].Name;

            if (columnName != "Edit" && columnName != "Hapus")
                return;

            var row = grid.Rows[e.RowIndex];
            var id = (int)row.Cells["IdMetodePembayaran"].Value;
            var namaMetode = row.Cells["NamaMetode"].Value?.ToString() ?? string.Empty;

            if (columnName == "Edit")
            {
                var editForm = new FormEditMetodePembayaran(id, namaMetode, _metodePembayaranApi);
                var result = editForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    _cache.IsLoaded = false;
                    await LoadData();
                }
            }
            else if (columnName == "Hapus")
            {
                var confirm = MessageBox.Show($"Apakah Anda yakin ingin menghapus metode pembayaran '{namaMetode}'?",
                                               "Konfirmasi Hapus",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        await _metodePembayaranApi.Hapus(id);
                        MessageBox.Show("Metode pembayaran berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        _cache.IsLoaded = false;
                        await LoadData();
                    }
                    catch (ApiException ex)
                    {
                        MessageBox.Show($"Gagal menghapus: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private class FormEditMetodePembayaran : Form
        {
            private int _id;
            private string _currentName;
            private readonly IMetodePembayaranApi _api;
            private TextBox txtNama;
            private Button btnSave;
            private Button btnCancel;

            public FormEditMetodePembayaran(int id, string currentName, IMetodePembayaranApi api)
            {
                _id = id;
                _currentName = currentName;
                _api = api;
                InitializeComponents();
                txtNama.Text = currentName;
            }

            private void InitializeComponents()
            {
                this.Text = "Edit Metode Pembayaran";
                this.Size = new System.Drawing.Size(300, 150);
                this.StartPosition = FormStartPosition.CenterParent;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                this.MinimizeBox = false;

                Label lbl = new Label { Text = "Nama Metode:", Left = 20, Top = 20, Width = 100 };
                txtNama = new TextBox { Left = 130, Top = 17, Width = 130 };

                btnSave = new Button { Text = "Simpan", Left = 60, Top = 60, Width = 75 };
                btnCancel = new Button { Text = "Batal", Left = 150, Top = 60, Width = 75 };

                btnSave.Click += BtnSave_Click;
                btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

                this.Controls.Add(lbl);
                this.Controls.Add(txtNama);
                this.Controls.Add(btnSave);
                this.Controls.Add(btnCancel);
            }

            private async void BtnSave_Click(object sender, EventArgs e)
            {
                string newName = txtNama.Text.Trim();
                if (string.IsNullOrEmpty(newName))
                {
                    MessageBox.Show("Nama metode tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    var request = new MetodePembayaranRequestDTO { NamaMetode = newName };
                    await _api.Edit(_id, request);

                    MessageBox.Show("Data berhasil diubah.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (ApiException ex)
                {
                    MessageBox.Show($"Gagal mengubah: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}