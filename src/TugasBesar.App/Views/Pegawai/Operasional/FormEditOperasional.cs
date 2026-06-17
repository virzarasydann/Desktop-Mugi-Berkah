using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasBesar.Core.Controllers.Interfaces;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Services;

namespace TugasBesar.App.Views.Pegawai.Operasional
{
    public partial class FormEditOperasional : Form
    {
        private readonly IOperasionalApi _operasionalApi;
        private readonly MasterDataCacheService _cache;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public OperasionalResponseDTO Operasional { get; set; }

        public FormEditOperasional(OperasionalResponseDTO data, IOperasionalApi operasionalApi, MasterDataCacheService cache)
        {
            InitializeComponent();

            Operasional = data;
            _operasionalApi = operasionalApi;
            _cache = cache;

            tbNama.Text = data.Nama;
            tbHarga.Text = data.Harga.ToString();
        }

        private async void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(tbHarga.Text, out int harga))
                {
                    MessageBox.Show("Harga harus berupa angka.");
                    return;
                }

                var request = new OperasionalRequestDTO
                {
                    IdUser = 2,
                    NamaUser = "Kasir",
                    Nama = tbNama.Text,
                    Harga = harga
                };

                await _operasionalApi.Edit(Operasional.id, request);

                var dataBaru = (await _operasionalApi.GetAll()).ToList();
                _cache.DaftarOperasional = dataBaru;

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