namespace TugasBesar.App.Views.Pegawai.Transaksi
{
    partial class ViewTransaksi
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
            labelTransaksiJudul = new Label();
            panel2 = new Panel();
            CbxMetodePembayaran = new ComboBox();
            btnBelumLunas = new Button();
            btnLunas = new Button();
            labelStatus = new Label();
            tbStatus = new TextBox();
            btnProsesPembayaran = new Button();
            tbTotal = new TextBox();
            tbUangKembalian = new TextBox();
            label17 = new Label();
            label12 = new Label();
            tbUangDiterima = new TextBox();
            label11 = new Label();
            label9 = new Label();
            tbNamaPembeli = new TextBox();
            label8 = new Label();
            panel3 = new Panel();
            panelListKeranjang = new FlowLayoutPanel();
            panel1 = new Panel();
            panelListProduk = new FlowLayoutPanel();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // labelTransaksiJudul
            // 
            labelTransaksiJudul.AutoSize = true;
            labelTransaksiJudul.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTransaksiJudul.Location = new Point(34, 76);
            labelTransaksiJudul.Margin = new Padding(2, 0, 2, 0);
            labelTransaksiJudul.Name = "labelTransaksiJudul";
            labelTransaksiJudul.Size = new Size(79, 17);
            labelTransaksiJudul.TabIndex = 2;
            labelTransaksiJudul.Text = "Transaksi";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(CbxMetodePembayaran);
            panel2.Controls.Add(btnBelumLunas);
            panel2.Controls.Add(btnLunas);
            panel2.Controls.Add(labelStatus);
            panel2.Controls.Add(tbStatus);
            panel2.Controls.Add(btnProsesPembayaran);
            panel2.Controls.Add(tbTotal);
            panel2.Controls.Add(tbUangKembalian);
            panel2.Controls.Add(label17);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(tbUangDiterima);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(tbNamaPembeli);
            panel2.Controls.Add(label8);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(525, 0);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(528, 447);
            panel2.TabIndex = 3;
            // 
            // CbxMetodePembayaran
            // 
            CbxMetodePembayaran.FormattingEnabled = true;
            CbxMetodePembayaran.Location = new Point(197, 93);
            CbxMetodePembayaran.Name = "CbxMetodePembayaran";
            CbxMetodePembayaran.Size = new Size(170, 23);
            CbxMetodePembayaran.TabIndex = 21;
            // 
            // btnBelumLunas
            // 
            btnBelumLunas.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBelumLunas.Location = new Point(437, 334);
            btnBelumLunas.Margin = new Padding(2);
            btnBelumLunas.Name = "btnBelumLunas";
            btnBelumLunas.Size = new Size(73, 48);
            btnBelumLunas.TabIndex = 20;
            btnBelumLunas.Text = "Belum Lunas";
            btnBelumLunas.UseVisualStyleBackColor = true;
            btnBelumLunas.Click += btnBelumLunas_Click;
            // 
            // btnLunas
            // 
            btnLunas.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLunas.Location = new Point(360, 334);
            btnLunas.Margin = new Padding(2);
            btnLunas.Name = "btnLunas";
            btnLunas.Size = new Size(73, 48);
            btnLunas.TabIndex = 19;
            btnLunas.Text = "Lunas";
            btnLunas.UseVisualStyleBackColor = true;
            btnLunas.Click += btnLunas_Click;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStatus.Location = new Point(195, 315);
            labelStatus.Margin = new Padding(2, 0, 2, 0);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(54, 17);
            labelStatus.TabIndex = 18;
            labelStatus.Text = "Status";
            // 
            // tbStatus
            // 
            tbStatus.Enabled = false;
            tbStatus.Location = new Point(198, 334);
            tbStatus.Margin = new Padding(2);
            tbStatus.Multiline = true;
            tbStatus.Name = "tbStatus";
            tbStatus.Size = new Size(158, 37);
            tbStatus.TabIndex = 17;
            // 
            // btnProsesPembayaran
            // 
            btnProsesPembayaran.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProsesPembayaran.Location = new Point(197, 384);
            btnProsesPembayaran.Margin = new Padding(2);
            btnProsesPembayaran.Name = "btnProsesPembayaran";
            btnProsesPembayaran.Size = new Size(139, 31);
            btnProsesPembayaran.TabIndex = 16;
            btnProsesPembayaran.Text = "Proses Pembayaran";
            btnProsesPembayaran.UseVisualStyleBackColor = true;
            btnProsesPembayaran.Click += btnProsesPembayaran_Click;
            // 
            // tbTotal
            // 
            tbTotal.Location = new Point(197, 271);
            tbTotal.Margin = new Padding(2);
            tbTotal.Multiline = true;
            tbTotal.Name = "tbTotal";
            tbTotal.Size = new Size(158, 37);
            tbTotal.TabIndex = 2;
            tbTotal.TextChanged += tbTotal_TextChanged;
            // 
            // tbUangKembalian
            // 
            tbUangKembalian.Location = new Point(198, 207);
            tbUangKembalian.Margin = new Padding(2);
            tbUangKembalian.Multiline = true;
            tbUangKembalian.Name = "tbUangKembalian";
            tbUangKembalian.Size = new Size(170, 29);
            tbUangKembalian.TabIndex = 14;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.Location = new Point(195, 252);
            label17.Margin = new Padding(2, 0, 2, 0);
            label17.Name = "label17";
            label17.Size = new Size(45, 17);
            label17.TabIndex = 1;
            label17.Text = "Total";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(194, 188);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(126, 17);
            label12.TabIndex = 13;
            label12.Text = "Uang Kembalian";
            // 
            // tbUangDiterima
            // 
            tbUangDiterima.Location = new Point(198, 147);
            tbUangDiterima.Margin = new Padding(2);
            tbUangDiterima.Multiline = true;
            tbUangDiterima.Name = "tbUangDiterima";
            tbUangDiterima.Size = new Size(170, 29);
            tbUangDiterima.TabIndex = 12;
            tbUangDiterima.TextChanged += tbUangDiterima_TextChanged;
            tbUangDiterima.KeyPress += tbUangDiterima_KeyPress;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(194, 128);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(167, 17);
            label11.TabIndex = 11;
            label11.Text = "Jumlah Uang Diterima";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(194, 67);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(156, 17);
            label9.TabIndex = 6;
            label9.Text = "Metode Pembayaran";
            // 
            // tbNamaPembeli
            // 
            tbNamaPembeli.Location = new Point(197, 19);
            tbNamaPembeli.Margin = new Padding(2);
            tbNamaPembeli.Multiline = true;
            tbNamaPembeli.Name = "tbNamaPembeli";
            tbNamaPembeli.Size = new Size(170, 29);
            tbNamaPembeli.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(194, 0);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(111, 17);
            label8.TabIndex = 4;
            label8.Text = "Nama Pembeli";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonFace;
            panel3.Controls.Add(panelListKeranjang);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(525, 447);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(528, 256);
            panel3.TabIndex = 4;
            // 
            // panelListKeranjang
            // 
            panelListKeranjang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelListKeranjang.AutoScroll = true;
            panelListKeranjang.Location = new Point(56, 21);
            panelListKeranjang.Name = "panelListKeranjang";
            panelListKeranjang.Size = new Size(458, 220);
            panelListKeranjang.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(panelListProduk);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(525, 703);
            panel1.TabIndex = 1;
            // 
            // panelListProduk
            // 
            panelListProduk.AutoScroll = true;
            panelListProduk.Location = new Point(37, 181);
            panelListProduk.Name = "panelListProduk";
            panelListProduk.Size = new Size(396, 314);
            panelListProduk.TabIndex = 1;
            // 
            // ViewTransaksi
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(labelTransaksiJudul);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "ViewTransaksi";
            Size = new Size(1053, 703);
            Load += ViewTransaksi_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTransaksiJudul;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbUangDiterima;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbNamaPembeli;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnProsesPembayaran;
        private System.Windows.Forms.TextBox tbUangKembalian;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel panelListProduk;
        private System.Windows.Forms.FlowLayoutPanel panelListKeranjang;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button btnLunas;
        private System.Windows.Forms.Button btnBelumLunas;
        private ComboBox CbxMetodePembayaran;
    }
}
