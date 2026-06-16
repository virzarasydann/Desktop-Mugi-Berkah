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
using TugasBesar.Controllers;


namespace TugasBesar.Views.Pegawai.Operasional
{

    public partial class ViewOperasional : UserControl
    {
        Dictionary<string, Action<int>> aksiKolom;
        DataGeneric<OperasionalModels> dataOperasional = DataManager.Operasional;
        int selectedIndex = -1;
        OperasionalController controller = new OperasionalController();

        public ViewOperasional()
        {
            InitializeComponent();

            dgvOperasional.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOperasional.CellClick += dgvOperasional_CellClick;
            dgvOperasional.AllowUserToAddRows = false;

            ApplyLanguage();
            TampilkanData();

            aksiKolom = new Dictionary<string, Action<int>>()
            {
                {
                    "Edit", (rowIndex) =>
                    {
                        var data = dataOperasional.GetAll()[rowIndex];
                        FormEditOperasional form = new FormEditOperasional(data, rowIndex);

                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            TampilkanData();
                        }
                    }
                },
                {
                    "Hapus", (rowIndex) =>
                    {
                        var confirm = MessageBox.Show(
                            "Anda yakin ingin menghapus ?",
                            "Konfirmasi",
                            MessageBoxButtons.YesNo
                        );

                        if (confirm == DialogResult.Yes)
                        {
                            controller.Hapus(rowIndex);
                            TampilkanData();
                        }
                    }
                }
            };
        }

        public void ApplyLanguage()
        {
            label2.Text = LocalizationService.GetString("lbl_nama_operasional");
            label3.Text = LocalizationService.GetString("lbl_biaya_operasional");

            btnTambahOperasional.Text = LocalizationService.GetString("btn_tambah");
            //btnSetText.Text = LocalizationService.GetString("btn_refresh");

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
            try
            {
                controller.Tambah(tbNamaOperasional.Text, tbHargaOperasional.Text);

                TampilkanData();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void btnEditOperasional_Click(object sender, EventArgs e) 
        //{
        //    try
        //    {
        //        controller.Edit(selectedIndex, tbNamaOperasional.Text, tbHargaOperasional.Text);

        //        TampilkanData();
        //        ClearInput();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}


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
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                if (e.RowIndex >= dataOperasional.GetAll().Count) return;

                selectedIndex = e.RowIndex;

                //var data = dataOperasional.GetAll()[e.RowIndex];

                var columnName = dgvOperasional.Columns[e.ColumnIndex].Name;

                if (aksiKolom.ContainsKey(columnName))
                {
                    aksiKolom[columnName].Invoke(e.RowIndex);
                }

                //if (dgvOperasional.Columns[e.ColumnIndex].Name == "Edit")
                //{
                //    FormEditOperasional form = new FormEditOperasional(data, selectedIndex);

                //    if (form.ShowDialog() == DialogResult.OK)
                //    {
                //        TampilkanData();
                //    }
                //}
                //else if (dgvOperasional.Columns[e.ColumnIndex].Name == "Hapus")
                //{
                //    var confirm = MessageBox.Show(
                //        "Anda yakin ingin menghapus ?",
                //        "Konfirmasi",
                //        MessageBoxButtons.YesNo
                //    );

                //    if (confirm == DialogResult.Yes)
                //    {
                //        controller.Hapus(e.RowIndex);
                //        TampilkanData();
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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