using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasBesar.Localization;
//using TugasBesar.App.Views.Admin.AkunPegawai;
using TugasBesar.App.Views.Pegawai;
using Microsoft.Extensions.DependencyInjection;

namespace TugasBesar.App.Views
{
    public partial class LoginForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        
        public LoginForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

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


        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBoxUsername.Text;
            String password = textBoxPassword.Text;

            var formPegawai = _serviceProvider.GetRequiredService<BaseFormPegawai>();
            formPegawai.FormClosed += (s, args) => this.Close();

            this.Hide();
            formPegawai.Show();
        }


    }
}