using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TugasBesar.Core.Factories;
using TugasBesar.Core.Factories.Reports;
using TugasBesar.Core.Services;

namespace TugasBesar.App.Views.Admin.Riwayat
{
    public partial class ViewRiwayat : UserControl
    {
        private readonly MasterDataCacheService _cache;
        private readonly ReportExporterFactory _exporterFactory;

        public ViewRiwayat(MasterDataCacheService cache)
        {
            InitializeComponent();
            _cache = cache;
            _exporterFactory = new ReportExporterFactory();

            SetupDataGridView();
            SetupComboBoxExport();

            this.Load += ViewRiwayat_Load;
            Tanggal.ValueChanged += Tanggal_ValueChanged;
            BtnApply.Click += BtnApply_Click;
        }

        private void SetupComboBoxExport()
        {
            CbxExport.Items.Clear();
            CbxExport.Items.AddRange(new object[] { "Pdf", "Excel", "Csv" });
            CbxExport.SelectedIndex = 0;
        }

        private void SetupDataGridView()
        {
            DgvRiwayat.AllowUserToAddRows = false;
            DgvRiwayat.AllowUserToDeleteRows = false;
            DgvRiwayat.AllowUserToResizeRows = false;
            DgvRiwayat.ReadOnly = true;
            DgvRiwayat.RowHeadersVisible = false;
            DgvRiwayat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvRiwayat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvRiwayat.BackgroundColor = Color.White;
            DgvRiwayat.BorderStyle = BorderStyle.None;
            DgvRiwayat.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            DgvRiwayat.EnableHeadersVisualStyles = false;
            DgvRiwayat.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DgvRiwayat.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            DgvRiwayat.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            DgvRiwayat.ColumnHeadersHeight = 35;

            DgvRiwayat.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            DgvRiwayat.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 236, 255);
            DgvRiwayat.DefaultCellStyle.SelectionForeColor = Color.Black;
            DgvRiwayat.RowTemplate.Height = 35;

            DgvRiwayat.ColumnCount = 3;
            DgvRiwayat.Columns[0].Name = "No";
            DgvRiwayat.Columns[0].FillWeight = 15;
            DgvRiwayat.Columns[1].Name = "Harga";
            DgvRiwayat.Columns[1].FillWeight = 40;
            DgvRiwayat.Columns[2].Name = "Tanggal";
            DgvRiwayat.Columns[2].FillWeight = 45;
        }

        private void ViewRiwayat_Load(object sender, EventArgs e)
        {
            RenderTable();
        }

        private void Tanggal_ValueChanged(object sender, EventArgs e)
        {
            RenderTable();
        }

        private void RenderTable()
        {
            DgvRiwayat.Rows.Clear();

            var selectedDate = Tanggal.Value.Date;
            var filteredData = _cache.DaftarTransaksi
                .Where(t => t.Tanggal.Date == selectedDate)
                .ToList();

            TbTotalTransaksi.Text = filteredData.Count.ToString();
            TbTotalPendapatan.Text = $"Rp {filteredData.Sum(t => t.TotalHarga):N0}";

            int no = 1;
            foreach (var item in filteredData)
            {
                DgvRiwayat.Rows.Add(
                    no++,
                    $"Rp {item.TotalHarga:N0}",
                    item.Tanggal.ToString("yyyy-MM-dd HH:mm:ss")
                );
            }
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            if (CbxExport.SelectedItem == null)
            {
                MessageBox.Show("Silakan pilih format ekspor terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedFormat = CbxExport.SelectedItem.ToString();
            var selectedDate = Tanggal.Value.Date;

            var filteredData = _cache.DaftarTransaksi
                .Where(t => t.Tanggal.Date == selectedDate)
                .ToList();

            if (!filteredData.Any())
            {
                MessageBox.Show("Tidak ada data transaksi untuk diekspor pada tanggal yang dipilih.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = $"Ekspor Laporan {selectedFormat}";
                saveFileDialog.FileName = $"Laporan_Penjualan_{selectedDate:yyyyMMdd}";
                saveFileDialog.Filter = selectedFormat.ToLower() switch
                {
                    "pdf" => "PDF Files (*.pdf)|*.pdf",
                    "excel" => "Excel Files (*.xlsx)|*.xlsx",
                    "csv" => "CSV Files (*.csv)|*.csv",
                    _ => "All Files (*.*)|*.*"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        IReportExporter exporter = _exporterFactory.CreateExporter(selectedFormat);
                        exporter.Export(filteredData, saveFileDialog.FileName);

                        MessageBox.Show($"Data berhasil diekspor ke format {selectedFormat}!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Gagal mengekspor data: {ex.Message}", "Error Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}