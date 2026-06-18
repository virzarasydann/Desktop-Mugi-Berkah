using System.Collections.Generic;
using TugasBesar.Core.DTO.Response;

namespace TugasBesar.Core.Factories.Reports
{
    public interface IReportExporter
    {
        void Export(List<TransaksiResponseDTO> data, string filePath);
    }
}