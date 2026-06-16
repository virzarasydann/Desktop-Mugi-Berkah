using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasBesar.Core.Models;
using TugasBesar.Localization;
using TugasBesar.Core.Services;
namespace TugasBesar.App.Views.Pegawai.Produk
{
    public partial class FormEditProduk : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProdukModels produk { get; set; }

        public FormEditProduk(ProdukModels data, IEnumerable<string> categories = null)
        {
            InitializeComponent();
            produk = data;

            ApplyLanguage();

            cmbKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            tbHarga.KeyPress += tbHarga_KeyPress;

            if (categories != null)
            {
                cmbKategori.Items.Clear();
                foreach (var item in categories)
                {
                    cmbKategori.Items.Add(item);
                }
            }
            else
            {
                LoadKategori();
            }

            tbNama.Text = data.nama;
            cmbKategori.Text = data.Kategori?.nama ?? "";
            tbHarga.Text = "Rp " + data.harga.ToString("N0", new System.Globalization.CultureInfo("id-ID"));
        }

        public void ApplyLanguage()
        {
            this.Text = LocalizationService.GetString("title_edit_produk");

            
            label1.Text = LocalizationService.GetString("lbl_nama_produk");
            label2.Text = LocalizationService.GetString("lbl_kategori_produk");
            label3.Text = LocalizationService.GetString("lbl_harga_produk");

            btnSimpan.Text = LocalizationService.GetString("btn_simpan");
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbNama.Text))
            {
                MessageBox.Show(LocalizationService.GetString("msg_nama_kosong"));
                return;
            }

            if (string.IsNullOrEmpty(cmbKategori.Text))
            {
                MessageBox.Show(LocalizationService.GetString("msg_kategori_kosong"));
                return;
            }

            if (!int.TryParse(tbHarga.Text.Replace("Rp ", "").Replace(".", ""), out int harga))
            {
                MessageBox.Show(LocalizationService.GetString("msg_harga_angka") ?? "Harga harus berupa angka!");
                return;
            }

            if (produk == null)
            {
                MessageBox.Show(LocalizationService.GetString("msg_data_tidak_ditemukan"));
                return;
            }

            produk.nama = tbNama.Text.Trim();
            if (produk.Kategori == null) produk.Kategori = new KategoriModels { nama = "" };
            produk.Kategori.nama = cmbKategori.Text.Trim();
            produk.harga = harga;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void LoadKategori()
        {
            cmbKategori.Items.Clear();

            foreach (var item in DataManager.Kategori.GetAll())
            {
                cmbKategori.Items.Add(item.nama);
            }


        }

        private void tbHarga_TextChanged(object sender, EventArgs e) 
        { 
            if (string.IsNullOrEmpty(tbHarga.Text)) return;

            string value = tbHarga.Text.Replace("Rp ", "").Replace(".", "");
            if (decimal.TryParse(value, out decimal hargaValue))
            {
                tbHarga.TextChanged -= tbHarga_TextChanged;
                tbHarga.Text = "Rp " + hargaValue.ToString("N0", new System.Globalization.CultureInfo("id-ID"));
                tbHarga.SelectionStart = tbHarga.Text.Length;
                tbHarga.TextChanged += tbHarga_TextChanged;
            }
        }

        private void tbHarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e) { }
        private void tbNama_TextChanged(object sender, EventArgs e) { }
        private void FormEditProduk_Load(object sender, EventArgs e) { }
    }
}