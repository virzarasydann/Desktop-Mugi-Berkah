namespace TugasBesar.App.Views.Pegawai
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            buttonTransaksi = new Button();
            buttonProduk = new Button();
            buttonKategori = new Button();
            buttonOperasional = new Button();
            cmbLanguageUtama = new ComboBox();
            panelContent = new Panel();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(buttonTransaksi);
            flowLayoutPanel1.Controls.Add(buttonProduk);
            flowLayoutPanel1.Controls.Add(buttonKategori);
            flowLayoutPanel1.Controls.Add(buttonOperasional);
            flowLayoutPanel1.Controls.Add(cmbLanguageUtama);
            flowLayoutPanel1.Location = new Point(90, 15);
            flowLayoutPanel1.Margin = new Padding(4, 4, 4, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(782, 80);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // buttonTransaksi
            // 
            buttonTransaksi.Location = new Point(4, 4);
            buttonTransaksi.Margin = new Padding(4, 4, 4, 4);
            buttonTransaksi.Name = "buttonTransaksi";
            buttonTransaksi.Size = new Size(152, 29);
            buttonTransaksi.TabIndex = 3;
            buttonTransaksi.Text = "Menu Transaksi";
            buttonTransaksi.UseVisualStyleBackColor = true;
            buttonTransaksi.Click += buttonTransaksi_Click;
            // 
            // buttonProduk
            // 
            buttonProduk.Location = new Point(164, 4);
            buttonProduk.Margin = new Padding(4, 4, 4, 4);
            buttonProduk.Name = "buttonProduk";
            buttonProduk.Size = new Size(132, 29);
            buttonProduk.TabIndex = 0;
            buttonProduk.Text = "Menu Produk";
            buttonProduk.UseVisualStyleBackColor = true;
            buttonProduk.Click += button1_Click;
            // 
            // buttonKategori
            // 
            buttonKategori.Location = new Point(304, 4);
            buttonKategori.Margin = new Padding(4, 4, 4, 4);
            buttonKategori.Name = "buttonKategori";
            buttonKategori.Size = new Size(119, 29);
            buttonKategori.TabIndex = 1;
            buttonKategori.Text = "Menu Kategori";
            buttonKategori.UseVisualStyleBackColor = true;
            buttonKategori.Click += buttonKategori_Click;
            // 
            // buttonOperasional
            // 
            buttonOperasional.Location = new Point(431, 4);
            buttonOperasional.Margin = new Padding(4, 4, 4, 4);
            buttonOperasional.Name = "buttonOperasional";
            buttonOperasional.Size = new Size(152, 29);
            buttonOperasional.TabIndex = 2;
            buttonOperasional.Text = "Menu Operasional";
            buttonOperasional.UseVisualStyleBackColor = true;
            buttonOperasional.Click += buttonOperasional_Click;
            // 
            // cmbLanguageUtama
            // 
            cmbLanguageUtama.FormattingEnabled = true;
            cmbLanguageUtama.Items.AddRange(new object[] { "Indonesia", "English" });
            cmbLanguageUtama.Location = new Point(591, 4);
            cmbLanguageUtama.Margin = new Padding(4, 4, 4, 4);
            cmbLanguageUtama.Name = "cmbLanguageUtama";
            cmbLanguageUtama.Size = new Size(150, 28);
            cmbLanguageUtama.TabIndex = 2;
            cmbLanguageUtama.Text = "Pilih Bahasa";
            cmbLanguageUtama.SelectedIndexChanged += cmbLanguageUtama_SelectedIndexChanged;
            // 
            // panelContent
            // 
            panelContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelContent.Location = new Point(0, 102);
            panelContent.Margin = new Padding(4, 4, 4, 4);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1000, 458);
            panelContent.TabIndex = 1;
            panelContent.Paint += panelContent_Paint;
            // 
            // BaseFormPegawai
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1000, 562);
            Controls.Add(panelContent);
            Controls.Add(flowLayoutPanel1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "BaseFormPegawai";
            Text = "NavbarForm";
            WindowState = FormWindowState.Maximized;
            Load += BaseFormPegawai_Load;
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);

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