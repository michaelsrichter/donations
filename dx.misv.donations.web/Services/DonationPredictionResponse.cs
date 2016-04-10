using System;

namespace dx.misv.donations.web.Services
{
    public class DonationPredictionResponse
    {
        public string Response { get; set; }
        public bool Success { get; set; }
        public TimeSpan RequestTime { get; set; }
    }
}