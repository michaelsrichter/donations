using System;
using System.Collections.Generic;

namespace dx.misv.donations.data.Profiles
{
    public interface IProfile
    {
        Donater GetDonater(Random seed, IEnumerable<ZipsAndIncome> Zips);
    }
}