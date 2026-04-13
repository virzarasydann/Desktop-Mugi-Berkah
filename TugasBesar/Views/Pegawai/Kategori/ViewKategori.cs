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

            dgvKategori.CellClick += dgvKategori_CellClick;
            TampilkanData();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void tbNamaKategori_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void btnTambahKategori_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbNamaKategori.Text))
            {
                MessageBox.Show("Nama kategori tidak boleh kosong!");
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
                MessageBox.Show("Pilih data dulu!");
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
                MessageBox.Show("Pilih data dulu!");
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

        private void TampilkanData()
        {
            dgvKategori.DataSource = null;
            dgvKategori.DataSource = dataKategori.GetAll();
        }


        private void dgvKategori_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvKategori_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedIndex = e.RowIndex;

                var data = dataKategori.GetAll()[selectedIndex];
                tbNamaKategori.Text = data.Nama;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
