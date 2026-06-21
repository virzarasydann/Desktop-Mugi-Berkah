namespace TugasBesar.App.Views.Pegawai.Produk
{
    partial class ViewProduk
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
            label1 = new Label();
            panel1 = new Panel();
            dgvProduk = new DataGridView();
            tbHargaProduk = new TextBox();
            cmbKategoriProduk = new ComboBox();
            tbNamaProduk = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            btnTambahProduk = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProduk).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(46, 92);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 4;
            label1.Text = "Produk";
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1404, 865);
            panel1.TabIndex = 5;
            // 
            // dgvProduk
            // 
            dgvProduk.AllowUserToAddRows = false;
            dgvProduk.AllowUserToDeleteRows = false;
            dgvProduk.AllowUserToOrderColumns = true;
            dgvProduk.BorderStyle = BorderStyle.Fixed3D;
            dgvProduk.ColumnHeadersHeight = 29;
            dgvProduk.Location = new Point(66, 277);
            dgvProduk.Margin = new Padding(2);
            dgvProduk.Name = "dgvProduk";
            dgvProduk.ReadOnly = true;
            dgvProduk.RowHeadersWidth = 51;
            dgvProduk.RowTemplate.Height = 24;
            dgvProduk.Size = new Size(714, 338);
            dgvProduk.TabIndex = 10;
            // 
            // tbHargaProduk
            // 
            tbHargaProduk.Location = new Point(32, 289);
            tbHargaProduk.Margin = new Padding(2);
            tbHargaProduk.Multiline = true;
            tbHargaProduk.Name = "tbHargaProduk";
            tbHargaProduk.Size = new Size(264, 45);
            tbHargaProduk.TabIndex = 8;
            // 
            // cmbKategoriProduk
            // 
            cmbKategoriProduk.FormattingEnabled = true;
            cmbKategoriProduk.ItemHeight = 20;
            cmbKategoriProduk.Location = new Point(32, 206);
            cmbKategoriProduk.Margin = new Padding(2);
            cmbKategoriProduk.Name = "cmbKategoriProduk";
            cmbKategoriProduk.Size = new Size(153, 28);
            cmbKategoriProduk.TabIndex = 7;
            // 
            // tbNamaProduk
            // 
            tbNamaProduk.Location = new Point(32, 90);
            tbNamaProduk.Margin = new Padding(2);
            tbNamaProduk.Multiline = true;
            tbNamaProduk.Name = "tbNamaProduk";
            tbNamaProduk.Size = new Size(264, 43);
            tbNamaProduk.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(32, 258);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(124, 20);
            label4.TabIndex = 5;
            label4.Text = "Harga Produk";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(32, 169);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(143, 20);
            label3.TabIndex = 4;
            label3.Text = "Kategori Produk";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(35, 55);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(121, 20);
            label2.TabIndex = 3;
            label2.Text = "Nama Produk";
            // 
            // btnTambahProduk
            // 
            btnTambahProduk.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTambahProduk.Location = new Point(125, 411);
            btnTambahProduk.Margin = new Padding(2);
            btnTambahProduk.Name = "btnTambahProduk";
            btnTambahProduk.Size = new Size(151, 38);
            btnTambahProduk.TabIndex = 0;
            btnTambahProduk.Text = "Tambah Produk";
            btnTambahProduk.UseVisualStyleBackColor = true;
            btnTambahProduk.Click += btnTambahProduk_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvProduk);
            panel2.Location = new Point(578, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(826, 862);
            panel2.TabIndex = 11;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.GradientActiveCaption;
            panel3.Controls.Add(btnTambahProduk);
            panel3.Controls.Add(tbHargaProduk);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(tbNamaProduk);
            panel3.Controls.Add(cmbKategoriProduk);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(117, 193);
            panel3.Name = "panel3";
            panel3.Size = new Size(418, 484);
            panel3.TabIndex = 12;
            // 
            // ViewProduk
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(panel1);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "ViewProduk";
            Size = new Size(1404, 865);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProduk).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTambahProduk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNamaProduk;
        private System.Windows.Forms.TextBox tbHargaProduk;
        private System.Windows.Forms.ComboBox cmbKategoriProduk;
        private System.Windows.Forms.DataGridView dgvProduk;
        private Panel panel3;
        private Panel panel2;
    }
}
