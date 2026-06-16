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
            flowLayoutPanel1.Location = new Point(72, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(626, 64);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // buttonTransaksi
            // 
            buttonTransaksi.Location = new Point(3, 3);
            buttonTransaksi.Name = "buttonTransaksi";
            buttonTransaksi.Size = new Size(122, 23);
            buttonTransaksi.TabIndex = 3;
            buttonTransaksi.Text = "Menu Transaksi";
            buttonTransaksi.UseVisualStyleBackColor = true;
            buttonTransaksi.Click += buttonTransaksi_Click;
            // 
            // buttonProduk
            // 
            buttonProduk.Location = new Point(131, 3);
            buttonProduk.Name = "buttonProduk";
            buttonProduk.Size = new Size(106, 23);
            buttonProduk.TabIndex = 0;
            buttonProduk.Text = "Menu Produk";
            buttonProduk.UseVisualStyleBackColor = true;
            buttonProduk.Click += button1_Click;
            // 
            // buttonKategori
            // 
            buttonKategori.Location = new Point(243, 3);
            buttonKategori.Name = "buttonKategori";
            buttonKategori.Size = new Size(95, 23);
            buttonKategori.TabIndex = 1;
            buttonKategori.Text = "Menu Kategori";
            buttonKategori.UseVisualStyleBackColor = true;
            buttonKategori.Click += buttonKategori_Click;
            // 
            // buttonOperasional
            // 
            buttonOperasional.Location = new Point(344, 3);
            buttonOperasional.Name = "buttonOperasional";
            buttonOperasional.Size = new Size(122, 23);
            buttonOperasional.TabIndex = 2;
            buttonOperasional.Text = "Menu Operasional";
            buttonOperasional.UseVisualStyleBackColor = true;
            buttonOperasional.Click += buttonOperasional_Click;
            // 
            // cmbLanguageUtama
            // 
            cmbLanguageUtama.FormattingEnabled = true;
            cmbLanguageUtama.Items.AddRange(new object[] { "Indonesia", "English" });
            cmbLanguageUtama.Location = new Point(472, 3);
            cmbLanguageUtama.Name = "cmbLanguageUtama";
            cmbLanguageUtama.Size = new Size(121, 23);
            cmbLanguageUtama.TabIndex = 2;
            cmbLanguageUtama.SelectedIndexChanged += cmbLanguageUtama_SelectedIndexChanged;
            // 
            // panelContent
            // 
            panelContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelContent.Location = new Point(0, 82);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(800, 366);
            panelContent.TabIndex = 1;
            panelContent.Paint += panelContent_Paint;
            // 
            // BaseFormPegawai
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(800, 450);
            Controls.Add(panelContent);
            Controls.Add(flowLayoutPanel1);
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