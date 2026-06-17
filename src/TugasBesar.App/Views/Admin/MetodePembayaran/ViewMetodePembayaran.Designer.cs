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
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvMetodePembayaran).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(DgvMetodePembayaran);
            panel1.Controls.Add(TbNamaMetode);
            panel1.Controls.Add(LabelNamaMetode);
            panel1.Controls.Add(BtnTambahMetode);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1123, 692);
            panel1.TabIndex = 4;
            // 
            // DgvMetodePembayaran
            // 
            DgvMetodePembayaran.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvMetodePembayaran.Location = new Point(269, 280);
            DgvMetodePembayaran.Margin = new Padding(2);
            DgvMetodePembayaran.Name = "DgvMetodePembayaran";
            DgvMetodePembayaran.RowHeadersWidth = 51;
            DgvMetodePembayaran.RowTemplate.Height = 24;
            DgvMetodePembayaran.Size = new Size(588, 314);
            DgvMetodePembayaran.TabIndex = 9;
            DgvMetodePembayaran.CellClick += DgvMetodePembayaran_CellClick;
            // 
            // TbNamaMetode
            // 
            TbNamaMetode.Location = new Point(50, 128);
            TbNamaMetode.Margin = new Padding(2);
            TbNamaMetode.Multiline = true;
            TbNamaMetode.Name = "TbNamaMetode";
            TbNamaMetode.Size = new Size(180, 34);
            TbNamaMetode.TabIndex = 7;
            TbNamaMetode.TextChanged += TbNamaMetode_TextChanged;
            // 
            // LabelNamaMetode
            // 
            LabelNamaMetode.AutoSize = true;
            LabelNamaMetode.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelNamaMetode.Location = new Point(47, 109);
            LabelNamaMetode.Margin = new Padding(2, 0, 2, 0);
            LabelNamaMetode.Name = "LabelNamaMetode";
            LabelNamaMetode.Size = new Size(202, 17);
            LabelNamaMetode.TabIndex = 5;
            LabelNamaMetode.Text = "Nama Metode Pembayaran";
            // 
            // BtnTambahMetode
            // 
            BtnTambahMetode.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnTambahMetode.Location = new Point(574, 234);
            BtnTambahMetode.Margin = new Padding(2);
            BtnTambahMetode.Name = "BtnTambahMetode";
            BtnTambahMetode.Size = new Size(170, 26);
            BtnTambahMetode.TabIndex = 0;
            BtnTambahMetode.Text = "Tambah";
            BtnTambahMetode.UseVisualStyleBackColor = true;
            BtnTambahMetode.Click += BtnTambahMetode_Click;
            // 
            // ViewMetodePembayaran
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(panel1);
            Name = "ViewMetodePembayaran";
            Size = new Size(1123, 692);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvMetodePembayaran).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView DgvMetodePembayaran;
        private TextBox TbNamaMetode;
        private Label LabelNamaMetode;
        private Button BtnTambahMetode;
    }
}
