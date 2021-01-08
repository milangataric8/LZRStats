using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.Services
{
    public interface IFileConverterService
    {
        public void ConvertPdfToDocx(string source, string target);
    }
}
