namespace TugasBesar.Views.Pegawai.Produk
{
    partial class FormEditProduk
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNama = new System.Windows.Forms.TextBox();
            this.tbHarga = new System.Windows.Forms.TextBox();
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nama Produk";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kategori Produk";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Harga Produk";
            // 
            // tbNama
            // 
            this.tbNama.Location = new System.Drawing.Point(51, 57);
            this.tbNama.Multiline = true;
            this.tbNama.Name = "tbNama";
            this.tbNama.Size = new System.Drawing.Size(139, 33);
            this.tbNama.TabIndex = 3;
            this.tbNama.TextChanged += new System.EventHandler(this.tbNama_TextChanged);
            // 
            // tbHarga
            // 
            this.tbHarga.Location = new System.Drawing.Point(51, 261);
            this.tbHarga.Multiline = true;
            this.tbHarga.Name = "tbHarga";
            this.tbHarga.Size = new System.Drawing.Size(139, 31);
            this.tbHarga.TabIndex = 4;
            this.tbHarga.TextChanged += new System.EventHandler(this.tbHarga_TextChanged);
            // 
            // cmbKategori
            // 
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Location = new System.Drawing.Point(52, 157);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(121, 24);
            this.cmbKategori.TabIndex = 5;
            this.cmbKategori.SelectedIndexChanged += new System.EventHandler(this.cmbKategori_SelectedIndexChanged);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpan.Location = new System.Drawing.Point(321, 360);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(159, 44);
            this.btnSimpan.TabIndex = 6;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // FormEditProduk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 521);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.cmbKategori);
            this.Controls.Add(this.tbHarga);
            this.Controls.Add(this.tbNama);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormEditProduk";
            this.Text = "FormEditProduk";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNama;
        private System.Windows.Forms.TextBox tbHarga;
        private System.Windows.Forms.ComboBox cmbKategori;
        private System.Windows.Forms.Button btnSimpan;
    }
}