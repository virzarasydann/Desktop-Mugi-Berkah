using System;
using System.ComponentModel;
using System.Windows.Forms;
using TugasBesar.Localization;
using TugasBesar.Core.Models;

namespace TugasBesar.App.Views.Admin.AkunPegawai
{
    public partial class FormEditAkunPegawai : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AkunPegawaiModels AkunEdit { get; set; }

        public FormEditAkunPegawai(AkunPegawaiModels data = null)
        {
            InitializeComponent();

            label2.UseSystemPasswordChar = true;

            btnSimpan.Click += btnSimpan_Click;

            ApplyLanguage();

            if (data != null)
            {
                AkunEdit = new AkunPegawaiModels
                {
                    Id = data.Id,
                    Username = data.Username,
                    Password = data.Password,
                    Role = data.Role,
                    NamaLengkap = data.NamaLengkap
                };

                label1.Text = data.Username;
                label2.Text = data.Password;
            }
            else
            {
                AkunEdit = new AkunPegawaiModels();
            }
        }

        public void ApplyLanguage()
        {
            this.Text = LocalizationService.GetString("title_edit_akun");
            btnSimpan.Text = LocalizationService.GetString("btn_simpan");
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            AkunEdit.Username = label1.Text;
            AkunEdit.Password = label2.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void FormEditAkunPegawai_Load(object sender, EventArgs e) { }
        private void btnSimpan_Click_1(object sender, EventArgs e) { }
        private void tbUsernameEdit_TextChanged(object sender, EventArgs e) { }
        private void tbPasswordEdit_TextChanged(object sender, EventArgs e) { }
        private void tbUsername_TextChanged(object sender, EventArgs e) { }
    }
}