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
using TugasBesar.Core.Models;
using TugasBesar.Core.Services;
namespace TugasBesar.App.Views.Pegawai.Operasional
{
    public partial class FormEditOperasional : Form
    {

        OperasionalController controller = new OperasionalController();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
