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
using TugasBesar.Views.Pegawai.Produk;
using TugasBesar.Views.Pegawai.Kategori;
using TugasBesar.Views.Pegawai.Operasional;
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
            PindahLayar(new ViewProduk());
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

        private void buttonTransaksi_Click(object sender, EventArgs e)
        {
            PindahLayar(new ViewTransaksi());
        }

        private void buttonKategori_Click(object sender, EventArgs e)
        {
            PindahLayar(new ViewKategori());
        }

        private void buttonOperasional_Click(object sender, EventArgs e)
        {
            PindahLayar(new ViewOperasional());
        }
    }
}
