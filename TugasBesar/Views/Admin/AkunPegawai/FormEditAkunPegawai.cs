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

namespace TugasBesar.Views.Admin.AkunPegawai
{
    public partial class FormEditAkunPegawai : Form
    {
        public Models.AkunPegawai AkunEdit { get; set; }

        public FormEditAkunPegawai(Models.AkunPegawai data = null)
        {
            InitializeComponent();

            tbPasswordEdit.UseSystemPasswordChar = true;

            // Menyambungkan tombol simpan secara manual melalui kode
            btnSimpan.Click += btnSimpan_Click;

            if (data != null)
            {
                AkunEdit = new Models.AkunPegawai
                {
                    Id = data.Id,
                    Username = data.Username,
                    Password = data.Password,
                    Role = data.Role,
                    NamaLengkap = data.NamaLengkap
                };

                tbUsernameEdit.Text = data.Username;
                tbPasswordEdit.Text = data.Password;


            }
            else
            {
                AkunEdit = new Models.AkunPegawai();
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbUsernameEdit.Text) || string.IsNullOrWhiteSpace(tbPasswordEdit.Text))
            {
                MessageBox.Show("Username dan Password tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AkunEdit.Username = tbUsernameEdit.Text;
            AkunEdit.Password = tbPasswordEdit.Text;
            AkunEdit.NamaLengkap = tbUsernameEdit.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormEditAkunPegawai_Load(object sender, EventArgs e) { }
    }
}