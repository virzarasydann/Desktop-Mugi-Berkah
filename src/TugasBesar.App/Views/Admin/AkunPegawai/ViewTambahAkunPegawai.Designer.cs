namespace TugasBesar.App.Views.Admin.AkunPegawai
{
    partial class ViewTambahAkunPegawai
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            tbPassword = new TextBox();
            tbUsername = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btnTambahAkunPegawai = new Button();
            panel2 = new Panel();
            dgvAkunPegawai = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAkunPegawai).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(tbPassword);
            panel1.Controls.Add(tbUsername);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnTambahAkunPegawai);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(470, 692);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(71, 304);
            tbPassword.Margin = new Padding(2);
            tbPassword.Multiline = true;
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(200, 36);
            tbPassword.TabIndex = 4;
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(71, 206);
            tbUsername.Margin = new Padding(2);
            tbUsername.Multiline = true;
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(200, 36);
            tbUsername.TabIndex = 3;
            tbUsername.TextChanged += tbUsername_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(68, 286);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(77, 17);
            label2.TabIndex = 2;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(68, 187);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(81, 17);
            label1.TabIndex = 1;
            label1.Text = "Username";
            // 
            // btnTambahAkunPegawai
            // 
            btnTambahAkunPegawai.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTambahAkunPegawai.Location = new Point(171, 431);
            btnTambahAkunPegawai.Margin = new Padding(2);
            btnTambahAkunPegawai.Name = "btnTambahAkunPegawai";
            btnTambahAkunPegawai.Size = new Size(153, 46);
            btnTambahAkunPegawai.TabIndex = 0;
            btnTambahAkunPegawai.Text = "Tambah Akun Pegawai";
            btnTambahAkunPegawai.UseVisualStyleBackColor = true;
            btnTambahAkunPegawai.Click += btnTambahAkunPegawai_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvAkunPegawai);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(468, 0);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(655, 692);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // dgvAkunPegawai
            // 
            dgvAkunPegawai.AccessibleName = "dgvAkunPegawai";
            dgvAkunPegawai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAkunPegawai.Location = new Point(0, 286);
            dgvAkunPegawai.Name = "dgvAkunPegawai";
            dgvAkunPegawai.Size = new Size(652, 244);
            dgvAkunPegawai.TabIndex = 4;
            // 
            // ViewTambahAkunPegawai
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "ViewTambahAkunPegawai";
            Size = new Size(1123, 692);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAkunPegawai).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTambahAkunPegawai;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvAkunPegawai;
    }
}
