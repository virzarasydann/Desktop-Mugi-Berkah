using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasBesar.Localization;
using TugasBesar.Core.Controllers.Interfaces;
using TugasBesar.Core.Models;
using TugasBesar.Core.Services;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;
using System.Diagnostics;

namespace TugasBesar.App.Views.Admin.AkunPegawai
{
    public partial class ViewTambahAkunPegawai : UserControl
    {
        private const string KolomId = "Id";
        private const string KolomName = "Name";
        private const string KolomRole = "Role";
        private const string KolomEdit = "Edit";
        private const string KolomHapus = "Hapus";

        private readonly IAkunPegawaiApi _akunPegawaiApi;
        private readonly MasterDataCacheService _cache;

        public ViewTambahAkunPegawai(IAkunPegawaiApi akunPegawaiApi, MasterDataCacheService cache)
        {
            InitializeComponent();
            _akunPegawaiApi = akunPegawaiApi;
            _cache = cache;

            dgvAkunPegawai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvAkunPegawai.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvAkunPegawai.CellClick += dgvAkunPegawai_CellClick;

            ApplyLanguage();
            BuatKolomTetap();

            this.Load += ViewTambahAkunPegawai_Load;
        }

        private async void ViewTambahAkunPegawai_Load(object? sender, EventArgs e)
        {
            await TampilkanData();
        }

        public void ApplyLanguage()
        {
            btnTambahAkunPegawai.Text = LocalizationService.GetString("btn_tambah_akun");

            label1.Text = LocalizationService.GetString("lbl_username");
            label2.Text = LocalizationService.GetString("lbl_password");

            if (dgvAkunPegawai.Columns.Contains(KolomEdit))
                dgvAkunPegawai.Columns[KolomEdit].HeaderText = "Aksi";

            if (dgvAkunPegawai.Columns.Contains(KolomHapus))
                dgvAkunPegawai.Columns[KolomHapus].HeaderText = LocalizationService.GetString("btn_hapus");
        }

        private void BuatKolomTetap()
        {
            dgvAkunPegawai.AutoGenerateColumns = false;
            dgvAkunPegawai.Columns.Clear();

            dgvAkunPegawai.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = KolomId,
                DataPropertyName = KolomId,
                HeaderText = "id",
                Visible = false
            });

            dgvAkunPegawai.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = KolomName,
                DataPropertyName = KolomName,
                HeaderText = "Username"
            });

            dgvAkunPegawai.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = KolomRole,
                DataPropertyName = KolomRole,
                HeaderText = "Role"
            });

            dgvAkunPegawai.Columns.Add(new DataGridViewButtonColumn
            {
                Name = KolomEdit,
                HeaderText = "Aksi",
                Text = LocalizationService.GetString("btn_edit"),
                UseColumnTextForButtonValue = true
            });

            dgvAkunPegawai.Columns.Add(new DataGridViewButtonColumn
            {
                Name = KolomHapus,
                HeaderText = LocalizationService.GetString("btn_hapus"),
                Text = LocalizationService.GetString("btn_hapus"),
                UseColumnTextForButtonValue = true
            });

            SesuaikanUkuranGrid();
        }

        private void SesuaikanUkuranGrid()
        {
            int lebarTotal = dgvAkunPegawai.RowHeadersWidth;
            foreach (DataGridViewColumn kolom in dgvAkunPegawai.Columns)
            {
                if (kolom.Visible)
                    lebarTotal += kolom.Width;
            }

            int tinggiTotal = dgvAkunPegawai.ColumnHeadersHeight;
            foreach (DataGridViewRow baris in dgvAkunPegawai.Rows)
            {
                if (baris.Visible)
                    tinggiTotal += baris.Height;
            }

            dgvAkunPegawai.Width = lebarTotal + 2;
            dgvAkunPegawai.Height = tinggiTotal + 2;
        }

        private async Task TampilkanData()
        {
            Debug.Assert(dgvAkunPegawai != null, "DbC Invariant Gagal: Tabel DataGridView hilang dari layar!");

            if (dgvAkunPegawai == null) return;

            try
            {
                var listAkun = await _akunPegawaiApi.GetAllAkun();

                dgvAkunPegawai.DataSource = listAkun ?? new List<AkunResponseDTO>();

                if (listAkun != null && listAkun.Count > 0)
                    dgvAkunPegawai.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                SesuaikanUkuranGrid();
            }
            catch (Exception ex)
            {
                TampilkanPesanError($"Gagal memuat data akun pegawai: {ex.Message}");
            }
        }

        private async void btnTambahAkunPegawai_Click(object? sender, EventArgs e)
        {
            Debug.Assert(_akunPegawaiApi != null, "DbC Pre-condition Gagal: API Client belum diinisialisasi!");
            Debug.Assert(tbUsername != null && tbPassword != null, "DbC Pre-condition Gagal: TextBox UI tidak terdeteksi!");

            string inputUsername = tbUsername.Text;
            string inputPassword = tbPassword.Text;

            if (string.IsNullOrWhiteSpace(inputUsername) || string.IsNullOrWhiteSpace(inputPassword))
            {
                TampilkanPesanPeringatan("Username dan Password wajib diisi!");
                return;
            }

            try
            {
                var request = new AkunRequestDTO
                {
                    name = inputUsername,
                    password = inputPassword
                };

                await _akunPegawaiApi.TambahAkun(request);

                tbUsername.Clear();
                tbPassword.Clear();
                await TampilkanData();
                TampilkanPesanSukses("Akun berhasil ditambahkan!");

                Debug.Assert(string.IsNullOrEmpty(tbUsername.Text) && string.IsNullOrEmpty(tbPassword.Text), "DbC Post-condition Gagal: Form gagal dikosongkan setelah sukses!");
            }
            catch (Refit.ApiException apiEx)
            {
                string errMsg = "Penyebab tidak diketahui.";
                try
                {
                    var content = apiEx.Content;
                    if (!string.IsNullOrWhiteSpace(content))
                    {
                        using (var doc = System.Text.Json.JsonDocument.Parse(content))
                        {
                            if (doc.RootElement.TryGetProperty("message", out var messageProp))
                            {
                                errMsg = messageProp.GetString() ?? errMsg;
                            }
                        }
                    }
                }
                catch { }
                TampilkanPesanPeringatan($"Gagal menambahkan akun: {errMsg}");
            }
            catch (Exception ex)
            {
                TampilkanPesanPeringatan($"Gagal menambahkan akun: {ex.Message}");
            }
        }

        private async void dgvAkunPegawai_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var listAkun = dgvAkunPegawai.DataSource as List<AkunResponseDTO>;
            if (listAkun == null || e.RowIndex >= listAkun.Count) return;

            var dataTerpilih = listAkun[e.RowIndex];

            if (dgvAkunPegawai.Columns[e.ColumnIndex].Name == KolomEdit)
            {
                var modelForEdit = new AkunPegawaiModels
                {
                    id = dataTerpilih.Id,
                    nama = dataTerpilih.Name
                };
                FormEditAkunPegawai formEdit = new FormEditAkunPegawai(modelForEdit);

                if (formEdit.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var request = new AkunRequestDTO
                        {
                            name = formEdit.AkunEdit.nama,
                            password = formEdit.AkunEdit.password
                        };

                        await _akunPegawaiApi.UpdateAkun(formEdit.AkunEdit.id, request);

                        await TampilkanData();
                        TampilkanPesanSukses("Akun berhasil diubah!");
                    }
                    catch (Exception ex)
                    {
                        TampilkanPesanError($"Gagal mengubah akun: {ex.Message}");
                    }
                }
            }
            else if (dgvAkunPegawai.Columns[e.ColumnIndex].Name == KolomHapus)
            {
                var confirm = MessageBox.Show(
                    LocalizationService.GetString("msg_konfirmasi_hapus_akun"),
                    LocalizationService.GetString("title_konfirmasi"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        await _akunPegawaiApi.HapusAkun(dataTerpilih.Id);

                        await TampilkanData();
                        TampilkanPesanSukses("Akun berhasil dihapus!");
                    }
                    catch (Exception ex)
                    {
                        TampilkanPesanError($"Gagal menghapus akun: {ex.Message}");
                    }
                }
            }
        }

        #region Helper Dialog Pesan UI

        private void TampilkanPesanSukses(string pesan)
        {
            MessageBox.Show(pesan, LocalizationService.GetString("title_sukses"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TampilkanPesanPeringatan(string pesan)
        {
            MessageBox.Show(pesan, LocalizationService.GetString("title_peringatan"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void TampilkanPesanError(string pesan)
        {
            MessageBox.Show(pesan, LocalizationService.GetString("title_gagal"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        private void panel2_Paint(object? sender, PaintEventArgs e) { }
        private void tbUsername_TextChanged(object? sender, EventArgs e) { }
        private void panel1_Paint(object? sender, PaintEventArgs e) { }
    }
}