namespace TugasBesar.App.Views.Pegawai.Kategori
{
    partial class ViewKategori
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
            panel2 = new Panel();
            dgvKategori = new DataGridView();
            tbNamaKategori = new TextBox();
            label2 = new Label();
            btnTambahKategori = new Button();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKategori).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(46, 92);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 2;
            label1.Text = "Kategori";
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1404, 865);
            panel1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvKategori);
            panel2.Location = new Point(546, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(858, 865);
            panel2.TabIndex = 10;
            // 
            // dgvKategori
            // 
            dgvKategori.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKategori.Location = new Point(57, 136);
            dgvKategori.Margin = new Padding(2);
            dgvKategori.Name = "dgvKategori";
            dgvKategori.RowHeadersWidth = 51;
            dgvKategori.RowTemplate.Height = 24;
            dgvKategori.Size = new Size(768, 481);
            dgvKategori.TabIndex = 9;
            // 
            // tbNamaKategori
            // 
            tbNamaKategori.Location = new Point(36, 77);
            tbNamaKategori.Margin = new Padding(2);
            tbNamaKategori.Multiline = true;
            tbNamaKategori.Name = "tbNamaKategori";
            tbNamaKategori.Size = new Size(224, 42);
            tbNamaKategori.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(36, 45);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(133, 20);
            label2.TabIndex = 5;
            label2.Text = "Nama Kategori";
            // 
            // btnTambahKategori
            // 
            btnTambahKategori.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTambahKategori.Location = new Point(113, 213);
            btnTambahKategori.Margin = new Padding(2);
            btnTambahKategori.Name = "btnTambahKategori";
            btnTambahKategori.Size = new Size(184, 32);
            btnTambahKategori.TabIndex = 0;
            btnTambahKategori.Text = "Tambah Kategori";
            btnTambahKategori.UseVisualStyleBackColor = true;
            btnTambahKategori.Click += btnTambahKategori_Click;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.GradientInactiveCaption;
            panel3.Controls.Add(tbNamaKategori);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(btnTambahKategori);
            panel3.Location = new Point(81, 158);
            panel3.Name = "panel3";
            panel3.Size = new Size(420, 407);
            panel3.TabIndex = 11;
            // 
            // ViewKategori
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(panel1);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "ViewKategori";
            Size = new Size(1404, 865);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKategori).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTambahKategori;
        private System.Windows.Forms.TextBox tbNamaKategori;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvKategori;
        private Panel panel2;
        private Panel panel3;
    }
}
