namespace TugasBesar.Views.Pegawai
{
    partial class BaseFormPegawai
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonProduk = new System.Windows.Forms.Button();
            this.buttonKategori = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonProduk);
            this.flowLayoutPanel1.Controls.Add(this.buttonKategori);
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(222, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(341, 64);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // buttonProduk
            // 
            this.buttonProduk.Location = new System.Drawing.Point(3, 3);
            this.buttonProduk.Name = "buttonProduk";
            this.buttonProduk.Size = new System.Drawing.Size(106, 23);
            this.buttonProduk.TabIndex = 0;
            this.buttonProduk.Text = "Menu Produk";
            this.buttonProduk.UseVisualStyleBackColor = true;
            this.buttonProduk.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonKategori
            // 
            this.buttonKategori.Location = new System.Drawing.Point(115, 3);
            this.buttonKategori.Name = "buttonKategori";
            this.buttonKategori.Size = new System.Drawing.Size(95, 23);
            this.buttonKategori.TabIndex = 1;
            this.buttonKategori.Text = "Menu Kategori";
            this.buttonKategori.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(216, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Menu Operasional";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // panelContent
            // 
            this.panelContent.Location = new System.Drawing.Point(0, 82);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(800, 366);
            this.panelContent.TabIndex = 1;
            // 
            // BaseFormPegawai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "BaseFormPegawai";
            this.Text = "NavbarForm";
            this.Load += new System.EventHandler(this.BaseFormPegawai_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonProduk;
        private System.Windows.Forms.Button buttonKategori;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panelContent;
    }
}