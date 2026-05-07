using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasBesar.Controllers;
using TugasBesar.Models;

namespace TugasBesar.Views.Pegawai.Operasional
{
    public partial class FormEditOperasional : Form
    {
        OperasionalController controller = new OperasionalController();
        public OperasionalModels operasional { get; set; }

        int index;

        public FormEditOperasional(OperasionalModels data, int selectedIndex)
        {
            InitializeComponent();

            operasional = data;
            this.index = selectedIndex; 

            tbNama.Text = data.Nama;
            tbHarga.Text = data.Harga.ToString();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                controller.Edit(index, tbNama.Text, tbHarga.Text);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
