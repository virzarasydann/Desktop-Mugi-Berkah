namespace TugasBesar.App.Views.Admin.Status
{
    partial class ViewStatus
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
            DgvStatus = new DataGridView();
            TbNamaStatus = new TextBox();
            LabelNamaStatus = new Label();
            BtnTambahStatus = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvStatus).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2, 3, 2, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1283, 923);
            panel1.TabIndex = 5;
            // 
            // DgvStatus
            // 
            DgvStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvStatus.Location = new Point(48, 320);
            DgvStatus.Margin = new Padding(2, 3, 2, 3);
            DgvStatus.Name = "DgvStatus";
            DgvStatus.RowHeadersWidth = 51;
            DgvStatus.RowTemplate.Height = 24;
            DgvStatus.Size = new Size(672, 287);
            DgvStatus.TabIndex = 9;
            DgvStatus.CellClick += DgvStatus_CellClick;
            // 
            // TbNamaStatus
            // 
            TbNamaStatus.Location = new Point(61, 112);
            TbNamaStatus.Margin = new Padding(2, 3, 2, 3);
            TbNamaStatus.Multiline = true;
            TbNamaStatus.Name = "TbNamaStatus";
            TbNamaStatus.Size = new Size(205, 44);
            TbNamaStatus.TabIndex = 7;
            // 
            // LabelNamaStatus
            // 
            LabelNamaStatus.AutoSize = true;
            LabelNamaStatus.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelNamaStatus.Location = new Point(61, 79);
            LabelNamaStatus.Margin = new Padding(2, 0, 2, 0);
            LabelNamaStatus.Name = "LabelNamaStatus";
            LabelNamaStatus.Size = new Size(117, 20);
            LabelNamaStatus.TabIndex = 5;
            LabelNamaStatus.Text = "Nama Status";
            // 
            // BtnTambahStatus
            // 
            BtnTambahStatus.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnTambahStatus.Location = new Point(65, 204);
            BtnTambahStatus.Margin = new Padding(2, 3, 2, 3);
            BtnTambahStatus.Name = "BtnTambahStatus";
            BtnTambahStatus.Size = new Size(194, 35);
            BtnTambahStatus.TabIndex = 0;
            BtnTambahStatus.Text = "Tambah";
            BtnTambahStatus.UseVisualStyleBackColor = true;
            BtnTambahStatus.Click += BtnTambahStatus_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(DgvStatus);
            panel2.Location = new Point(518, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(765, 920);
            panel2.TabIndex = 10;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.GradientActiveCaption;
            panel3.Controls.Add(BtnTambahStatus);
            panel3.Controls.Add(TbNamaStatus);
            panel3.Controls.Add(LabelNamaStatus);
            panel3.Location = new Point(79, 311);
            panel3.Name = "panel3";
            panel3.Size = new Size(335, 313);
            panel3.TabIndex = 11;
            // 
            // ViewStatus
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ViewStatus";
            Size = new Size(1283, 923);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvStatus).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView DgvStatus;
        private TextBox TbNamaStatus;
        private Label LabelNamaStatus;
        private Button BtnTambahStatus;
        private Panel panel3;
        private Panel panel2;
    }
}
