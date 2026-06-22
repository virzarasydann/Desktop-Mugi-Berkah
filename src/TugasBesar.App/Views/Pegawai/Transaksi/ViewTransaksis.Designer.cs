namespace TugasBesar.App.Views.Pegawai.Transaksi
{
    partial class ViewTransaksis
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
            panelListProduk = new FlowLayoutPanel();
            panel3 = new Panel();
            panelListKeranjang = new FlowLayoutPanel();
            labelTransaksiJudul = new Label();
            panel1 = new Panel();
            label9 = new Label();
            tbNamaPembeli = new TextBox();
            label8 = new Label();
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
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelListProduk
            // 
            panelListProduk.AutoScroll = true;
            panelListProduk.Location = new Point(14, 101);
            panelListProduk.Name = "panelListProduk";
            panelListProduk.Size = new Size(492, 567);
            panelListProduk.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonFace;
            panel3.Controls.Add(CbxMetodePembayaran);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(btnBelumLunas);
            panel3.Controls.Add(tbNamaPembeli);
            panel3.Controls.Add(btnLunas);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(labelStatus);
            panel3.Controls.Add(tbUangDiterima);
            panel3.Controls.Add(tbStatus);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(btnProsesPembayaran);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(tbTotal);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(tbUangKembalian);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label17);
            panel3.Controls.Add(label12);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(525, 404);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(675, 596);
            panel3.TabIndex = 8;
            // 
            // panelListKeranjang
            // 
            panelListKeranjang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelListKeranjang.AutoScroll = true;
            panelListKeranjang.Location = new Point(525, 0);
            panelListKeranjang.Name = "panelListKeranjang";
            panelListKeranjang.Size = new Size(721, 622);
            panelListKeranjang.TabIndex = 3;
            // 
            // labelTransaksiJudul
            // 
            labelTransaksiJudul.AutoSize = true;
            labelTransaksiJudul.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTransaksiJudul.Location = new Point(34, 76);
            labelTransaksiJudul.Margin = new Padding(2, 0, 2, 0);
            labelTransaksiJudul.Name = "labelTransaksiJudul";
            labelTransaksiJudul.Size = new Size(79, 17);
            labelTransaksiJudul.TabIndex = 6;
            labelTransaksiJudul.Text = "Transaksi";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(panelListKeranjang);
            panel1.Controls.Add(panelListProduk);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(525, 1000);
            panel1.TabIndex = 5;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(106, -33);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(156, 17);
            label9.TabIndex = 26;
            label9.Text = "Metode Pembayaran";
            // 
            // tbNamaPembeli
            // 
            tbNamaPembeli.Location = new Point(109, -81);
            tbNamaPembeli.Margin = new Padding(2);
            tbNamaPembeli.Multiline = true;
            tbNamaPembeli.Name = "tbNamaPembeli";
            tbNamaPembeli.Size = new Size(170, 29);
            tbNamaPembeli.TabIndex = 25;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(106, -100);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(111, 17);
            label8.TabIndex = 24;
            label8.Text = "Nama Pembeli";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(525, 0);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(675, 404);
            panel2.TabIndex = 7;
            // 
            // CbxMetodePembayaran
            // 
            CbxMetodePembayaran.FormattingEnabled = true;
            CbxMetodePembayaran.Location = new Point(297, 58);
            CbxMetodePembayaran.Name = "CbxMetodePembayaran";
            CbxMetodePembayaran.Size = new Size(170, 23);
            CbxMetodePembayaran.TabIndex = 36;
            // 
            // btnBelumLunas
            // 
            btnBelumLunas.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBelumLunas.Location = new Point(556, 223);
            btnBelumLunas.Margin = new Padding(2);
            btnBelumLunas.Name = "btnBelumLunas";
            btnBelumLunas.Size = new Size(73, 48);
            btnBelumLunas.TabIndex = 35;
            btnBelumLunas.Text = "Belum Lunas";
            btnBelumLunas.UseVisualStyleBackColor = true;
            // 
            // btnLunas
            // 
            btnLunas.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLunas.Location = new Point(466, 223);
            btnLunas.Margin = new Padding(2);
            btnLunas.Name = "btnLunas";
            btnLunas.Size = new Size(73, 48);
            btnLunas.TabIndex = 34;
            btnLunas.Text = "Lunas";
            btnLunas.UseVisualStyleBackColor = true;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStatus.Location = new Point(297, 201);
            labelStatus.Margin = new Padding(2, 0, 2, 0);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(54, 17);
            labelStatus.TabIndex = 33;
            labelStatus.Text = "Status";
            // 
            // tbStatus
            // 
            tbStatus.Enabled = false;
            tbStatus.Location = new Point(295, 229);
            tbStatus.Margin = new Padding(2);
            tbStatus.Multiline = true;
            tbStatus.Name = "tbStatus";
            tbStatus.Size = new Size(158, 37);
            tbStatus.TabIndex = 32;
            // 
            // btnProsesPembayaran
            // 
            btnProsesPembayaran.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProsesPembayaran.Location = new Point(128, 348);
            btnProsesPembayaran.Margin = new Padding(2);
            btnProsesPembayaran.Name = "btnProsesPembayaran";
            btnProsesPembayaran.Size = new Size(388, 77);
            btnProsesPembayaran.TabIndex = 31;
            btnProsesPembayaran.Text = "Proses Pembayaran";
            btnProsesPembayaran.UseVisualStyleBackColor = true;
            // 
            // tbTotal
            // 
            tbTotal.Location = new Point(85, 227);
            tbTotal.Margin = new Padding(2);
            tbTotal.Multiline = true;
            tbTotal.Name = "tbTotal";
            tbTotal.Size = new Size(158, 37);
            tbTotal.TabIndex = 23;
            // 
            // tbUangKembalian
            // 
            tbUangKembalian.Location = new Point(297, 142);
            tbUangKembalian.Margin = new Padding(2);
            tbUangKembalian.Multiline = true;
            tbUangKembalian.Name = "tbUangKembalian";
            tbUangKembalian.Size = new Size(170, 29);
            tbUangKembalian.TabIndex = 30;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.Location = new Point(85, 201);
            label17.Margin = new Padding(2, 0, 2, 0);
            label17.Name = "label17";
            label17.Size = new Size(45, 17);
            label17.TabIndex = 22;
            label17.Text = "Total";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(297, 109);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(126, 17);
            label12.TabIndex = 29;
            label12.Text = "Uang Kembalian";
            // 
            // tbUangDiterima
            // 
            tbUangDiterima.Location = new Point(85, 142);
            tbUangDiterima.Margin = new Padding(2);
            tbUangDiterima.Multiline = true;
            tbUangDiterima.Name = "tbUangDiterima";
            tbUangDiterima.Size = new Size(170, 29);
            tbUangDiterima.TabIndex = 28;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(85, 109);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(167, 17);
            label11.TabIndex = 27;
            label11.Text = "Jumlah Uang Diterima";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(297, 33);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(156, 17);
            label1.TabIndex = 26;
            label1.Text = "Metode Pembayaran";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(84, 52);
            textBox1.Margin = new Padding(2);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(170, 29);
            textBox1.TabIndex = 25;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(81, 33);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(111, 17);
            label2.TabIndex = 24;
            label2.Text = "Nama Pembeli";
            // 
            // ViewTransaksis
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(labelTransaksiJudul);
            Controls.Add(panel1);
            Name = "ViewTransaksis";
            Size = new Size(1200, 1000);
            Load += ViewTransaksis_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel panelListProduk;
        private Panel panel3;
        private FlowLayoutPanel panelListKeranjang;
        private Label labelTransaksiJudul;
        private Panel panel1;
        private Label label9;
        private TextBox tbNamaPembeli;
        private Label label8;
        private Panel panel2;
        private ComboBox CbxMetodePembayaran;
        private Button btnBelumLunas;
        private Button btnLunas;
        private Label labelStatus;
        private TextBox tbUangDiterima;
        private TextBox tbStatus;
        private Label label2;
        private Button btnProsesPembayaran;
        private TextBox textBox1;
        private TextBox tbTotal;
        private Label label1;
        private TextBox tbUangKembalian;
        private Label label11;
        private Label label17;
        private Label label12;
    }
}
