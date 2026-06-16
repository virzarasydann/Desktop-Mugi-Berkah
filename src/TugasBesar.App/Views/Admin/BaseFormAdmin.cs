using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TugasBesar.App.Views.Admin.AkunPegawai;
using TugasBesar.App.Views.Admin.Riwayat;
using TugasBesar.App.Views.Pegawai.Transaksi;

namespace TugasBesar.App.Views.Admin
{
    public partial class BaseFormAdmin : Form
    {
        private readonly IServiceProvider _serviceProvider;
        public BaseFormAdmin(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            PindahLayar(_serviceProvider.GetRequiredService<ViewTambahAkunPegawai>());
        }

        private void PindahLayar(UserControl layar)
        {
            panelContent.Controls.Clear();
            layar.Dock = DockStyle.Fill;
            panelContent.Controls.Add(layar);
        }

        private void btnMenuRiwayat_Click(object sender, EventArgs e)
        {
            PindahLayar(_serviceProvider.GetRequiredService<ViewRiwayat>());
        }

        private void btnMenuAkunPegawai_Click(object sender, EventArgs e)
        {
            PindahLayar(_serviceProvider.GetRequiredService<ViewTambahAkunPegawai>());
        }
    }
}
