using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasBesar.Localization;
using TugasBesar.Core.Models;
using TugasBesar.Core.Services;

namespace TugasBesar.App.Views.Admin.AkunPegawai
{
    public partial class FormEditAkunPegawai : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AkunPegawaiModels AkunEdit { get; set; }

        public FormEditAkunPegawai(AkunPegawaiModels? data = null)
        {
            InitializeComponent();
            label2.UseSystemPasswordChar = true;
            btnSimpan.Click += btnSimpan_Click;

            ApplyLanguage();

            if (data != null)
            {
                AkunEdit = new AkunPegawaiModels
                {
                    id = data.id,
                    nama = data.nama,
                    password = data.password,
                    role = data.role,
                    nama_user = data.nama_user
                };

                label1.Text = data.nama;
                label2.Text = data.password;
            }
            else
            {
                AkunEdit = new AkunPegawaiModels();
            }
        }

        public void ApplyLanguage()
        {
            this.Text = LocalizationService.GetString("title_edit_akun");

            label1.Text = LocalizationService.GetString("lbl_username");
            label2.Text = LocalizationService.GetString("lbl_password");

            btnSimpan.Text = LocalizationService.GetString("btn_simpan");
        }

        private void btnSimpan_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(label1.Text) || string.IsNullOrWhiteSpace(label2.Text))
            {
                MessageBox.Show(LocalizationService.GetString("msg_userpass_kosong"), LocalizationService.GetString("title_peringatan"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AkunEdit.nama = label1.Text;
            AkunEdit.nama_user = label1.Text;
            AkunEdit.password = label2.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormEditAkunPegawai_Load(object? sender, EventArgs e) { }
        private void btnSimpan_Click_1(object? sender, EventArgs e) { }
        private void tbUsernameEdit_TextChanged(object? sender, EventArgs e) { }
        private void tbPasswordEdit_TextChanged(object? sender, EventArgs e) { }
    }
}