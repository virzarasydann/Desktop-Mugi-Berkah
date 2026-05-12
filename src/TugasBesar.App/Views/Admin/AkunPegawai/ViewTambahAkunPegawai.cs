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
using TugasBesar.Core.Controllers;
using TugasBesar.Core.Models;
using TugasBesar.Core.Services;
using System.Diagnostics; 

namespace TugasBesar.App.Views.Admin.AkunPegawai
{
    public partial class ViewTambahAkunPegawai : UserControl
    {
        private AkunPegawaiController _controller;

        public ViewTambahAkunPegawai()
        {
            InitializeComponent();
            _controller = new AkunPegawaiController();

            ApplyLanguage();

            dgvAkunPegawai.CellClick += dgvAkunPegawai_CellClick;
            TampilkanData();
        }

        public void ApplyLanguage()
        {
            btnTambahAkunPegawai.Text = LocalizationService.GetString("btn_tambah_akun");

            // PERBAIKAN: Memanggil nama Label (label1, label2), bukan TextBox (tbUsername).
            // Jika saat dicopy ada garis merah di kata 'label1', sesuaikan dengan (Name) Label-mu di jendela Properties.
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

        private void TampilkanData()
        {
            //  3. INVARIANT (Syarat Tetap) 
            // Memastikan DataGridView tidak hilang dari layar selama proses
            Debug.Assert(dgvAkunPegawai != null, "DbC Invariant Gagal: Tabel DataGridView hilang dari layar!");

            dgvAkunPegawai.Columns.Clear();
            dgvAkunPegawai.DataSource = null;

            if (dgvAkunPegawai == null) return;

            dgvAkunPegawai.Columns.Clear();
            dgvAkunPegawai.DataSource = null;

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

        private void btnTambahAkunPegawai_Click(object sender, EventArgs e)
        {
            // --- 1. PRE-CONDITION (Syarat Awal) ---
            // Memastikan Controller dan komponen layar (TextBox) tidak bocor/hilang sebelum memproses data
            Debug.Assert(_controller != null, "DbC Pre-condition Gagal: Controller belum diinisialisasi!");
            Debug.Assert(tbUsername != null && tbPassword != null, "DbC Pre-condition Gagal: TextBox UI tidak terdeteksi!");

            string inputUsername = tbUsername.Text;
            string inputPassword = tbPassword.Text;
            string pesan;

            // --- PROSES UTAMA ---
            bool sukses = _controller.TambahAkun(inputUsername, inputPassword, out pesan);

            if (sukses)
            {
                tbUsername.Clear();
                tbPassword.Clear();
                TampilkanData();
                MessageBox.Show(pesan, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // --- 2. POST-CONDITION (Syarat Akhir) ---
                // Memastikan dengan mutlak bahwa kotak input benar-benar sudah kosong setelah data berhasil disimpan
                Debug.Assert(string.IsNullOrEmpty(tbUsername.Text) && string.IsNullOrEmpty(tbPassword.Text), "DbC Post-condition Gagal: Form gagal dikosongkan setelah sukses!");
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

            if (dgvAkunPegawai.Columns[e.ColumnIndex].Name == "Edit")
            {
                FormEditAkunPegawai formEdit = new FormEditAkunPegawai(dataTerpilih);

                if (formEdit.ShowDialog() == DialogResult.OK)
                {
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
                        MessageBox.Show(pesan, LocalizationService.GetString("title_sukses"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(pesan, LocalizationService.GetString("title_gagal"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (dgvAkunPegawai.Columns[e.ColumnIndex].Name == "Hapus")
            {
                var confirm = MessageBox.Show(LocalizationService.GetString("msg_konfirmasi_hapus_akun"), LocalizationService.GetString("title_konfirmasi"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    string pesan;
                    bool sukses = _controller.HapusAkun(dataTerpilih.Id, out pesan);

                    if (sukses)
                    {
                        TampilkanData();
                        MessageBox.Show(pesan, LocalizationService.GetString("title_sukses"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(pesan, LocalizationService.GetString("title_gagal"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void tbUsername_TextChanged(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}