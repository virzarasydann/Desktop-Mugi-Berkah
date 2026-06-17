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
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvStatus).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(DgvStatus);
            panel1.Controls.Add(TbNamaStatus);
            panel1.Controls.Add(LabelNamaStatus);
            panel1.Controls.Add(BtnTambahStatus);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1123, 692);
            panel1.TabIndex = 5;
            // 
            // DgvStatus
            // 
            DgvStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvStatus.Location = new Point(269, 280);
            DgvStatus.Margin = new Padding(2);
            DgvStatus.Name = "DgvStatus";
            DgvStatus.RowHeadersWidth = 51;
            DgvStatus.RowTemplate.Height = 24;
            DgvStatus.Size = new Size(588, 314);
            DgvStatus.TabIndex = 9;
            DgvStatus.CellClick += DgvStatus_CellClick;
            // 
            // TbNamaStatus
            // 
            TbNamaStatus.Location = new Point(50, 128);
            TbNamaStatus.Margin = new Padding(2);
            TbNamaStatus.Multiline = true;
            TbNamaStatus.Name = "TbNamaStatus";
            TbNamaStatus.Size = new Size(180, 34);
            TbNamaStatus.TabIndex = 7;
            // 
            // LabelNamaStatus
            // 
            LabelNamaStatus.AutoSize = true;
            LabelNamaStatus.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelNamaStatus.Location = new Point(47, 109);
            LabelNamaStatus.Margin = new Padding(2, 0, 2, 0);
            LabelNamaStatus.Name = "LabelNamaStatus";
            LabelNamaStatus.Size = new Size(100, 17);
            LabelNamaStatus.TabIndex = 5;
            LabelNamaStatus.Text = "Nama Status";
            // 
            // BtnTambahStatus
            // 
            BtnTambahStatus.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnTambahStatus.Location = new Point(574, 234);
            BtnTambahStatus.Margin = new Padding(2);
            BtnTambahStatus.Name = "BtnTambahStatus";
            BtnTambahStatus.Size = new Size(170, 26);
            BtnTambahStatus.TabIndex = 0;
            BtnTambahStatus.Text = "Tambah";
            BtnTambahStatus.UseVisualStyleBackColor = true;
            BtnTambahStatus.Click += BtnTambahStatus_Click;
            // 
            // ViewStatus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "ViewStatus";
            Size = new Size(1123, 692);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvStatus).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView DgvStatus;
        private TextBox TbNamaStatus;
        private Label LabelNamaStatus;
        private Button BtnTambahStatus;
    }
}
