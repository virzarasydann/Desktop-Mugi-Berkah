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
            this.tbUsernameEdit = new System.Windows.Forms.TextBox();
            this.tbPasswordEdit = new System.Windows.Forms.TextBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbUsernameEdit
            // 
            this.tbUsernameEdit.Location = new System.Drawing.Point(48, 44);
            this.tbUsernameEdit.Name = "tbUsernameEdit";
            this.tbUsernameEdit.Size = new System.Drawing.Size(100, 20);
            this.tbUsernameEdit.TabIndex = 0;
            // 
            // tbPasswordEdit
            // 
            this.tbPasswordEdit.Location = new System.Drawing.Point(48, 103);
            this.tbPasswordEdit.Name = "tbPasswordEdit";
            this.tbPasswordEdit.Size = new System.Drawing.Size(100, 20);
            this.tbPasswordEdit.TabIndex = 1;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(72, 174);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 23);
            this.btnSimpan.TabIndex = 2;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            // 
            // FormEditAkunPegawai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.tbPasswordEdit);
            this.Controls.Add(this.tbUsernameEdit);
            this.Name = "FormEditAkunPegawai";
            this.Text = "FormEditAkunPegawai";
            this.Load += new System.EventHandler(this.FormEditAkunPegawai_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUsernameEdit;
        private System.Windows.Forms.TextBox tbPasswordEdit;
        private System.Windows.Forms.Button btnSimpan;
    }
}