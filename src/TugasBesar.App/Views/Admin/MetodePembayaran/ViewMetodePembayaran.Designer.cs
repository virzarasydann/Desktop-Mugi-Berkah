namespace TugasBesar.App.Views.Admin.MetodePembayaran
{
    partial class ViewMetodePembayaran
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
            panel1 = new Panel();
            DgvMetodePembayaran = new DataGridView();
            TbNamaMetode = new TextBox();
            LabelNamaMetode = new Label();
            BtnTambahMetode = new Button();
            panel2 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvMetodePembayaran).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(DgvMetodePembayaran);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1404, 865);
            panel1.TabIndex = 4;
            // 
            // DgvMetodePembayaran
            // 
            DgvMetodePembayaran.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvMetodePembayaran.Location = new Point(549, 228);
            DgvMetodePembayaran.Margin = new Padding(2);
            DgvMetodePembayaran.Name = "DgvMetodePembayaran";
            DgvMetodePembayaran.RowHeadersWidth = 51;
            DgvMetodePembayaran.RowTemplate.Height = 24;
            DgvMetodePembayaran.Size = new Size(735, 392);
            DgvMetodePembayaran.TabIndex = 9;
            DgvMetodePembayaran.CellClick += DgvMetodePembayaran_CellClick;
            // 
            // TbNamaMetode
            // 
            TbNamaMetode.Location = new Point(39, 155);
            TbNamaMetode.Margin = new Padding(2);
            TbNamaMetode.Multiline = true;
            TbNamaMetode.Name = "TbNamaMetode";
            TbNamaMetode.Size = new Size(224, 42);
            TbNamaMetode.TabIndex = 7;
            TbNamaMetode.TextChanged += TbNamaMetode_TextChanged;
            // 
            // LabelNamaMetode
            // 
            LabelNamaMetode.AutoSize = true;
            LabelNamaMetode.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelNamaMetode.Location = new Point(30, 112);
            LabelNamaMetode.Margin = new Padding(2, 0, 2, 0);
            LabelNamaMetode.Name = "LabelNamaMetode";
            LabelNamaMetode.Size = new Size(233, 20);
            LabelNamaMetode.TabIndex = 5;
            LabelNamaMetode.Text = "Nama Metode Pembayaran";
            // 
            // BtnTambahMetode
            // 
            BtnTambahMetode.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnTambahMetode.Location = new Point(84, 260);
            BtnTambahMetode.Margin = new Padding(2);
            BtnTambahMetode.Name = "BtnTambahMetode";
            BtnTambahMetode.Size = new Size(212, 32);
            BtnTambahMetode.TabIndex = 0;
            BtnTambahMetode.Text = "Tambah";
            BtnTambahMetode.UseVisualStyleBackColor = true;
            BtnTambahMetode.Click += BtnTambahMetode_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.GradientInactiveCaption;
            panel2.Controls.Add(BtnTambahMetode);
            panel2.Controls.Add(TbNamaMetode);
            panel2.Controls.Add(LabelNamaMetode);
            panel2.Location = new Point(48, 228);
            panel2.Name = "panel2";
            panel2.Size = new Size(375, 385);
            panel2.TabIndex = 10;
            // 
            // ViewMetodePembayaran
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(panel1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "ViewMetodePembayaran";
            Size = new Size(1404, 865);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvMetodePembayaran).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView DgvMetodePembayaran;
        private TextBox TbNamaMetode;
        private Label LabelNamaMetode;
        private Button BtnTambahMetode;
        private Panel panel2;
    }
}
