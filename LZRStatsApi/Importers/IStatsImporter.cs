using LZRStatsApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.Importers
{
    public interface IStatsImporter
    {
        Task ExtractFromFile(FileDetails fileDetails);
    }
}
