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
        private readonly IAkunPegawaiApi _akunPegawaiApi;
        private readonly MasterDataCacheService _cache;

        public ViewTambahAkunPegawai(IAkunPegawaiApi akunPegawaiApi, MasterDataCacheService cache)
        {
            InitializeComponent();
            _akunPegawaiApi = akunPegawaiApi;
            _cache = cache;

            ApplyLanguage();

            dgvAkunPegawai.CellClick += dgvAkunPegawai_CellClick;
            this.Load += ViewTambahAkunPegawai_Load;
        }

        private async void ViewTambahAkunPegawai_Load(object? sender, EventArgs e)
        {
            await TampilkanData();
        }

        /// <summary>
        /// Menerapkan lokalisasi bahasa untuk kontrol UI.
        /// </summary>
        public void ApplyLanguage()
        {
            btnTambahAkunPegawai.Text = LocalizationService.GetString("btn_tambah_akun");

            label1.Text = LocalizationService.GetString("lbl_username");
            label2.Text = LocalizationService.GetString("lbl_password");

            if (dgvAkunPegawai.Columns.Contains("Edit"))
            {
                dgvAkunPegawai.Columns["Edit"].HeaderText = LocalizationService.GetString("btn_aksi");
                foreach (DataGridViewRow row in dgvAkunPegawai.Rows)
                {
                    row.Cells["Edit"].Value = LocalizationService.GetString("btn_edit");
                }
            }
            if (dgvAkunPegawai.Columns.Contains("Hapus"))
            {
                dgvAkunPegawai.Columns["Hapus"].HeaderText = LocalizationService.GetString("btn_hapus");
                foreach (DataGridViewRow row in dgvAkunPegawai.Rows)
                {
                    row.Cells["Hapus"].Value = LocalizationService.GetString("btn_hapus");
                }
            }
        }

        /// <summary>
        /// Mengambil data pegawai terbaru dari API dan menampilkannya di DataGridView.
        /// </summary>
        private async Task TampilkanData()
        {
            // INVARIANT (Syarat Kelas)
            Debug.Assert(dgvAkunPegawai != null, "DbC Invariant Gagal: Tabel DataGridView hilang dari layar!");

            dgvAkunPegawai.Columns.Clear();
            dgvAkunPegawai.DataSource = null;

            if (dgvAkunPegawai == null) return;

            try
            {
                var listAkun = await _akunPegawaiApi.GetAllAkun();
                if (listAkun == null || listAkun.Count == 0) return;

                dgvAkunPegawai.DataSource = listAkun;

                TambahKolomButton();

                // Menyusun letak tombol aksi agar berada di kolom paling kanan
                if (dgvAkunPegawai.Columns.Contains("Edit"))
                    dgvAkunPegawai.Columns["Edit"].DisplayIndex = dgvAkunPegawai.Columns.Count - 2;

                if (dgvAkunPegawai.Columns.Contains("Hapus"))
                    dgvAkunPegawai.Columns["Hapus"].DisplayIndex = dgvAkunPegawai.Columns.Count - 1;
            }
            catch (Exception ex)
            {
                TampilkanPesanError($"Gagal memuat data akun pegawai: {ex.Message}");
            }
        }

        /// <summary>
        /// Menambahkan tombol Aksi (Edit dan Hapus) secara dinamis ke dalam tabel.
        /// </summary>
        private void TambahKolomButton()
        {
            if (!dgvAkunPegawai.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
                btnEdit.Name = "Edit";
                btnEdit.HeaderText = LocalizationService.GetString("btn_aksi");
                btnEdit.Text = LocalizationService.GetString("btn_edit");
                btnEdit.UseColumnTextForButtonValue = true;
                dgvAkunPegawai.Columns.Add(btnEdit);
            }

            if (!dgvAkunPegawai.Columns.Contains("Hapus"))
            {
                DataGridViewButtonColumn btnHapus = new DataGridViewButtonColumn();
                btnHapus.Name = "Hapus";
                btnHapus.HeaderText = LocalizationService.GetString("btn_hapus");
                btnHapus.Text = LocalizationService.GetString("btn_hapus");
                btnHapus.UseColumnTextForButtonValue = true;
                dgvAkunPegawai.Columns.Add(btnHapus);
            }
        }

        private async void btnTambahAkunPegawai_Click(object? sender, EventArgs e)
        {
            // PRE-CONDITION (Syarat Awal)
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

                // POST-CONDITION (Syarat Akhir)
                Debug.Assert(string.IsNullOrEmpty(tbUsername.Text) && string.IsNullOrEmpty(tbPassword.Text), "DbC Post-condition Gagal: Form gagal dikosongkan setelah sukses!");
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

            if (dgvAkunPegawai.Columns[e.ColumnIndex].Name == "Edit")
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
            else if (dgvAkunPegawai.Columns[e.ColumnIndex].Name == "Hapus")
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