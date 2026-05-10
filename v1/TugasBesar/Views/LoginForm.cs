using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasBesar.Services;
using TugasBesar.Views.Admin.AkunPegawai;
using TugasBesar.Views.Pegawai;

namespace TugasBesar.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            cmbLanguage.Items.Clear();
            cmbLanguage.Items.Add("Indonesia");
            cmbLanguage.Items.Add("English");

            cmbLanguage.SelectedIndex = 0;
        }

        private void ApplyLanguage()
        {
            this.Text = LocalizationService.GetString("login_title");
            button1.Text = LocalizationService.GetString("btn_login");

            
            textBoxUsername.Text = LocalizationService.GetString("placeholder_username");
            textBoxPassword.Text = LocalizationService.GetString("placeholder_password");
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLanguage.SelectedItem.ToString() == "Indonesia")
            {
                LocalizationService.SetLanguage("id");
            }
            else if (cmbLanguage.SelectedItem.ToString() == "English")
            {
                LocalizationService.SetLanguage("en");
            }

            ApplyLanguage();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    String username = textBoxUsername.Text;
        //    String password = textBoxPassword.Text;

        //    BaseFormPegawai formPegawai = new BaseFormPegawai();
        //    formPegawai.FormClosed += (s, args) => this.Close();

        //    this.Hide();
        //    formPegawai.Show();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBoxUsername.Text;
            String password = textBoxPassword.Text;

            BaseFormPegawai formPegawai = new BaseFormPegawai();
            formPegawai.FormClosed += (s, args) => this.Close();

            this.Hide();
            formPegawai.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}