namespace TugasBesar.App.Views.Pegawai.Operasional
{
    partial class ViewOperasional
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
            dgvOperasional = new DataGridView();
            tbHargaOperasional = new TextBox();
            tbNamaOperasional = new TextBox();
            label3 = new Label();
            label2 = new Label();
            btnTambahOperasional = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOperasional).BeginInit();
            panel2.SuspendLayout();
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
            label1.Size = new Size(110, 20);
            label1.TabIndex = 6;
            label1.Text = "Operasional";
            label1.Click += label1_Click;
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
            panel1.TabIndex = 7;
            panel1.Paint += panel1_Paint;
            // 
            // dgvOperasional
            // 
            dgvOperasional.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOperasional.Location = new Point(41, 275);
            dgvOperasional.Name = "dgvOperasional";
            dgvOperasional.RowHeadersWidth = 51;
            dgvOperasional.RowTemplate.Height = 24;
            dgvOperasional.Size = new Size(891, 297);
            dgvOperasional.TabIndex = 8;
            dgvOperasional.CellContentClick += dgvOperasional_CellContentClick;
            // 
            // tbHargaOperasional
            // 
            tbHargaOperasional.Location = new Point(30, 244);
            tbHargaOperasional.Margin = new Padding(2);
            tbHargaOperasional.Multiline = true;
            tbHargaOperasional.Name = "tbHargaOperasional";
            tbHargaOperasional.Size = new Size(296, 46);
            tbHargaOperasional.TabIndex = 6;
            tbHargaOperasional.TextChanged += tbHargaOperasional_TextChanged;
            // 
            // tbNamaOperasional
            // 
            tbNamaOperasional.Location = new Point(30, 130);
            tbNamaOperasional.Margin = new Padding(2);
            tbNamaOperasional.Multiline = true;
            tbNamaOperasional.Name = "tbNamaOperasional";
            tbNamaOperasional.Size = new Size(296, 44);
            tbNamaOperasional.TabIndex = 5;
            tbNamaOperasional.TextChanged += tbNamaOperasional_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(30, 209);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(167, 20);
            label3.TabIndex = 4;
            label3.Text = "Harga Operasional";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(33, 88);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(164, 20);
            label2.TabIndex = 3;
            label2.Text = "Nama Operasional";
            label2.Click += label2_Click;
            // 
            // btnTambahOperasional
            // 
            btnTambahOperasional.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTambahOperasional.Location = new Point(73, 330);
            btnTambahOperasional.Margin = new Padding(2);
            btnTambahOperasional.Name = "btnTambahOperasional";
            btnTambahOperasional.Size = new Size(204, 40);
            btnTambahOperasional.TabIndex = 0;
            btnTambahOperasional.Text = "Tambah Operasional";
            btnTambahOperasional.UseVisualStyleBackColor = true;
            btnTambahOperasional.Click += btnTambahOperasional_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvOperasional);
            panel2.Location = new Point(416, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(988, 865);
            panel2.TabIndex = 9;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.GradientInactiveCaption;
            panel3.Controls.Add(btnTambahOperasional);
            panel3.Controls.Add(tbHargaOperasional);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(tbNamaOperasional);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(31, 187);
            panel3.Name = "panel3";
            panel3.Size = new Size(353, 415);
            panel3.TabIndex = 10;
            // 
            // ViewOperasional
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(panel1);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "ViewOperasional";
            Size = new Size(1404, 865);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOperasional).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbHargaOperasional;
        private System.Windows.Forms.TextBox tbNamaOperasional;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTambahOperasional;
        private System.Windows.Forms.DataGridView dgvOperasional;
        private Panel panel3;
        private Panel panel2;
    }
}
