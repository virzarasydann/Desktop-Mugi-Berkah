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
using TugasBesar.Core.Controllers;  // Tambahkan ini agar bisa memanggil Controller

namespace TugasBesar.App.Views.Admin.AkunPegawai
{
    public partial class ViewTambahAkunPegawai : UserControl
    {
        // GANTI Service menjadi Controller
        private AkunPegawaiController _controller;

        public ViewTambahAkunPegawai()
        {
            InitializeComponent();

            // Inisialisasi Controller
            _controller = new AkunPegawaiController();

            dgvAkunPegawai.CellClick += dgvAkunPegawai_CellClick;
            TampilkanData();
        }

        private void TampilkanData()
        {
            if (dgvAkunPegawai == null) return;

            dgvAkunPegawai.Columns.Clear();
            dgvAkunPegawai.DataSource = null;

            // Panggil data lewat Controller, BUKAN Service lagi
            var listAkun = _controller.GetAllAkun();

            if (listAkun.Count == 0) return;

            dgvAkunPegawai.DataSource = listAkun;

            if (dgvAkunPegawai.Columns.Contains("NamaLengkap"))
                dgvAkunPegawai.Columns["NamaLengkap"].Visible = false;

            if (dgvAkunPegawai.Columns.Contains("Password"))
                dgvAkunPegawai.Columns["Password"].Visible = false;

            TambahKolomButton();

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
                btnEdit.HeaderText = "Aksi";
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

            // Logika if-else kosong dihapus dari sini, karena Controller yang akan ngecek
            // Kita tinggal panggil fungsi TambahAkun di Controller
            string pesan;
            bool sukses = _controller.TambahAkun(inputUsername, inputPassword, out pesan);

            if (sukses)
            {
                tbUsername.Clear();
                tbPassword.Clear();
                TampilkanData();
                MessageBox.Show(pesan, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(pesan, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvAkunPegawai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var listAkun = _controller.GetAllAkun();
            if (e.RowIndex >= listAkun.Count) return;

            var dataTerpilih = listAkun[e.RowIndex];

            // EDIT AKUN
            if (dgvAkunPegawai.Columns[e.ColumnIndex].Name == "Edit")
            {
                FormEditAkunPegawai formEdit = new FormEditAkunPegawai(dataTerpilih);

                if (formEdit.ShowDialog() == DialogResult.OK)
                {
                    // Panggil Controller untuk Update
                    string pesan;
                    bool sukses = _controller.UpdateAkun(
                        formEdit.AkunEdit.Id,
                        formEdit.AkunEdit.Username,
                        formEdit.AkunEdit.Password,
                        out pesan
                    );

                    if (sukses)
                    {
                        TampilkanData();
                        MessageBox.Show(pesan, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(pesan, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            // HAPUS AKUN
            else if (dgvAkunPegawai.Columns[e.ColumnIndex].Name == "Hapus")
            {
                var confirm = MessageBox.Show("Apakah kamu yakin ingin menghapus akun ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    // Panggil Controller untuk Hapus
                    string pesan;
                    bool sukses = _controller.HapusAkun(dataTerpilih.Id, out pesan);

                    if (sukses)
                    {
                        TampilkanData();
                        MessageBox.Show(pesan, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(pesan, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void tbUsername_TextChanged(object sender, EventArgs e) { }
    }
}