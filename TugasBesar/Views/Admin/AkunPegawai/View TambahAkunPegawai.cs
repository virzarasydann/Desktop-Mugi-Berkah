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

namespace TugasBesar.Views.Admin.AkunPegawai
{
    public partial class ViewTambahAkunPegawai : UserControl
    {
        private AkunPegawaiService _akunService;

        public ViewTambahAkunPegawai()
        {
            InitializeComponent();
            _akunService = new AkunPegawaiService();

            // Menyambungkan event klik pada tabel
            dgvAkunPegawai.CellClick += dgvAkunPegawai_CellClick;

            TampilkanData();
        }

        private void TampilkanData()
        {
            if (dgvAkunPegawai == null) return;

            dgvAkunPegawai.DataSource = null;
            var listAkun = _akunService.AmbilSemuaAkun();

            if (listAkun.Count == 0) return;

            dgvAkunPegawai.DataSource = listAkun;

            // Menyembunyikan kolom yang tidak perlu ditampilkan
            if (dgvAkunPegawai.Columns.Contains("NamaLengkap"))
            {
                dgvAkunPegawai.Columns["NamaLengkap"].Visible = false;
            }

            // --- TAMBAHAN BARU: Sembunyikan kolom Password ---
            if (dgvAkunPegawai.Columns.Contains("Password"))
            {
                dgvAkunPegawai.Columns["Password"].Visible = false;
            }


            TambahKolomButton();

            // Mengatur posisi tombol Edit dan Hapus di paling kanan
            if (dgvAkunPegawai.Columns.Contains("Edit"))
                dgvAkunPegawai.Columns["Edit"].DisplayIndex = dgvAkunPegawai.Columns.Count - 2;

            if (dgvAkunPegawai.Columns.Contains("Hapus"))
                dgvAkunPegawai.Columns["Hapus"].DisplayIndex = dgvAkunPegawai.Columns.Count - 1;
        }

        private void TambahKolomButton()
        {
            if (!dgvAkunPegawai.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
                btnEdit.Name = "Edit";
                btnEdit.HeaderText = "Edit";
                btnEdit.Text = "Edit";
                btnEdit.UseColumnTextForButtonValue = true;
                dgvAkunPegawai.Columns.Add(btnEdit);
            }

            if (!dgvAkunPegawai.Columns.Contains("Hapus"))
            {
                DataGridViewButtonColumn btnHapus = new DataGridViewButtonColumn();
                btnHapus.Name = "Hapus";
                btnHapus.HeaderText = "Hapus";
                btnHapus.Text = "Hapus";
                btnHapus.UseColumnTextForButtonValue = true;
                dgvAkunPegawai.Columns.Add(btnHapus);
            }
        }

        private void btnTambahAkunPegawai_Click(object sender, EventArgs e)
        {
            string inputUsername = tbUsername.Text;
            string inputPassword = tbPassword.Text;

            if (string.IsNullOrWhiteSpace(inputUsername) || string.IsNullOrWhiteSpace(inputPassword))
            {
                MessageBox.Show("Username dan Password wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Models.AkunPegawai akunBaru = new Models.AkunPegawai
            {
                Username = inputUsername,
                Password = inputPassword,
                Role = "Pegawai",
                NamaLengkap = inputUsername
            };

            _akunService.TambahAkun(akunBaru);

            tbUsername.Clear();
            tbPassword.Clear();
            TampilkanData();

            MessageBox.Show("Akun berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvAkunPegawai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var listAkun = _akunService.AmbilSemuaAkun();
            if (e.RowIndex >= listAkun.Count) return;

            var dataTerpilih = listAkun[e.RowIndex];

            // Logika Tombol Edit dalam Tabel
            if (dgvAkunPegawai.Columns[e.ColumnIndex].Name == "Edit")
            {
                FormEditAkunPegawai formEdit = new FormEditAkunPegawai(dataTerpilih);

                if (formEdit.ShowDialog() == DialogResult.OK)
                {
                    _akunService.UpdateAkun(formEdit.AkunEdit);
                    TampilkanData();
                }
            }
            // Logika Tombol Hapus dalam Tabel
            else if (dgvAkunPegawai.Columns[e.ColumnIndex].Name == "Hapus")
            {
                var confirm = MessageBox.Show(
                    "Apakah kamu yakin ingin menghapus akun ini?",
                    "Konfirmasi Hapus",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    _akunService.HapusAkun(dataTerpilih.Id);
                    TampilkanData();
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void tbUsername_TextChanged(object sender, EventArgs e) { }
    }
}