using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using TugasBesar.Core.DTO.Response;

namespace TugasBesar.Core.Factories.Reports
{
    public class PdfReportExporter : IReportExporter
    {
        public void Export(List<TransaksiResponseDTO> data, string filePath)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(11));

                    page.Header().Text("Laporan Penjualan POS").SemiBold().FontSize(20).FontColor(Colors.Blue.Darken2);

                    page.Content().PaddingVertical(1, Unit.Centimetre).Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(50);
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });

                        table.Header(header =>
                        {
                            header.Cell().Element(CellStyle).Text("No");
                            header.Cell().Element(CellStyle).Text("Harga");
                            header.Cell().Element(CellStyle).Text("Tanggal");

                            static IContainer CellStyle(IContainer container)
                            {
                                return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
                            }
                        });

                        int no = 1;
                        foreach (var item in data)
                        {
                            table.Cell().Element(CellStyle).Text(no.ToString());
                            table.Cell().Element(CellStyle).Text($"Rp {item.TotalHarga:N0}");
                            table.Cell().Element(CellStyle).Text(item.Tanggal.ToString("yyyy-MM-dd HH:mm:ss"));
                            no++;

                            static IContainer CellStyle(IContainer container)
                            {
                                return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                            }
                        }
                    });

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Halaman ");
                        x.CurrentPageNumber();
                        x.Span(" dari ");
                        x.TotalPages();
                    });
                });
            })
            .GeneratePdf(filePath);
        }
    }
}
