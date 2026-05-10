namespace TugasBesar.Views.Pegawai.Kategori
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvKategori = new System.Windows.Forms.DataGridView();
            this.btnSetText = new System.Windows.Forms.Button();
            this.tbNamaKategori = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTambahKategori = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKategori)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kategori";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvKategori);
            this.panel1.Controls.Add(this.btnSetText);
            this.panel1.Controls.Add(this.tbNamaKategori);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnTambahKategori);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1123, 692);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dgvKategori
            // 
            this.dgvKategori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKategori.Location = new System.Drawing.Point(294, 280);
            this.dgvKategori.Margin = new System.Windows.Forms.Padding(2);
            this.dgvKategori.Name = "dgvKategori";
            this.dgvKategori.RowHeadersWidth = 51;
            this.dgvKategori.RowTemplate.Height = 24;
            this.dgvKategori.Size = new System.Drawing.Size(563, 192);
            this.dgvKategori.TabIndex = 9;
            this.dgvKategori.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKategori_CellContentClick);
            // 
            // btnSetText
            // 
            this.btnSetText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetText.Location = new System.Drawing.Point(737, 234);
            this.btnSetText.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetText.Name = "btnSetText";
            this.btnSetText.Size = new System.Drawing.Size(90, 26);
            this.btnSetText.TabIndex = 8;
            this.btnSetText.Text = "Set Text";
            this.btnSetText.UseVisualStyleBackColor = true;
            this.btnSetText.Click += new System.EventHandler(this.btnSetText_Click);
            // 
            // tbNamaKategori
            // 
            this.tbNamaKategori.Location = new System.Drawing.Point(50, 128);
            this.tbNamaKategori.Margin = new System.Windows.Forms.Padding(2);
            this.tbNamaKategori.Multiline = true;
            this.tbNamaKategori.Name = "tbNamaKategori";
            this.tbNamaKategori.Size = new System.Drawing.Size(180, 34);
            this.tbNamaKategori.TabIndex = 7;
            this.tbNamaKategori.TextChanged += new System.EventHandler(this.tbNamaKategori_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 109);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nama Kategori";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnTambahKategori
            // 
            this.btnTambahKategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambahKategori.Location = new System.Drawing.Point(574, 234);
            this.btnTambahKategori.Margin = new System.Windows.Forms.Padding(2);
            this.btnTambahKategori.Name = "btnTambahKategori";
            this.btnTambahKategori.Size = new System.Drawing.Size(147, 26);
            this.btnTambahKategori.TabIndex = 0;
            this.btnTambahKategori.Text = "Tambah Kategori";
            this.btnTambahKategori.UseVisualStyleBackColor = true;
            this.btnTambahKategori.Click += new System.EventHandler(this.btnTambahKategori_Click);
            // 
            // ViewKategori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ViewKategori";
            this.Size = new System.Drawing.Size(1123, 692);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKategori)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTambahKategori;
        private System.Windows.Forms.TextBox tbNamaKategori;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSetText;
        private System.Windows.Forms.DataGridView dgvKategori;
    }
}
