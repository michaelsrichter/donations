using CsvHelper.Configuration;

namespace dx.misv.donations.data
{
    public sealed class ZipsAndIncomeMap: CsvClassMap<ZipsAndIncome>
    {
        public ZipsAndIncomeMap()
        {
            Map(m => m.Zip);
            Map(m => m.Rank);
            Map(m => m.Income);
        }
    }
}