using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.Services
{
    public class FileConverterService : IFileConverterService
    {
        public void ConvertPdfToDocx(string source, string target)
        {
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(source);
            doc.SaveToFile(target, FileFormat.DOCX);
            doc.Close();
        }
    }
}
