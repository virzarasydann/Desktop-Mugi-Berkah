using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasBesar.Views.Pegawai;
namespace TugasBesar.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

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
    }
}
