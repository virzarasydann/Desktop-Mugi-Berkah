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

namespace TugasBesar.App.Views.Admin.Status
{
    public partial class ViewStatus : UserControl
    {
        private const string KolomId = "IdStatus";
        private const string KolomNama = "NamaStatus";
        private const string KolomEdit = "Edit";
        private const string KolomHapus = "Hapus";

        private readonly IStatusApi _statusApi;
        private readonly MasterDataCacheService _cache;

        public ViewStatus(MasterDataCacheService cache, IStatusApi statusApi)
        {
            _statusApi = statusApi;
            _cache = cache;
            InitializeComponent();

            DgvStatus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DgvStatus.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DgvStatus.AllowUserToAddRows = false;
            DgvStatus.ReadOnly = true;
            DgvStatus.AutoGenerateColumns = false;

            BuatKolomTetap();

            this.Load += ViewStatus_Load;
        }

        private async void ViewStatus_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async void TbNamaStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private async Task LoadData()
        {
            try
            {
                if (_cache.IsLoaded && _cache.DaftarStatus.Any())
                {
                    BindDataToGrid(_cache.DaftarStatus);
                    return;
                }

                var response = await _statusApi.GetAll();
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content;
                    if (data != null)
                    {
                        _cache.DaftarStatus = data.ToList();
                        _cache.IsLoaded = true;
                        BindDataToGrid(data);
                    }
                }
                else
                {
                    MessageBox.Show("Gagal memuat data status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Membuat kolom grid sekali di awal (IdStatus, Nama Status, Aksi, Hapus)
        /// agar header tetap terlihat meskipun data status masih kosong.
        /// </summary>
        private void BuatKolomTetap()
        {
            DgvStatus.Columns.Clear();

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn
            {
                Name = KolomId,
                DataPropertyName = KolomId,
                Visible = false
            };
            DgvStatus.Columns.Add(idColumn);

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn
            {
                Name = KolomNama,
                DataPropertyName = KolomNama,
                HeaderText = "Nama Status"
            };
            DgvStatus.Columns.Add(nameColumn);

            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn
            {
                Name = KolomEdit,
                HeaderText = "Aksi",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            };
            DgvStatus.Columns.Add(editButton);

            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn
            {
                Name = KolomHapus,
                HeaderText = "Hapus",
                Text = "Hapus",
                UseColumnTextForButtonValue = true
            };
            DgvStatus.Columns.Add(deleteButton);

            SesuaikanUkuranGrid();
        }

        /// <summary>
        /// Mengisi grid dari data status. Kolom tidak lagi dibuat ulang di sini
        /// (sudah dibuat sekali oleh BuatKolomTetap), sehingga header tetap tampil
        /// walau data kosong, dan ukuran grid disesuaikan ulang.
        /// </summary>
        private void BindDataToGrid(IEnumerable<StatusResponseDTO> data)
        {
            var list = data?.ToList() ?? new List<StatusResponseDTO>();

            DgvStatus.DataSource = list;

            if (list.Count > 0)
                DgvStatus.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            SesuaikanUkuranGrid();
        }

        /// <summary>
        /// Mengubah ukuran kontrol DataGridView itu sendiri (bukan hanya kolom di dalamnya)
        /// agar mengikuti total lebar kolom dan tinggi baris yang sebenarnya, tanpa
        /// menyisakan area kosong di kanan/bawah grid.
        /// </summary>
        private void SesuaikanUkuranGrid()
        {
            int lebarTotal = DgvStatus.RowHeadersWidth;
            foreach (DataGridViewColumn kolom in DgvStatus.Columns)
            {
                if (kolom.Visible)
                    lebarTotal += kolom.Width;
            }

            int tinggiTotal = DgvStatus.ColumnHeadersHeight;
            foreach (DataGridViewRow baris in DgvStatus.Rows)
            {
                if (baris.Visible)
                    tinggiTotal += baris.Height;
            }

            DgvStatus.Width = lebarTotal + 2;
            DgvStatus.Height = tinggiTotal + 2;
        }

        private async void BtnTambahStatus_Click(object sender, EventArgs e)
        {
            string namaStatus = TbNamaStatus.Text.Trim();
            if (string.IsNullOrEmpty(namaStatus))
            {
                MessageBox.Show("Nama status tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var request = new StatusRequestDTO { NamaStatus = namaStatus };
                await _statusApi.Tambah(request);

                MessageBox.Show("Status berhasil ditambahkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TbNamaStatus.Clear();

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

        private async void DgvStatus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var grid = sender as DataGridView;
            string columnName = grid.Columns[e.ColumnIndex].Name;

            if (columnName != KolomEdit && columnName != KolomHapus)
                return;

            var row = grid.Rows[e.RowIndex];
            var id = (int)row.Cells[KolomId].Value;
            var namaStatus = row.Cells[KolomNama].Value?.ToString() ?? string.Empty;

            if (columnName == KolomEdit)
            {
                var editForm = new FormEditStatus(id, namaStatus, _statusApi);
                var result = editForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    _cache.IsLoaded = false;
                    await LoadData();
                }
            }
            else if (columnName == KolomHapus)
            {
                var confirm = MessageBox.Show($"Apakah Anda yakin ingin menghapus status '{namaStatus}'?",
                                               "Konfirmasi Hapus",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        await _statusApi.Hapus(id);
                        MessageBox.Show("Status berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private class FormEditStatus : Form
        {
            private int _id;
            private string _currentName;
            private readonly IStatusApi _api;
            private TextBox txtNama;
            private Button btnSave;
            private Button btnCancel;

            public FormEditStatus(int id, string currentName, IStatusApi api)
            {
                _id = id;
                _currentName = currentName;
                _api = api;
                InitializeComponents();
                txtNama.Text = currentName;
            }

            private void InitializeComponents()
            {
                this.Text = "Edit Status";
                this.Size = new System.Drawing.Size(300, 150);
                this.StartPosition = FormStartPosition.CenterParent;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                this.MinimizeBox = false;

                Label lbl = new Label { Text = "Nama Status:", Left = 20, Top = 20, Width = 100 };
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
                    MessageBox.Show("Nama status tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    var request = new StatusRequestDTO { NamaStatus = newName };
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