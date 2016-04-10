using System;
using System.Collections.Generic;

namespace dx.misv.donations.web.Services
{
    public class DonationExperienceValues
    {
        public string Score { get; set; }
        public bool Success { get; set; }
        public IEnumerable<int> Values { get; set; }
        public string Message { get; set; }
        public DonationExperienceSettings ExperienceSettings { get; set; }
        public TimeSpan RequestTime { get; set; }
    }
}