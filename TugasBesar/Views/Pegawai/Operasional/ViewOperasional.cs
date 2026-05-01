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

namespace TugasBesar.Views.Pegawai.Operasional
{
    public partial class ViewOperasional : UserControl
    {
        DataGeneric<OperasionalModels> dataOperasional = DataManager.Operasional;
        int selectedIndex = -1;

        public ViewOperasional()
        {
            InitializeComponent();

            dgvOperasional.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOperasional.CellClick += dgvOperasional_CellClick;
            dgvOperasional.AllowUserToAddRows = false;

            ApplyLanguage();
            TampilkanData();
        }

        public void ApplyLanguage()
        {
            label2.Text = LocalizationService.GetString("lbl_nama_operasional");
            label3.Text = LocalizationService.GetString("lbl_biaya_operasional");

            btnTambahOperasional.Text = LocalizationService.GetString("btn_tambah");
            btnSetText.Text = LocalizationService.GetString("btn_refresh");

            if (dgvOperasional.Columns.Contains("Edit"))
                dgvOperasional.Columns["Edit"].HeaderText = LocalizationService.GetString("btn_edit");

            if (dgvOperasional.Columns.Contains("Hapus"))
                dgvOperasional.Columns["Hapus"].HeaderText = LocalizationService.GetString("btn_hapus");
        }

        private void TambahKolomButton()
        {
            if (!dgvOperasional.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
                btnEdit.Name = "Edit";
                btnEdit.HeaderText = LocalizationService.GetString("btn_edit");
                btnEdit.Text = LocalizationService.GetString("btn_edit");
                btnEdit.UseColumnTextForButtonValue = true;

                dgvOperasional.Columns.Add(btnEdit);
            }

            if (!dgvOperasional.Columns.Contains("Hapus"))
            {
                DataGridViewButtonColumn btnHapus = new DataGridViewButtonColumn();
                btnHapus.Name = "Hapus";
                btnHapus.HeaderText = LocalizationService.GetString("btn_hapus");
                btnHapus.Text = LocalizationService.GetString("btn_hapus");
                btnHapus.UseColumnTextForButtonValue = true;

                dgvOperasional.Columns.Add(btnHapus);
            }
        }

        private void TampilkanData()
        {
            dgvOperasional.DataSource = null;

            var list = dataOperasional.GetAll();

            if (list.Count == 0)
            {
                dgvOperasional.Columns.Clear();
                return;
            }

            dgvOperasional.AutoGenerateColumns = true;

            dgvOperasional.DataSource = list;
            TambahKolomButton();

            if (dgvOperasional.Columns.Contains("Nama"))
                dgvOperasional.Columns["Nama"].DisplayIndex = 0;

            if (dgvOperasional.Columns.Contains("Harga"))
                dgvOperasional.Columns["Harga"].DisplayIndex = 1;

            if (dgvOperasional.Columns.Contains("Edit"))
                dgvOperasional.Columns["Edit"].DisplayIndex = 2;

            if (dgvOperasional.Columns.Contains("Hapus"))
                dgvOperasional.Columns["Hapus"].DisplayIndex = 3;
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void btnTambahOperasional_Click(object sender, EventArgs e) 
        {
            if (string.IsNullOrEmpty(tbNamaOperasional.Text) ||
                string.IsNullOrEmpty(tbHargaOperasional.Text))
            {
                MessageBox.Show("Semua field harus diisi!");
                return;
            }

            if (!int.TryParse(tbHargaOperasional.Text, out int harga))
            {
                MessageBox.Show("Harga harus angka!");
                return;
            }

            dataOperasional.Add(new OperasionalModels()
            {
                Nama = tbNamaOperasional.Text,
                Harga = harga
            });

            TampilkanData();
            ClearInput();
        }

        private void btnEditOperasional_Click(object sender, EventArgs e) 
        {
            if (selectedIndex < 0 || selectedIndex >= dataOperasional.GetAll().Count)
            {
                MessageBox.Show("Pilih data dulu!");
                return;
            }

            if (!int.TryParse(tbHargaOperasional.Text, out int harga))
            {
                MessageBox.Show("Harga harus angka!");
                return;
            }

            OperasionalModels data = new OperasionalModels()
            {
                Nama = tbNamaOperasional.Text,
                Harga = harga
            };

            dataOperasional.Update(selectedIndex, data);

            TampilkanData();
            ClearInput();
        }


        private void label2_Click(object sender, EventArgs e) { }

        private void tbNamaOperasional_TextChanged(object sender, EventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }

        private void tbHargaOperasional_TextChanged(object sender, EventArgs e) { }

        private void label5_Click(object sender, EventArgs e) { }

        private void label4_Click(object sender, EventArgs e) { }

        private void label6_Click(object sender, EventArgs e) { }

        private void btnSetText_Click(object sender, EventArgs e) 
        {
            TampilkanData();
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void dgvOperasional_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvOperasional_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (e.RowIndex >= dataOperasional.GetAll().Count) return;

            selectedIndex = e.RowIndex;

            var data = dataOperasional.GetAll()[e.RowIndex];

            if (dgvOperasional.Columns[e.ColumnIndex].Name == "Edit")
            {
                FormEditOperasional form = new FormEditOperasional(data);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    TampilkanData();
                }
            }
            else if (dgvOperasional.Columns[e.ColumnIndex].Name == "Hapus")
            {
                var confirm = MessageBox.Show(
                    LocalizationService.GetString("Anda yakin ingin menghapus ?"),
                    LocalizationService.GetString("title_konfirmasi"),
                    MessageBoxButtons.YesNo
                );

                if (confirm == DialogResult.Yes)
                {
                    dataOperasional.RemoveAt(e.RowIndex);
                    TampilkanData();
                }
            }
        }

        private void ClearInput()
        {
            tbNamaOperasional.Text = "";
            tbHargaOperasional.Text = "";
            selectedIndex = -1;
        }

    }
}