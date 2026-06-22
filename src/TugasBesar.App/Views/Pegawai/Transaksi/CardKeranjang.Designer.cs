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
            labelNamaProduk = new Label();
            labelHarga = new Label();
            labelJumlah = new Label();
            SuspendLayout();
            // 
            // labelNamaProduk
            // 
            labelNamaProduk.AutoSize = true;
            labelNamaProduk.Location = new Point(49, 29);
            labelNamaProduk.Margin = new Padding(4, 0, 4, 0);
            labelNamaProduk.Name = "labelNamaProduk";
            labelNamaProduk.Size = new Size(39, 15);
            labelNamaProduk.TabIndex = 0;
            labelNamaProduk.Text = "Nama";
            // 
            // labelHarga
            // 
            labelHarga.AutoSize = true;
            labelHarga.Location = new Point(49, 77);
            labelHarga.Margin = new Padding(4, 0, 4, 0);
            labelHarga.Name = "labelHarga";
            labelHarga.Size = new Size(39, 15);
            labelHarga.TabIndex = 1;
            labelHarga.Text = "Harga";
            labelHarga.Click += labelHarga_Click;
            // 
            // labelJumlah
            // 
            labelJumlah.AutoSize = true;
            labelJumlah.Location = new Point(49, 126);
            labelJumlah.Margin = new Padding(4, 0, 4, 0);
            labelJumlah.Name = "labelJumlah";
            labelJumlah.Size = new Size(45, 15);
            labelJumlah.TabIndex = 2;
            labelJumlah.Text = "Jumlah";
            labelJumlah.Click += labelJumlah_Click;
            // 
            // CardKeranjang
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Highlight;
            Controls.Add(labelJumlah);
            Controls.Add(labelHarga);
            Controls.Add(labelNamaProduk);
            Margin = new Padding(4, 3, 4, 3);
            Name = "CardKeranjang";
            Size = new Size(175, 173);
            Load += CardKeranjang_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNamaProduk;
        private System.Windows.Forms.Label labelHarga;
        private System.Windows.Forms.Label labelJumlah;
    }
}
