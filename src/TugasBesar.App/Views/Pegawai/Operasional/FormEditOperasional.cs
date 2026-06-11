using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasBesar.Core.Controllers;
using TugasBesar.Core.Controllers.Interfaces;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Models;
using TugasBesar.Core.Services;
namespace TugasBesar.App.Views.Pegawai.Operasional
{
    public partial class FormEditOperasional : Form
    {

        private readonly IOperasionalApi _OperasionalApi;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public OperasionalResponseDTO operasional { get; set; }

        int index;

        public FormEditOperasional(OperasionalResponseDTO data, IOperasionalApi operasionalApi)
        {
            InitializeComponent();

            operasional = data;
            _OperasionalApi = operasionalApi;

            tbNama.Text = data.Nama;
            tbHarga.Text = data.Harga.ToString();
        }
        private async void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                var request = new OperasionalRequestDTO
                {
                    Nama = tbNama.Text,
                    Harga = int.Parse(tbHarga.Text)
                };

                await _OperasionalApi.Edit(operasional.id, request);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
