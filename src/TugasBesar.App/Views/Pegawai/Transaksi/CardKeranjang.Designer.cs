namespace TugasBesar.App.Views.Pegawai.Transaksi
{
    partial class CardKeranjang
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
            this.labelNamaProduk = new System.Windows.Forms.Label();
            this.labelHarga = new System.Windows.Forms.Label();
            this.labelJumlah = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelNamaProduk
            // 
            this.labelNamaProduk.AutoSize = true;
            this.labelNamaProduk.Location = new System.Drawing.Point(42, 69);
            this.labelNamaProduk.Name = "labelNamaProduk";
            this.labelNamaProduk.Size = new System.Drawing.Size(35, 13);
            this.labelNamaProduk.TabIndex = 0;
            this.labelNamaProduk.Text = "Nama";
            // 
            // labelHarga
            // 
            this.labelHarga.AutoSize = true;
            this.labelHarga.Location = new System.Drawing.Point(42, 22);
            this.labelHarga.Name = "labelHarga";
            this.labelHarga.Size = new System.Drawing.Size(36, 13);
            this.labelHarga.TabIndex = 1;
            this.labelHarga.Text = "Harga";
            this.labelHarga.Click += new System.EventHandler(this.labelHarga_Click);
            // 
            // labelJumlah
            // 
            this.labelJumlah.AutoSize = true;
            this.labelJumlah.Location = new System.Drawing.Point(42, 109);
            this.labelJumlah.Name = "labelJumlah";
            this.labelJumlah.Size = new System.Drawing.Size(40, 13);
            this.labelJumlah.TabIndex = 2;
            this.labelJumlah.Text = "Jumlah";
            this.labelJumlah.Click += new System.EventHandler(this.labelJumlah_Click);
            // 
            // CardKeranjang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.Controls.Add(this.labelJumlah);
            this.Controls.Add(this.labelHarga);
            this.Controls.Add(this.labelNamaProduk);
            this.Name = "CardKeranjang";
            this.Load += new System.EventHandler(this.CardKeranjang_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNamaProduk;
        private System.Windows.Forms.Label labelHarga;
        private System.Windows.Forms.Label labelJumlah;
    }
}
