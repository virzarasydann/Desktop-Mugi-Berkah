namespace TugasBesar.App.Views.Pegawai.Transaksi
{
    partial class CardProduk
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
            lblHarga = new Label();
            lblNama = new Label();
            SuspendLayout();
            // 
            // lblHarga
            // 
            lblHarga.AutoSize = true;
            lblHarga.Location = new Point(41, 79);
            lblHarga.Margin = new Padding(4, 0, 4, 0);
            lblHarga.Name = "lblHarga";
            lblHarga.Size = new Size(39, 15);
            lblHarga.TabIndex = 0;
            lblHarga.Text = "Harga";
            // 
            // lblNama
            // 
            lblNama.AutoSize = true;
            lblNama.Location = new Point(41, 26);
            lblNama.Margin = new Padding(4, 0, 4, 0);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(39, 15);
            lblNama.TabIndex = 1;
            lblNama.Text = "Nama";
            // 
            // CardProduk
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(lblNama);
            Controls.Add(lblHarga);
            Margin = new Padding(4, 3, 4, 3);
            Name = "CardProduk";
            Size = new Size(181, 142);
            Load += CardProduk_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHarga;
        private System.Windows.Forms.Label lblNama;
    }
}
