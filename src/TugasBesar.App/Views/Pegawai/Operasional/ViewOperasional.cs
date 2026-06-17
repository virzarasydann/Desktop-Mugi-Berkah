using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Refit;
using TugasBesar.Core.Controllers.Interfaces;
using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Services;
using TugasBesar.Core.Services.Interfaces;
using TugasBesar.Localization;

namespace TugasBesar.App.Views.Pegawai.Operasional
{
    public partial class ViewOperasional : UserControl, IOperasionalObserver
    {
        private const string KolomEdit = "Edit";
        private const string KolomHapus = "Hapus";
        private const string KolomId = "id";
        private const string KolomNamaUser = "NamaUser";
        private const string KolomNama = "Nama";
        private const string KolomHarga = "Harga";

        private readonly Dictionary<string, Action<int>> _aksiKolom;
        private readonly IOperasionalApi _operasionalApi;
        private readonly MasterDataCacheService _cache;

        private List<OperasionalResponseDTO> _daftarOperasional = new List<OperasionalResponseDTO>();

        public ViewOperasional(IOperasionalApi operasionalApi, MasterDataCacheService cache)
        {
            InitializeComponent();
            _operasionalApi = operasionalApi;
            _cache = cache;

            dgvOperasional.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOperasional.CellClick += dgvOperasional_CellClick;
            dgvOperasional.AllowUserToAddRows = false;

            _cache.Subscribe(this);
            this.Disposed += (s, e) => _cache.Unsubscribe(this);

            _aksiKolom = new Dictionary<string, Action<int>>
            {
                { KolomEdit, BukaFormEdit },
                { KolomHapus, (rowIndex) => _ = HapusData(rowIndex) }
            };

            ApplyLanguage();
            _ = TampilkanData();
        }

        public void OnOperasionalChanged()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(OnOperasionalChanged));
                return;
            }

            _daftarOperasional = _cache.DaftarOperasional;
            RefreshGrid();
        }

        private void BukaFormEdit(int rowIndex)
        {
            var data = _daftarOperasional[rowIndex];
            var form = new FormEditOperasional(data, _operasionalApi, _cache);
            form.ShowDialog();
        }

        private async Task HapusData(int rowIndex)
        {
            var confirm = MessageBox.Show(
                "Anda yakin ingin menghapus ?",
                "Konfirmasi",
                MessageBoxButtons.YesNo
            );

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                await _operasionalApi.Hapus(_daftarOperasional[rowIndex].id);
                await RefreshCache();
            }
            catch (ApiException ex)
            {
                MessageBox.Show(TampilkanPesanError(ex));
            }
        }

        public void ApplyLanguage()
        {
            label2.Text = LocalizationService.GetString("lbl_nama_operasional");
            label3.Text = LocalizationService.GetString("lbl_biaya_operasional");
            btnTambahOperasional.Text = LocalizationService.GetString("btn_tambah");

            if (dgvOperasional.Columns.Contains(KolomEdit))
                dgvOperasional.Columns[KolomEdit].HeaderText = LocalizationService.GetString("btn_edit");

            if (dgvOperasional.Columns.Contains(KolomHapus))
                dgvOperasional.Columns[KolomHapus].HeaderText = LocalizationService.GetString("btn_hapus");
        }

        private void TambahKolomAksi()
        {
            TambahKolomButtonJikaBelumAda(KolomEdit, "btn_edit");
            TambahKolomButtonJikaBelumAda(KolomHapus, "btn_hapus");
        }

        private void TambahKolomButtonJikaBelumAda(string namaKolom, string localizationKey)
        {
            if (dgvOperasional.Columns.Contains(namaKolom))
                return;

            var kolom = new DataGridViewButtonColumn
            {
                Name = namaKolom,
                HeaderText = LocalizationService.GetString(localizationKey),
                Text = LocalizationService.GetString(localizationKey),
                UseColumnTextForButtonValue = true
            };

            dgvOperasional.Columns.Add(kolom);
        }

        private async Task TampilkanData()
        {
            try
            {
                await RefreshCache();
            }
            catch (ApiException ex)
            {
                MessageBox.Show(TampilkanPesanError(ex));
            }
        }

        private async Task RefreshCache()
        {
            var dataBaru = (await _operasionalApi.GetAll()).ToList();
            _cache.DaftarOperasional = dataBaru;
        }

        private void RefreshGrid()
        {
            dgvOperasional.DataSource = null;

            if (_daftarOperasional.Count == 0)
            {
                dgvOperasional.Columns.Clear();
                return;
            }

            dgvOperasional.AutoGenerateColumns = true;
            dgvOperasional.DataSource = _daftarOperasional;

            TambahKolomAksi();
            AturUrutanKolom();
        }

        private void AturUrutanKolom()
        {
            var urutan = new[] { KolomId, KolomNamaUser, KolomNama, KolomHarga, KolomEdit, KolomHapus };

            for (int i = 0; i < urutan.Length; i++)
            {
                if (dgvOperasional.Columns.Contains(urutan[i]))
                    dgvOperasional.Columns[urutan[i]].DisplayIndex = i;
            }

            if (dgvOperasional.Columns.Contains("IdUser"))
                dgvOperasional.Columns["IdUser"].Visible = false;

            if (dgvOperasional.Columns.Contains(KolomNamaUser))
                dgvOperasional.Columns[KolomNamaUser].HeaderText = "Diinput Oleh";
        }

        private async void btnTambahOperasional_Click(object sender, EventArgs e)
        {
            try
            {
                var nama = tbNamaOperasional.Text.Trim();
                var hargaText = tbHargaOperasional.Text.Trim();

                if (!ValidasiInput(nama, hargaText, out int harga))
                    return;

                var request = new OperasionalRequestDTO
                {
                    IdUser = 2,
                    NamaUser = "Kasir",
                    Nama = nama,
                    Harga = harga
                };

                await _operasionalApi.Tambah(request);
                await RefreshCache();

                ClearInput();
            }
            catch (ApiException ex)
            {
                MessageBox.Show("[ApiException]\n" + TampilkanPesanError(ex));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[{ex.GetType().FullName}]\n{ex.Message}\n\nInner: {ex.InnerException?.Message}");
            }
        }

        private static string TampilkanPesanError(ApiException ex)
        {
            var statusInfo = $"Status: {(int)ex.StatusCode} {ex.StatusCode}";
            var isiBody = ex.Content;

            if (string.IsNullOrWhiteSpace(isiBody))
                return $"{statusInfo}\n\n{ex.Message}\n\n(Body response kosong)";

            try
            {
                var json = System.Text.Json.JsonDocument.Parse(isiBody);
                var root = json.RootElement;

                var pesan = root.TryGetProperty("message", out var messageProp)
                    ? messageProp.GetString()
                    : ex.Message;

                if (root.TryGetProperty("detail", out var detailProp) && detailProp.ValueKind == System.Text.Json.JsonValueKind.String)
                {
                    var detail = detailProp.GetString();
                    if (!string.IsNullOrWhiteSpace(detail))
                        pesan += "\n\nDetail: " + detail;
                }

                return $"{statusInfo}\n\n{pesan}";
            }
            catch
            {
                return $"{statusInfo}\n\nBody mentah:\n{isiBody}";
            }
        }

        private bool ValidasiInput(string nama, string hargaText, out int harga)
        {
            harga = 0;

            if (string.IsNullOrWhiteSpace(nama))
            {
                MessageBox.Show("Nama operasional tidak boleh kosong.");
                return false;
            }

            if (nama.Any(char.IsDigit))
            {
                MessageBox.Show("Nama operasional harus berupa huruf, tidak boleh mengandung angka.");
                return false;
            }

            if (!int.TryParse(hargaText, out harga))
            {
                MessageBox.Show("Harga harus berupa angka.");
                return false;
            }

            if (harga <= 0)
            {
                MessageBox.Show("Harga operasional harus lebih dari 0.");
                return false;
            }

            return true;
        }

        private void btnSetText_Click(object sender, EventArgs e)
        {
            _ = TampilkanData();
        }

        private void dgvOperasional_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                if (e.RowIndex >= _daftarOperasional.Count)
                    return;

                var columnName = dgvOperasional.Columns[e.ColumnIndex].Name;

                if (_aksiKolom.ContainsKey(columnName))
                    _aksiKolom[columnName].Invoke(e.RowIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearInput()
        {
            tbNamaOperasional.Text = "";
            tbHargaOperasional.Text = "";
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void tbNamaOperasional_TextChanged(object sender, EventArgs e) { }
        private void tbHargaOperasional_TextChanged(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void dgvOperasional_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}