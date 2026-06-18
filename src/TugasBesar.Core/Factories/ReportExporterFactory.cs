using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.Factories.Reports;

namespace TugasBesar.Core.Factories
{
    public class ReportExporterFactory
    {
        public IReportExporter CreateExporter(string format)
        {
            return format.ToLower() switch
            {
                "pdf" => new PdfReportExporter(),
                "excel" => new ExcelReportExporter(),
                "csv" => new CsvReportExporter(),
                _ => throw new ArgumentException($"Format ekspor '{format}' tidak didukung.")
            };
        }
    }
}
