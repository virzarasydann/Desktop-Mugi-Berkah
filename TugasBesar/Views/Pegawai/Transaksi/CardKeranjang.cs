using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TugasBesar.Views.Pegawai.Transaksi
{
    public partial class CardKeranjang : UserControl
    {
        public CardKeranjang()
        {
            InitializeComponent();
        }

        private void CardKeranjang_Load(object sender, EventArgs e)
        {

        }

      
        public int HargaSatuan { get; set; }

        
        private int _jumlah = 0;
        public int Jumlah
        {
            get { return _jumlah; }
            set
            {
                _jumlah = value;

                
                labelJumlah.Text = _jumlah.ToString() + "x";

                
                int subtotal = HargaSatuan * _jumlah;
                labelHarga.Text = "Rp " + subtotal.ToString("N0");
            }
        }

        public string NamaProduk
        {
            get { return labelNamaProduk.Text; }
            set { labelNamaProduk.Text = value; }
        }

        
        public int Harga
        {
            get
            {

                return int.Parse(labelHarga.Text.Replace("Rp ", "").Replace(".", ""));
            }
            set
            {

                labelHarga.Text = "Rp " + value.ToString("N0");
            }
        }

        private void labelHarga_Click(object sender, EventArgs e)
        {

        }

        private void labelJumlah_Click(object sender, EventArgs e)
        {

        }
    }
}
