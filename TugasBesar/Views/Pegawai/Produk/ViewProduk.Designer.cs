namespace TugasBesar.Views.Pegawai.Produk
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
            this.btnSetTex = new System.Windows.Forms.Button();
            this.tbHargaProduk = new System.Windows.Forms.TextBox();
            this.cmbKategoriProduk = new System.Windows.Forms.ComboBox();
            this.tbNamaProduk = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnHapusProduk = new System.Windows.Forms.Button();
            this.btnEditProduk = new System.Windows.Forms.Button();
            this.btnTambahProduk = new System.Windows.Forms.Button();
            this.dgvProduk = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduk)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
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
            this.panel1.Controls.Add(this.btnHapusProduk);
            this.panel1.Controls.Add(this.btnEditProduk);
            this.panel1.Controls.Add(this.btnTambahProduk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1404, 865);
            this.panel1.TabIndex = 5;
            // 
            // btnSetTex
            // 
            this.btnSetTex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetTex.Location = new System.Drawing.Point(1005, 346);
            this.btnSetTex.Name = "btnSetTex";
            this.btnSetTex.Size = new System.Drawing.Size(116, 33);
            this.btnSetTex.TabIndex = 9;
            this.btnSetTex.Text = "Set Tex";
            this.btnSetTex.UseVisualStyleBackColor = true;
            this.btnSetTex.Click += new System.EventHandler(this.btnSetTex_Click);
            // 
            // tbHargaProduk
            // 
            this.tbHargaProduk.Location = new System.Drawing.Point(68, 284);
            this.tbHargaProduk.Multiline = true;
            this.tbHargaProduk.Name = "tbHargaProduk";
            this.tbHargaProduk.Size = new System.Drawing.Size(264, 45);
            this.tbHargaProduk.TabIndex = 8;
            this.tbHargaProduk.TextChanged += new System.EventHandler(this.tbHargaProduk_TextChanged);
            // 
            // cmbKategoriProduk
            // 
            this.cmbKategoriProduk.FormattingEnabled = true;
            this.cmbKategoriProduk.ItemHeight = 16;
            this.cmbKategoriProduk.Location = new System.Drawing.Point(68, 209);
            this.cmbKategoriProduk.Name = "cmbKategoriProduk";
            this.cmbKategoriProduk.Size = new System.Drawing.Size(153, 24);
            this.cmbKategoriProduk.TabIndex = 7;
            this.cmbKategoriProduk.SelectedIndexChanged += new System.EventHandler(this.cmbKategoriProduk_SelectedIndexChanged);
            // 
            // tbNamaProduk
            // 
            this.tbNamaProduk.Location = new System.Drawing.Point(68, 119);
            this.tbNamaProduk.Multiline = true;
            this.tbNamaProduk.Name = "tbNamaProduk";
            this.tbNamaProduk.Size = new System.Drawing.Size(264, 43);
            this.tbNamaProduk.TabIndex = 6;
            this.tbNamaProduk.TextChanged += new System.EventHandler(this.tbNamaProduk_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(64, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Harga Produk";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(64, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kategori Produk";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nama Produk";
            // 
            // btnHapusProduk
            // 
            this.btnHapusProduk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapusProduk.Location = new System.Drawing.Point(905, 28);
            this.btnHapusProduk.Name = "btnHapusProduk";
            this.btnHapusProduk.Size = new System.Drawing.Size(164, 38);
            this.btnHapusProduk.TabIndex = 2;
            this.btnHapusProduk.Text = "Hapus Produk";
            this.btnHapusProduk.UseVisualStyleBackColor = true;
            this.btnHapusProduk.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnEditProduk
            // 
            this.btnEditProduk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditProduk.Location = new System.Drawing.Point(767, 28);
            this.btnEditProduk.Name = "btnEditProduk";
            this.btnEditProduk.Size = new System.Drawing.Size(116, 38);
            this.btnEditProduk.TabIndex = 1;
            this.btnEditProduk.Text = "Edit Produk";
            this.btnEditProduk.UseVisualStyleBackColor = true;
            this.btnEditProduk.Click += new System.EventHandler(this.btnEditProduk_Click);
            // 
            // btnTambahProduk
            // 
            this.btnTambahProduk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambahProduk.Location = new System.Drawing.Point(593, 28);
            this.btnTambahProduk.Name = "btnTambahProduk";
            this.btnTambahProduk.Size = new System.Drawing.Size(151, 38);
            this.btnTambahProduk.TabIndex = 0;
            this.btnTambahProduk.Text = "Tambah Produk";
            this.btnTambahProduk.UseVisualStyleBackColor = true;
            this.btnTambahProduk.Click += new System.EventHandler(this.btnTambahProduk_Click);
            // 
            // dgvProduk
            // 
            this.dgvProduk.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvProduk.ColumnHeadersHeight = 29;
            this.dgvProduk.Location = new System.Drawing.Point(373, 391);
            this.dgvProduk.Name = "dgvProduk";
            this.dgvProduk.RowHeadersWidth = 51;
            this.dgvProduk.RowTemplate.Height = 24;
            this.dgvProduk.Size = new System.Drawing.Size(811, 337);
            this.dgvProduk.TabIndex = 10;
            this.dgvProduk.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduk_CellContentClick);
            // 
            // ViewProduk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "ViewProduk";
            this.Size = new System.Drawing.Size(1404, 865);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHapusProduk;
        private System.Windows.Forms.Button btnEditProduk;
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
