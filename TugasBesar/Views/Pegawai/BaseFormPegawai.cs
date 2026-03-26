using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasBesar.Views.Pegawai.Transaksi;

namespace TugasBesar.Views.Pegawai
{
    public partial class BaseFormPegawai : Form
    {

        public BaseFormPegawai()
        {
            InitializeComponent();
            PindahLayar(new ViewTransaksi());
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void PindahLayar(UserControl layar)
        {
            panelContent.Controls.Clear();
            layar.Dock = DockStyle.Fill;
            panelContent.Controls.Add(layar);
        }
        private void BaseFormPegawai_Load(object sender, EventArgs e)
        {

        }
    }
}
