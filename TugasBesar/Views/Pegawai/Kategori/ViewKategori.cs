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
using TugasBesar.Services; // Pastikan ini ada
using KategoriModel = TugasBesar.Models.KategoriModels;

namespace TugasBesar.Views.Pegawai.Kategori
{
    public partial class ViewKategori : UserControl
    {
        DataGeneric<KategoriModels> dataKategori = DataManager.Kategori;
        int selectedIndex = -1;

        public ViewKategori()
        {
            InitializeComponent();

            ApplyLanguage();

            dgvKategori.CellClick += dgvKategori_CellClick;
            TampilkanData();
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

        private void button2_Click(object sender, EventArgs e) { }

        private void tbNamaKategori_TextChanged(object sender, EventArgs e) { }

        private void btnTambahKategori_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbNamaKategori.Text))
            {
                MessageBox.Show(LocalizationService.GetString("msg_nama_kategori_kosong"));
                return;
            }

            KategoriModel kategori = new KategoriModel()
            {
                Nama = tbNamaKategori.Text
            };

            dataKategori.Add(kategori);

            TampilkanData();
            tbNamaKategori.Text = "";
        }

        private void btnEditKategori_Click(object sender, EventArgs e)
        {
            if (selectedIndex < 0)
            {
                MessageBox.Show(LocalizationService.GetString("msg_pilih_data"));
                return;
            }

            KategoriModel kategori = new KategoriModel()
            {
                Nama = tbNamaKategori.Text
            };

            dataKategori.Update(selectedIndex, kategori);
            TampilkanData();
            tbNamaKategori.Text = "";
        }

        private void btnHapusKategori_Click(object sender, EventArgs e)
        {
            if (selectedIndex < 0)
            {
                MessageBox.Show(LocalizationService.GetString("msg_pilih_data"));
                return;
            }

            dataKategori.RemoveAt(selectedIndex);

            TampilkanData();
            tbNamaKategori.Text = "";
        }

        private void btnSetText_Click(object sender, EventArgs e)
        {
            TampilkanData();
        }

        private void dgvKategori_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void TampilkanData()
        {
            dgvKategori.DataSource = null;

            var list = dataKategori.GetAll();

            if (list.Count == 0)
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
        }

        private void dgvKategori_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (e.RowIndex >= dataKategori.GetAll().Count) return;

            var data = dataKategori.GetAll()[e.RowIndex];

            if (dgvKategori.Columns[e.ColumnIndex].Name == "Edit")
            {
                FormEditKategori form = new FormEditKategori(data);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    dataKategori.Update(e.RowIndex, form.kategori);
                    TampilkanData();
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
                    dataKategori.RemoveAt(e.RowIndex);
                    TampilkanData();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void label2_Click(object sender, EventArgs e)
        {
        }
    }
}