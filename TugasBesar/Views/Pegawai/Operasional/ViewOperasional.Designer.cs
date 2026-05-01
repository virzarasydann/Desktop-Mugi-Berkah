namespace TugasBesar.Views.Pegawai.Operasional
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSetText = new System.Windows.Forms.Button();
            this.tbHargaOperasional = new System.Windows.Forms.TextBox();
            this.tbNamaOperasional = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTambahOperasional = new System.Windows.Forms.Button();
            this.dgvOperasional = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperasional)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Operasional";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvOperasional);
            this.panel1.Controls.Add(this.btnSetText);
            this.panel1.Controls.Add(this.tbHargaOperasional);
            this.panel1.Controls.Add(this.tbNamaOperasional);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnTambahOperasional);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1404, 865);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnSetText
            // 
            this.btnSetText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetText.Location = new System.Drawing.Point(1050, 286);
            this.btnSetText.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetText.Name = "btnSetText";
            this.btnSetText.Size = new System.Drawing.Size(139, 38);
            this.btnSetText.TabIndex = 7;
            this.btnSetText.Text = "Set Tex";
            this.btnSetText.UseVisualStyleBackColor = true;
            this.btnSetText.Click += new System.EventHandler(this.btnSetText_Click);
            // 
            // tbHargaOperasional
            // 
            this.tbHargaOperasional.Location = new System.Drawing.Point(81, 228);
            this.tbHargaOperasional.Margin = new System.Windows.Forms.Padding(2);
            this.tbHargaOperasional.Multiline = true;
            this.tbHargaOperasional.Name = "tbHargaOperasional";
            this.tbHargaOperasional.Size = new System.Drawing.Size(296, 46);
            this.tbHargaOperasional.TabIndex = 6;
            this.tbHargaOperasional.TextChanged += new System.EventHandler(this.tbHargaOperasional_TextChanged);
            // 
            // tbNamaOperasional
            // 
            this.tbNamaOperasional.Location = new System.Drawing.Point(81, 112);
            this.tbNamaOperasional.Margin = new System.Windows.Forms.Padding(2);
            this.tbNamaOperasional.Multiline = true;
            this.tbNamaOperasional.Name = "tbNamaOperasional";
            this.tbNamaOperasional.Size = new System.Drawing.Size(296, 44);
            this.tbNamaOperasional.TabIndex = 5;
            this.tbNamaOperasional.TextChanged += new System.EventHandler(this.tbNamaOperasional_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(78, 202);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Harga Operasional";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(78, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nama Operasional";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnTambahOperasional
            // 
            this.btnTambahOperasional.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambahOperasional.Location = new System.Drawing.Point(604, 31);
            this.btnTambahOperasional.Margin = new System.Windows.Forms.Padding(2);
            this.btnTambahOperasional.Name = "btnTambahOperasional";
            this.btnTambahOperasional.Size = new System.Drawing.Size(204, 40);
            this.btnTambahOperasional.TabIndex = 0;
            this.btnTambahOperasional.Text = "Tambah Operasional";
            this.btnTambahOperasional.UseVisualStyleBackColor = true;
            this.btnTambahOperasional.Click += new System.EventHandler(this.btnTambahOperasional_Click);
            // 
            // dgvOperasional
            // 
            this.dgvOperasional.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperasional.Location = new System.Drawing.Point(276, 422);
            this.dgvOperasional.Name = "dgvOperasional";
            this.dgvOperasional.RowHeadersWidth = 51;
            this.dgvOperasional.RowTemplate.Height = 24;
            this.dgvOperasional.Size = new System.Drawing.Size(891, 297);
            this.dgvOperasional.TabIndex = 8;
            this.dgvOperasional.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOperasional_CellContentClick);
            // 
            // ViewOperasional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ViewOperasional";
            this.Size = new System.Drawing.Size(1404, 865);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperasional)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSetText;
        private System.Windows.Forms.TextBox tbHargaOperasional;
        private System.Windows.Forms.TextBox tbNamaOperasional;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTambahOperasional;
        private System.Windows.Forms.DataGridView dgvOperasional;
    }
}
