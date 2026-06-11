using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasBesar.Core.Controllers;
using TugasBesar.Core.Controllers.Interfaces;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Models;
using TugasBesar.Core.Services;
using TugasBesar.Localization;



namespace TugasBesar.App.Views.Pegawai.Operasional
{

    public partial class ViewOperasional : UserControl
    {
        Dictionary<string, Action<int>> aksiKolom;
        int selectedIndex = -1;
        private List<OperasionalResponseDTO> daftarOperasional = new();

        private readonly IOperasionalApi _OperasionalApi;
        private readonly MasterDataCacheService _cache;

        public ViewOperasional(IOperasionalApi OperasionalApi, MasterDataCacheService cache)
        {
            InitializeComponent();
            _OperasionalApi = OperasionalApi;
            _cache = cache;
            dgvOperasional.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOperasional.CellClick += dgvOperasional_CellClick;
            dgvOperasional.AllowUserToAddRows = false;

            ApplyLanguage();
            TampilkanData();

            aksiKolom = new Dictionary<string, Action<int>>()
            {
                {
                    "Edit", (rowid) =>
            {
                var data = daftarOperasional[rowid];

                    FormEditOperasional form = new FormEditOperasional(data, _OperasionalApi);

                    if (form.ShowDialog() == DialogResult.OK)
                {
            _       = TampilkanData();
                    }
                }
            },
                {
                    "Hapus", async (rowIndex) =>
                {
                    var confirm = MessageBox.Show(
                        "Anda yakin ingin menghapus ?",
                        "Konfirmasi",
                    MessageBoxButtons.YesNo
                );

                if (confirm == DialogResult.Yes)
            {
                await _OperasionalApi.Hapus(
                    daftarOperasional[rowIndex].id);

                await TampilkanData();
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

        private async Task TampilkanData()
        {
            dgvOperasional.DataSource = null;

            daftarOperasional = (await _OperasionalApi.GetAll()).ToList();

            if (daftarOperasional.Count == 0)
            {
                dgvOperasional.Columns.Clear();
                return;
            }

            dgvOperasional.AutoGenerateColumns = true;

            dgvOperasional.DataSource = daftarOperasional;

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

        private async void btnTambahOperasional_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(tbHargaOperasional.Text, out int harga))
                {
                    MessageBox.Show("Harga harus berupa angka.");
                    return;
                }

                var request = new OperasionalRequestDTO
                {
                    Nama = tbNamaOperasional.Text,
                    Harga = harga
                };

                await _OperasionalApi.Tambah(request);

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
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                if (e.RowIndex >= daftarOperasional.Count)
                    return;

                selectedIndex = e.RowIndex;

                var columnName = dgvOperasional.Columns[e.ColumnIndex].Name;

                if (aksiKolom.ContainsKey(columnName))
                {
                    aksiKolom[columnName].Invoke(e.RowIndex);
                }
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