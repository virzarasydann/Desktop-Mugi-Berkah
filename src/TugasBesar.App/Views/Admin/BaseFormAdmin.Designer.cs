namespace TugasBesar.App.Views.Admin
{
    partial class BaseFormAdmin
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
            panelNavbarAdmin = new FlowLayoutPanel();
            btnMenuRiwayat = new Button();
            btnMenuAkunPegawai = new Button();
            btnMetodePembayaran = new Button();
            panelContent = new Panel();
            MenuStatus = new Button();
            panelNavbarAdmin.SuspendLayout();
            SuspendLayout();
            // 
            // panelNavbarAdmin
            // 
            panelNavbarAdmin.Controls.Add(btnMenuRiwayat);
            panelNavbarAdmin.Controls.Add(btnMenuAkunPegawai);
            panelNavbarAdmin.Controls.Add(btnMetodePembayaran);
            panelNavbarAdmin.Controls.Add(MenuStatus);
            panelNavbarAdmin.Location = new Point(72, 12);
            panelNavbarAdmin.Name = "panelNavbarAdmin";
            panelNavbarAdmin.Size = new Size(626, 64);
            panelNavbarAdmin.TabIndex = 1;
            // 
            // btnMenuRiwayat
            // 
            btnMenuRiwayat.Location = new Point(3, 3);
            btnMenuRiwayat.Name = "btnMenuRiwayat";
            btnMenuRiwayat.Size = new Size(114, 23);
            btnMenuRiwayat.TabIndex = 0;
            btnMenuRiwayat.Text = "Menu Riwayat";
            btnMenuRiwayat.UseVisualStyleBackColor = true;
            btnMenuRiwayat.Click += btnMenuRiwayat_Click;
            // 
            // btnMenuAkunPegawai
            // 
            btnMenuAkunPegawai.Location = new Point(123, 3);
            btnMenuAkunPegawai.Name = "btnMenuAkunPegawai";
            btnMenuAkunPegawai.Size = new Size(143, 23);
            btnMenuAkunPegawai.TabIndex = 1;
            btnMenuAkunPegawai.Text = "Menu Akun Pegawai";
            btnMenuAkunPegawai.UseVisualStyleBackColor = true;
            btnMenuAkunPegawai.Click += btnMenuAkunPegawai_Click;
            // 
            // btnMetodePembayaran
            // 
            btnMetodePembayaran.Location = new Point(272, 3);
            btnMetodePembayaran.Name = "btnMetodePembayaran";
            btnMetodePembayaran.Size = new Size(165, 23);
            btnMetodePembayaran.TabIndex = 2;
            btnMetodePembayaran.Text = "Menu Metode Pembayaran";
            btnMetodePembayaran.UseVisualStyleBackColor = true;
            btnMetodePembayaran.Click += btnMetodePembayaran_Click;
            // 
            // panelContent
            // 
            panelContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelContent.Location = new Point(12, 82);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(776, 338);
            panelContent.TabIndex = 2;
            // 
            // MenuStatus
            // 
            MenuStatus.Location = new Point(443, 3);
            MenuStatus.Name = "MenuStatus";
            MenuStatus.Size = new Size(165, 23);
            MenuStatus.TabIndex = 3;
            MenuStatus.Text = "Menu Status";
            MenuStatus.UseVisualStyleBackColor = true;
            MenuStatus.Click += MenuStatus_Click;
            // 
            // BaseFormAdmin
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(800, 450);
            Controls.Add(panelContent);
            Controls.Add(panelNavbarAdmin);
            Name = "BaseFormAdmin";
            Text = "BaseForm";
            WindowState = FormWindowState.Maximized;
            panelNavbarAdmin.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel panelNavbarAdmin;
        private Button btnMenuRiwayat;
        private Button btnMenuAkunPegawai;
        private Panel panelContent;
        private Button btnMetodePembayaran;
        private Button MenuStatus;
    }
}