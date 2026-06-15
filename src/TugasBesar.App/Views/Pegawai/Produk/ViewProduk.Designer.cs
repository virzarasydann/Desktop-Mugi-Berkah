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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvProduk = new System.Windows.Forms.DataGridView();
            this.btnSetTex = new System.Windows.Forms.Button();
            this.tbHargaProduk = new System.Windows.Forms.TextBox();
            this.cmbKategoriProduk = new System.Windows.Forms.ComboBox();
            this.tbNamaProduk = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTambahProduk = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduk)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Produk";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvProduk);
            this.panel1.Controls.Add(this.btnSetTex);
            this.panel1.Controls.Add(this.tbHargaProduk);
            this.panel1.Controls.Add(this.cmbKategoriProduk);
            this.panel1.Controls.Add(this.tbNamaProduk);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnTambahProduk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1123, 692);
            this.panel1.TabIndex = 5;
            // 
            // dgvProduk
            // 
            this.dgvProduk.AllowUserToAddRows = false;
            this.dgvProduk.AllowUserToDeleteRows = false;
            this.dgvProduk.AllowUserToOrderColumns = true;
            this.dgvProduk.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvProduk.ColumnHeadersHeight = 29;
            this.dgvProduk.Location = new System.Drawing.Point(298, 313);
            this.dgvProduk.Margin = new System.Windows.Forms.Padding(2);
            this.dgvProduk.Name = "dgvProduk";
            this.dgvProduk.ReadOnly = true;
            this.dgvProduk.RowHeadersWidth = 51;
            this.dgvProduk.RowTemplate.Height = 24;
            this.dgvProduk.Size = new System.Drawing.Size(649, 270);
            this.dgvProduk.TabIndex = 10;
            // 
            // btnSetTex
            // 
            this.btnSetTex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetTex.Location = new System.Drawing.Point(802, 272);
            this.btnSetTex.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetTex.Name = "btnSetTex";
            this.btnSetTex.Size = new System.Drawing.Size(94, 30);
            this.btnSetTex.TabIndex = 9;
            this.btnSetTex.Text = "Set Tex";
            this.btnSetTex.UseVisualStyleBackColor = true;
            this.btnSetTex.Click += new System.EventHandler(this.btnSetTex_Click);
            // 
            // tbHargaProduk
            // 
            this.tbHargaProduk.Location = new System.Drawing.Point(54, 227);
            this.tbHargaProduk.Margin = new System.Windows.Forms.Padding(2);
            this.tbHargaProduk.Multiline = true;
            this.tbHargaProduk.Name = "tbHargaProduk";
            this.tbHargaProduk.Size = new System.Drawing.Size(212, 37);
            this.tbHargaProduk.TabIndex = 8;
            // 
            // cmbKategoriProduk
            // 
            this.cmbKategoriProduk.FormattingEnabled = true;
            this.cmbKategoriProduk.ItemHeight = 13;
            this.cmbKategoriProduk.Location = new System.Drawing.Point(54, 167);
            this.cmbKategoriProduk.Margin = new System.Windows.Forms.Padding(2);
            this.cmbKategoriProduk.Name = "cmbKategoriProduk";
            this.cmbKategoriProduk.Size = new System.Drawing.Size(123, 21);
            this.cmbKategoriProduk.TabIndex = 7;
            // 
            // tbNamaProduk
            // 
            this.tbNamaProduk.Location = new System.Drawing.Point(54, 95);
            this.tbNamaProduk.Margin = new System.Windows.Forms.Padding(2);
            this.tbNamaProduk.Multiline = true;
            this.tbNamaProduk.Name = "tbNamaProduk";
            this.tbNamaProduk.Size = new System.Drawing.Size(212, 35);
            this.tbNamaProduk.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(51, 208);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Harga Produk";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(51, 149);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kategori Produk";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nama Produk";
            // 
            // btnTambahProduk
            // 
            this.btnTambahProduk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambahProduk.Location = new System.Drawing.Point(662, 272);
            this.btnTambahProduk.Margin = new System.Windows.Forms.Padding(2);
            this.btnTambahProduk.Name = "btnTambahProduk";
            this.btnTambahProduk.Size = new System.Drawing.Size(121, 30);
            this.btnTambahProduk.TabIndex = 0;
            this.btnTambahProduk.Text = "Tambah Produk";
            this.btnTambahProduk.UseVisualStyleBackColor = true;
            this.btnTambahProduk.Click += new System.EventHandler(this.btnTambahProduk_Click);
            // 
            // ViewProduk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ViewProduk";
            this.Size = new System.Drawing.Size(1123, 692);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button btnSetTex;
        private System.Windows.Forms.DataGridView dgvProduk;
    }
}
