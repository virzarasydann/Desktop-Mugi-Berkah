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

namespace TugasBesar.Views.Pegawai.Operasional
{
    public partial class FormEditOperasional : Form
    {
        public OperasionalModels operasional { get; set; }
        public FormEditOperasional(OperasionalModels data)
        {
            InitializeComponent();

            operasional = data;


            tbNama.Text = data.Nama;
            tbHarga.Text = data.Harga.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbNama.Text))
            {
                MessageBox.Show("Nama tidak boleh kosong!");
                return;
            }

            if (!int.TryParse(tbHarga.Text, out int harga))
            {
                MessageBox.Show("Harga harus angka!");
                return;
            }

            // ❗ penting: pastikan object ada
            if (operasional == null)
            {
                MessageBox.Show("Data tidak ditemukan!");
                return;
            }

            operasional.Nama = tbNama.Text.Trim();
            operasional.Harga = harga;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
