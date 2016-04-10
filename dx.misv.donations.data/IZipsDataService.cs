using System.Collections.Generic;

namespace dx.misv.donations.data
{
    public interface IZipsDataService
    {
        IEnumerable<ZipsAndIncome> GetZips();
        IEnumerable<ZipsAndIncome> GetZips(string file);
    }
}