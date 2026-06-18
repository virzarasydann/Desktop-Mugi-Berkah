namespace TugasBesar.App.Views.Admin.Riwayat
{
    partial class ViewRiwayat
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
            label1 = new Label();
            panel1 = new Panel();
            DgvRiwayat = new DataGridView();
            Tanggal = new DateTimePicker();
            TbTotalPendapatan = new TextBox();
            label3 = new Label();
            TbTotalTransaksi = new TextBox();
            label2 = new Label();
            BtnApply = new Button();
            CbxExport = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvRiwayat).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(27, 61);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(140, 17);
            label1.TabIndex = 3;
            label1.Text = "Riwayat Transaksi";
            // 
            // panel1
            // 
            panel1.Controls.Add(CbxExport);
            panel1.Controls.Add(BtnApply);
            panel1.Controls.Add(DgvRiwayat);
            panel1.Controls.Add(Tanggal);
            panel1.Controls.Add(TbTotalPendapatan);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(TbTotalTransaksi);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1107, 653);
            panel1.TabIndex = 4;
            // 
            // DgvRiwayat
            // 
            DgvRiwayat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvRiwayat.Location = new Point(50, 140);
            DgvRiwayat.Name = "DgvRiwayat";
            DgvRiwayat.Size = new Size(678, 403);
            DgvRiwayat.TabIndex = 6;
            // 
            // Tanggal
            // 
            Tanggal.Location = new Point(493, 54);
            Tanggal.Name = "Tanggal";
            Tanggal.Size = new Size(200, 23);
            Tanggal.TabIndex = 5;
            // 
            // TbTotalPendapatan
            // 
            TbTotalPendapatan.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TbTotalPendapatan.Location = new Point(282, 52);
            TbTotalPendapatan.Margin = new Padding(2);
            TbTotalPendapatan.Multiline = true;
            TbTotalPendapatan.Name = "TbTotalPendapatan";
            TbTotalPendapatan.ReadOnly = true;
            TbTotalPendapatan.Size = new Size(174, 38);
            TbTotalPendapatan.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(278, 34);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(137, 17);
            label3.TabIndex = 2;
            label3.Text = "Total Pendapatan";
            // 
            // TbTotalTransaksi
            // 
            TbTotalTransaksi.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TbTotalTransaksi.Location = new Point(50, 52);
            TbTotalTransaksi.Margin = new Padding(2);
            TbTotalTransaksi.Multiline = true;
            TbTotalTransaksi.Name = "TbTotalTransaksi";
            TbTotalTransaksi.ReadOnly = true;
            TbTotalTransaksi.Size = new Size(174, 38);
            TbTotalTransaksi.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(46, 34);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(121, 17);
            label2.TabIndex = 0;
            label2.Text = "Total Transaksi";
            // 
            // BtnApply
            // 
            BtnApply.Location = new Point(849, 56);
            BtnApply.Name = "BtnApply";
            BtnApply.Size = new Size(75, 23);
            BtnApply.TabIndex = 7;
            BtnApply.Text = "Apply";
            BtnApply.UseVisualStyleBackColor = true;
            BtnApply.Click += BtnApply_Click;
            // 
            // CbxExport
            // 
            CbxExport.FormattingEnabled = true;
            CbxExport.Location = new Point(712, 56);
            CbxExport.Name = "CbxExport";
            CbxExport.Size = new Size(121, 23);
            CbxExport.TabIndex = 8;
            // 
            // ViewRiwayat
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(panel1);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "ViewRiwayat";
            Size = new Size(1107, 653);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvRiwayat).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TbTotalTransaksi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TbTotalPendapatan;
        private System.Windows.Forms.Label label3;
        private DateTimePicker Tanggal;
        private DataGridView DgvRiwayat;
        private Button BtnApply;
        private ComboBox CbxExport;
    }
}
