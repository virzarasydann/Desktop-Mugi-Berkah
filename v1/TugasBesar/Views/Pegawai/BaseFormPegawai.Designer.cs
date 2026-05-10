namespace TugasBesar.Views.Pegawai
{
    partial class BaseFormPegawai
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonTransaksi = new System.Windows.Forms.Button();
            this.buttonProduk = new System.Windows.Forms.Button();
            this.buttonKategori = new System.Windows.Forms.Button();
            this.buttonOperasional = new System.Windows.Forms.Button();
            this.cmbLanguageUtama = new System.Windows.Forms.ComboBox();
            this.panelContent = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonTransaksi);
            this.flowLayoutPanel1.Controls.Add(this.buttonProduk);
            this.flowLayoutPanel1.Controls.Add(this.buttonKategori);
            this.flowLayoutPanel1.Controls.Add(this.buttonOperasional);
            this.flowLayoutPanel1.Controls.Add(this.cmbLanguageUtama);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(72, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(626, 64);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // buttonTransaksi
            // 
            this.buttonTransaksi.Location = new System.Drawing.Point(3, 3);
            this.buttonTransaksi.Name = "buttonTransaksi";
            this.buttonTransaksi.Size = new System.Drawing.Size(122, 23);
            this.buttonTransaksi.TabIndex = 3;
            this.buttonTransaksi.Text = "Menu Transaksi";
            this.buttonTransaksi.UseVisualStyleBackColor = true;
            this.buttonTransaksi.Click += new System.EventHandler(this.buttonTransaksi_Click);
            // 
            // buttonProduk
            // 
            this.buttonProduk.Location = new System.Drawing.Point(131, 3);
            this.buttonProduk.Name = "buttonProduk";
            this.buttonProduk.Size = new System.Drawing.Size(106, 23);
            this.buttonProduk.TabIndex = 0;
            this.buttonProduk.Text = "Menu Produk";
            this.buttonProduk.UseVisualStyleBackColor = true;
            this.buttonProduk.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonKategori
            // 
            this.buttonKategori.Location = new System.Drawing.Point(243, 3);
            this.buttonKategori.Name = "buttonKategori";
            this.buttonKategori.Size = new System.Drawing.Size(95, 23);
            this.buttonKategori.TabIndex = 1;
            this.buttonKategori.Text = "Menu Kategori";
            this.buttonKategori.UseVisualStyleBackColor = true;
            this.buttonKategori.Click += new System.EventHandler(this.buttonKategori_Click);
            // 
            // buttonOperasional
            // 
            this.buttonOperasional.Location = new System.Drawing.Point(344, 3);
            this.buttonOperasional.Name = "buttonOperasional";
            this.buttonOperasional.Size = new System.Drawing.Size(122, 23);
            this.buttonOperasional.TabIndex = 2;
            this.buttonOperasional.Text = "Menu Operasional";
            this.buttonOperasional.UseVisualStyleBackColor = true;
            this.buttonOperasional.Click += new System.EventHandler(this.buttonOperasional_Click);
            // 
            // cmbLanguageUtama
            // 
            this.cmbLanguageUtama.FormattingEnabled = true;
            this.cmbLanguageUtama.Items.AddRange(new object[] {
            "Indonesia",
            "English"});
            this.cmbLanguageUtama.Location = new System.Drawing.Point(472, 3);
            this.cmbLanguageUtama.Name = "cmbLanguageUtama";
            this.cmbLanguageUtama.Size = new System.Drawing.Size(121, 21);
            this.cmbLanguageUtama.TabIndex = 2;
            this.cmbLanguageUtama.SelectedIndexChanged += new System.EventHandler(this.cmbLanguageUtama_SelectedIndexChanged);
            // 
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.Location = new System.Drawing.Point(0, 82);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(800, 366);
            this.panelContent.TabIndex = 1;
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint);
            // 
            // BaseFormPegawai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "BaseFormPegawai";
            this.Text = "NavbarForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BaseFormPegawai_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonProduk;
        private System.Windows.Forms.Button buttonKategori;
        private System.Windows.Forms.Button buttonOperasional;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button buttonTransaksi;
        private System.Windows.Forms.ComboBox cmbLanguageUtama;
    }
}