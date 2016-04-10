using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;

namespace dx.misv.donations.data
{
    public class ZipsDataService : IZipsDataService
    {
        public IEnumerable<ZipsAndIncome> GetZips()
        {
            return GetZips("ZipsAndIncome.txt");
        }

        public IEnumerable<ZipsAndIncome> GetZips(string file)
        {
            var textReader = File.OpenText(file);
            var csv = new CsvReader(textReader);
            var zipMap = new ZipsAndIncomeMap();
            csv.Configuration.RegisterClassMap(zipMap);
            csv.Configuration.HasHeaderRecord = false;
            var records = csv.GetRecords<ZipsAndIncome>().ToArray();
            textReader.Close();
            return records;
        }
    }
}