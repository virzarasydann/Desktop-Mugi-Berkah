using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.DTO.Response;

namespace TugasBesar.Core.Factories.Reports
{
    public class ExcelReportExporter : IReportExporter
    {
        public void Export(List<TransaksiResponseDTO> data, string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Laporan Penjualan");

                worksheet.Cell(1, 1).Value = "No";
                worksheet.Cell(1, 2).Value = "Harga";
                worksheet.Cell(1, 3).Value = "Tanggal";

                var headerRange = worksheet.Range("A1:C1");
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;

                int row = 2;
                int no = 1;

                foreach (var item in data)
                {
                    worksheet.Cell(row, 1).Value = no++;
                    worksheet.Cell(row, 2).Value = item.TotalHarga;
                    worksheet.Cell(row, 2).Style.NumberFormat.Format = "Rp #,##0";
                    worksheet.Cell(row, 3).Value = item.Tanggal.ToString("yyyy-MM-dd HH:mm:ss");
                    row++;
                }

                worksheet.Columns().AdjustToContents();
                workbook.SaveAs(filePath);
            }
        }
    }
}
