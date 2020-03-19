using SautinSoft;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.Helpers
{
    public static class FileConverter
    {

        public static string ConvertPdfToDocx(string file)
        {
            PdfFocus f = new PdfFocus();
            f.OpenPdf(file);
            string outFile = string.Empty;
            if (f.PageCount > 0)
            {
                // To Docx.
                outFile = Path.ChangeExtension(file, ".docx");
                f.WordOptions.Format = PdfFocus.CWordOptions.eWordDocument.Docx;
                //if (f.ToWord(outFile) == 0)
                //    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });
            }

            return outFile;
        }
    }
}
