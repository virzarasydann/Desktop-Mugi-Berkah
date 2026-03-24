namespace TugasBesar.Views
{
    partial class UserControl1
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
            this.panelProduk = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // panelProduk
            // 
            this.panelProduk.Location = new System.Drawing.Point(183, 174);
            this.panelProduk.Name = "panelProduk";
            this.panelProduk.Size = new System.Drawing.Size(310, 90);
            this.panelProduk.TabIndex = 0;
            this.panelProduk.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelProduk);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(816, 489);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelProduk;
    }
}
