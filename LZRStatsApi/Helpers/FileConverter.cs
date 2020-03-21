using Microsoft.Office.Interop.Word;
using Spire.Pdf;

namespace LZRStatsApi.Helpers
{
    public static class FileConverter
    {
        //TODO use dependency injection
        public static void ConvertPdfToDocx(string source, string target)
        {
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(source);
            doc.SaveToFile(target, FileFormat.DOCX);
            doc.Close();
        }
    }
}
