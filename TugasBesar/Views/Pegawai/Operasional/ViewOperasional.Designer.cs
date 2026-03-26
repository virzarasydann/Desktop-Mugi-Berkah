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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSetText = new System.Windows.Forms.Button();
            this.tbHargaOperasional = new System.Windows.Forms.TextBox();
            this.tbNamaOperasional = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnHapusOperasional = new System.Windows.Forms.Button();
            this.btnEditOperasional = new System.Windows.Forms.Button();
            this.btnTambahOperasional = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Operasional";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.btnSetText);
            this.panel1.Controls.Add(this.tbHargaOperasional);
            this.panel1.Controls.Add(this.tbNamaOperasional);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnHapusOperasional);
            this.panel1.Controls.Add(this.btnEditOperasional);
            this.panel1.Controls.Add(this.btnTambahOperasional);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1404, 865);
            this.panel1.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.48971F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.51028F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 318F));
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(271, 377);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.93548F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.06451F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(804, 310);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(489, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Harga Operasional";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(88, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Nama Operasional";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "No";
            // 
            // btnSetText
            // 
            this.btnSetText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetText.Location = new System.Drawing.Point(1050, 286);
            this.btnSetText.Name = "btnSetText";
            this.btnSetText.Size = new System.Drawing.Size(139, 38);
            this.btnSetText.TabIndex = 7;
            this.btnSetText.Text = "Set Tex";
            this.btnSetText.UseVisualStyleBackColor = true;
            // 
            // tbHargaOperasional
            // 
            this.tbHargaOperasional.Location = new System.Drawing.Point(81, 227);
            this.tbHargaOperasional.Multiline = true;
            this.tbHargaOperasional.Name = "tbHargaOperasional";
            this.tbHargaOperasional.Size = new System.Drawing.Size(296, 46);
            this.tbHargaOperasional.TabIndex = 6;
            // 
            // tbNamaOperasional
            // 
            this.tbNamaOperasional.Location = new System.Drawing.Point(81, 113);
            this.tbNamaOperasional.Multiline = true;
            this.tbNamaOperasional.Name = "tbNamaOperasional";
            this.tbNamaOperasional.Size = new System.Drawing.Size(296, 44);
            this.tbNamaOperasional.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(77, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Harga Operasional";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(77, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nama Operasional";
            // 
            // btnHapusOperasional
            // 
            this.btnHapusOperasional.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapusOperasional.Location = new System.Drawing.Point(1050, 31);
            this.btnHapusOperasional.Name = "btnHapusOperasional";
            this.btnHapusOperasional.Size = new System.Drawing.Size(204, 40);
            this.btnHapusOperasional.TabIndex = 2;
            this.btnHapusOperasional.Text = "Hapus Operasional";
            this.btnHapusOperasional.UseVisualStyleBackColor = true;
            // 
            // btnEditOperasional
            // 
            this.btnEditOperasional.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditOperasional.Location = new System.Drawing.Point(827, 31);
            this.btnEditOperasional.Name = "btnEditOperasional";
            this.btnEditOperasional.Size = new System.Drawing.Size(204, 40);
            this.btnEditOperasional.TabIndex = 1;
            this.btnEditOperasional.Text = "Edit Operasional";
            this.btnEditOperasional.UseVisualStyleBackColor = true;
            // 
            // btnTambahOperasional
            // 
            this.btnTambahOperasional.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambahOperasional.Location = new System.Drawing.Point(604, 31);
            this.btnTambahOperasional.Name = "btnTambahOperasional";
            this.btnTambahOperasional.Size = new System.Drawing.Size(204, 40);
            this.btnTambahOperasional.TabIndex = 0;
            this.btnTambahOperasional.Text = "Tambah Operasional";
            this.btnTambahOperasional.UseVisualStyleBackColor = true;
            // 
            // ViewOperasional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "ViewOperasional";
            this.Size = new System.Drawing.Size(1404, 865);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.Button btnHapusOperasional;
        private System.Windows.Forms.Button btnEditOperasional;
        private System.Windows.Forms.Button btnTambahOperasional;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}
