using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TugasBesar.App.Views.Pegawai.Transaksi
{
    public partial class CardProduk : UserControl
    {
        public event EventHandler ProdukDiklik;
        public CardProduk()
        {
            InitializeComponent();
            this.Click += TriggerKlik;
            lblNama.Click += TriggerKlik;
            lblHarga.Click += TriggerKlik;
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NamaProduk
        {
            get { return lblNama.Text; } 
            set { lblNama.Text = value; }
        }

        private void TriggerKlik(object sender, EventArgs e)
        {
            
            ProdukDiklik?.Invoke(this, e);
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Harga
        {
            get
            {

                return int.Parse(lblHarga.Text.Replace("Rp ", "").Replace(".", "").Replace(",", ""));
            }
            set
            {
              
                lblHarga.Text = "Rp " + value.ToString("N0");
            }
        }

        private void CardProduk_Load(object sender, EventArgs e)
        {

        }
    }
}
