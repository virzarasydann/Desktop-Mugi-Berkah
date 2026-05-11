namespace TugasBesar.App.Views.Admin.AkunPegawai
{
    partial class FormEditAkunPegawai
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new TextBox();
            label2 = new TextBox();
            btnSimpan = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(56, 51);
            label1.Margin = new Padding(4, 3, 4, 3);
            label1.Name = "label1";
            label1.Size = new Size(116, 23);
            label1.TabIndex = 0;
            label1.TextChanged += tbUsernameEdit_TextChanged;
            // 
            // label2
            // 
            label2.Location = new Point(56, 119);
            label2.Margin = new Padding(4, 3, 4, 3);
            label2.Name = "label2";
            label2.Size = new Size(116, 23);
            label2.TabIndex = 1;
            label2.TextChanged += tbPasswordEdit_TextChanged;
            // 
            // btnSimpan
            // 
            btnSimpan.Location = new Point(84, 201);
            btnSimpan.Margin = new Padding(4, 3, 4, 3);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(88, 27);
            btnSimpan.TabIndex = 2;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = true;
            btnSimpan.Click += btnSimpan_Click_1;
            // 
            // FormEditAkunPegawai
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(btnSimpan);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormEditAkunPegawai";
            Text = "FormEditAkunPegawai";
            Load += FormEditAkunPegawai_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox label1;
        private System.Windows.Forms.TextBox label2;
        private System.Windows.Forms.Button btnSimpan;
    }
}