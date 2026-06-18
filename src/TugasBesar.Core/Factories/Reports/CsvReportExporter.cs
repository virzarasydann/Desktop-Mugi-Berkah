using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.DTO.Response;

namespace TugasBesar.Core.Factories.Reports
{
    public class CsvReportExporter : IReportExporter
    {
        public void Export(List<TransaksiResponseDTO> data, string filePath)
        {
            var csv = new StringBuilder();
          
            csv.AppendLine("No,Harga,Tanggal");

            int no = 1;
            foreach (var item in data)
            {
                csv.AppendLine($"{no++},{item.TotalHarga},{item.Tanggal:yyyy-MM-dd HH:mm:ss}");
            }

            File.WriteAllText(filePath, csv.ToString(), Encoding.UTF8);
        }
    }
}
