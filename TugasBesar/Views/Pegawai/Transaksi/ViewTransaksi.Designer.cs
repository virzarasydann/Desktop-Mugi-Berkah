namespace TugasBesar.Views.Pegawai.Transaksi
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnProsesPembayaran = new System.Windows.Forms.Button();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.tbUangKembalian = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbUangDiterima = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnQris = new System.Windows.Forms.Button();
            this.btnCash = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnNamaPembeli = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelListKeranjang = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelListProduk = new System.Windows.Forms.FlowLayoutPanel();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.btnLunas = new System.Windows.Forms.Button();
            this.btnBelumLunas = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Transaksi";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.btnBelumLunas);
            this.panel2.Controls.Add(this.btnLunas);
            this.panel2.Controls.Add(this.labelStatus);
            this.panel2.Controls.Add(this.tbStatus);
            this.panel2.Controls.Add(this.btnProsesPembayaran);
            this.panel2.Controls.Add(this.tbTotal);
            this.panel2.Controls.Add(this.tbUangKembalian);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.tbUangDiterima);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.btnQris);
            this.panel2.Controls.Add(this.btnCash);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.btnNamaPembeli);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(525, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(528, 447);
            this.panel2.TabIndex = 3;
            // 
            // btnProsesPembayaran
            // 
            this.btnProsesPembayaran.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProsesPembayaran.Location = new System.Drawing.Point(197, 384);
            this.btnProsesPembayaran.Margin = new System.Windows.Forms.Padding(2);
            this.btnProsesPembayaran.Name = "btnProsesPembayaran";
            this.btnProsesPembayaran.Size = new System.Drawing.Size(139, 31);
            this.btnProsesPembayaran.TabIndex = 16;
            this.btnProsesPembayaran.Text = "Proses Pembayaran";
            this.btnProsesPembayaran.UseVisualStyleBackColor = true;
            this.btnProsesPembayaran.Click += new System.EventHandler(this.btnProsesPembayaran_Click);
            // 
            // tbTotal
            // 
            this.tbTotal.Location = new System.Drawing.Point(197, 271);
            this.tbTotal.Margin = new System.Windows.Forms.Padding(2);
            this.tbTotal.Multiline = true;
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.Size = new System.Drawing.Size(158, 37);
            this.tbTotal.TabIndex = 2;
            this.tbTotal.TextChanged += new System.EventHandler(this.tbTotal_TextChanged);
            // 
            // tbUangKembalian
            // 
            this.tbUangKembalian.Location = new System.Drawing.Point(198, 207);
            this.tbUangKembalian.Margin = new System.Windows.Forms.Padding(2);
            this.tbUangKembalian.Multiline = true;
            this.tbUangKembalian.Name = "tbUangKembalian";
            this.tbUangKembalian.Size = new System.Drawing.Size(170, 29);
            this.tbUangKembalian.TabIndex = 14;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(195, 252);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 17);
            this.label17.TabIndex = 1;
            this.label17.Text = "Total";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(194, 188);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(126, 17);
            this.label12.TabIndex = 13;
            this.label12.Text = "Uang Kembalian";
            // 
            // tbUangDiterima
            // 
            this.tbUangDiterima.Location = new System.Drawing.Point(198, 147);
            this.tbUangDiterima.Margin = new System.Windows.Forms.Padding(2);
            this.tbUangDiterima.Multiline = true;
            this.tbUangDiterima.Name = "tbUangDiterima";
            this.tbUangDiterima.Size = new System.Drawing.Size(170, 29);
            this.tbUangDiterima.TabIndex = 12;
            this.tbUangDiterima.TextChanged += new System.EventHandler(this.tbUangDiterima_TextChanged);
            this.tbUangDiterima.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbUangDiterima_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(194, 128);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(167, 17);
            this.label11.TabIndex = 11;
            this.label11.Text = "Jumlah Uang Diterima";
            // 
            // btnQris
            // 
            this.btnQris.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQris.Location = new System.Drawing.Point(267, 86);
            this.btnQris.Margin = new System.Windows.Forms.Padding(2);
            this.btnQris.Name = "btnQris";
            this.btnQris.Size = new System.Drawing.Size(62, 28);
            this.btnQris.TabIndex = 8;
            this.btnQris.Text = "Qris";
            this.btnQris.UseVisualStyleBackColor = true;
            // 
            // btnCash
            // 
            this.btnCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCash.Location = new System.Drawing.Point(198, 86);
            this.btnCash.Margin = new System.Windows.Forms.Padding(2);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(62, 28);
            this.btnCash.TabIndex = 7;
            this.btnCash.Text = "Cash";
            this.btnCash.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(194, 67);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(156, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "Metode Pembayaran";
            // 
            // btnNamaPembeli
            // 
            this.btnNamaPembeli.Location = new System.Drawing.Point(197, 19);
            this.btnNamaPembeli.Margin = new System.Windows.Forms.Padding(2);
            this.btnNamaPembeli.Multiline = true;
            this.btnNamaPembeli.Name = "btnNamaPembeli";
            this.btnNamaPembeli.Size = new System.Drawing.Size(170, 29);
            this.btnNamaPembeli.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(194, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Nama Pembeli";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel3.Controls.Add(this.panelListKeranjang);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(525, 447);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(528, 256);
            this.panel3.TabIndex = 4;
            // 
            // panelListKeranjang
            // 
            this.panelListKeranjang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelListKeranjang.AutoScroll = true;
            this.panelListKeranjang.Location = new System.Drawing.Point(56, 21);
            this.panelListKeranjang.Name = "panelListKeranjang";
            this.panelListKeranjang.Size = new System.Drawing.Size(458, 220);
            this.panelListKeranjang.TabIndex = 3;
            this.panelListKeranjang.Paint += new System.Windows.Forms.PaintEventHandler(this.panelListKeranjang_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.panelListProduk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 703);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panelListProduk
            // 
            this.panelListProduk.AutoScroll = true;
            this.panelListProduk.Location = new System.Drawing.Point(37, 181);
            this.panelListProduk.Name = "panelListProduk";
            this.panelListProduk.Size = new System.Drawing.Size(396, 314);
            this.panelListProduk.TabIndex = 1;
            this.panelListProduk.Paint += new System.Windows.Forms.PaintEventHandler(this.panelListProduk_Paint);
            // 
            // tbStatus
            // 
            this.tbStatus.Enabled = false;
            this.tbStatus.Location = new System.Drawing.Point(198, 334);
            this.tbStatus.Margin = new System.Windows.Forms.Padding(2);
            this.tbStatus.Multiline = true;
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.Size = new System.Drawing.Size(158, 37);
            this.tbStatus.TabIndex = 17;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(195, 315);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(54, 17);
            this.labelStatus.TabIndex = 18;
            this.labelStatus.Text = "Status";
            // 
            // btnLunas
            // 
            this.btnLunas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLunas.Location = new System.Drawing.Point(360, 334);
            this.btnLunas.Margin = new System.Windows.Forms.Padding(2);
            this.btnLunas.Name = "btnLunas";
            this.btnLunas.Size = new System.Drawing.Size(73, 48);
            this.btnLunas.TabIndex = 19;
            this.btnLunas.Text = "Lunas";
            this.btnLunas.UseVisualStyleBackColor = true;
            this.btnLunas.Click += new System.EventHandler(this.btnLunas_Click);
            // 
            // btnBelumLunas
            // 
            this.btnBelumLunas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBelumLunas.Location = new System.Drawing.Point(437, 334);
            this.btnBelumLunas.Margin = new System.Windows.Forms.Padding(2);
            this.btnBelumLunas.Name = "btnBelumLunas";
            this.btnBelumLunas.Size = new System.Drawing.Size(73, 48);
            this.btnBelumLunas.TabIndex = 20;
            this.btnBelumLunas.Text = "Belum Lunas";
            this.btnBelumLunas.UseVisualStyleBackColor = true;
            this.btnBelumLunas.Click += new System.EventHandler(this.btnBelumLunas_Click);
            // 
            // ViewTransaksi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ViewTransaksi";
            this.Size = new System.Drawing.Size(1053, 703);
            this.Load += new System.EventHandler(this.ViewTransaksi_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbUangDiterima;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnQris;
        private System.Windows.Forms.Button btnCash;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox btnNamaPembeli;
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
    }
}
