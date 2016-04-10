using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dx.misv.donations.data;
using Microsoft.ApplicationInsights;
using Newtonsoft.Json.Linq;

namespace dx.misv.donations.web.Services
{
    public class DonationExperienceService : IDonationExperienceService
    {
        private readonly DonationExperienceSettings donationExperienceSettings;
        private readonly IDonationPredictionService donationPredictionService;

        public DonationExperienceService(DonationExperienceSettings donationExperienceSettings, IDonationPredictionService donationPredictionService)
        {
            this.donationExperienceSettings = donationExperienceSettings;
            this.donationPredictionService = donationPredictionService;
        }

        public async Task<DonationExperienceValues> GetValuesForDonator(Donater donater)
        {
            var ai = new TelemetryClient();
            var response = await donationPredictionService.InvokeRequestResponseService(donater);

            if (response.Success)
            {
                try
                {
                    var json = JObject.Parse(response.Response);
                    var columnNames = json["Results"]["output1"]["value"]["ColumnNames"].ToArray();
                    var scoreArrayIndex = Array.IndexOf(columnNames, "Scored Labels");
                    var score = json["Results"]["output1"]["value"]["Values"].ToArray()[0].ToArray()[scoreArrayIndex];

                    return new DonationExperienceValues
                    {
                        Score = score.ToString(),
                        Values = SuggestedValuesFromScore((double) score, donationExperienceSettings.SuggestionCount, donationExperienceSettings.Multiplier),
                        Success = true,
                        Message = response.Response,
                        ExperienceSettings = donationExperienceSettings,
                        RequestTime = response.RequestTime
                    };
                }
                catch (Exception ex)
                {
                    ai.TrackException(ex);
                    return new DonationExperienceValues
                    {
                        Success = false,
                        Message = ex.ToString()
                    };
                }
            }
            ai.TrackException(new Exception(response.Response));
            return new DonationExperienceValues
            {
                Success = false,
                Message = response.Response
            };
        }

        internal IEnumerable<int> SuggestedValuesFromScore(double score, int count, double multiplier)
        {
            var roundedScore = 10*(int) Math.Round(score/10);

            var choices = new List<int> {roundedScore};


            var spacer = roundedScore*multiplier;
            var roundedSpacer = 5*(int) Math.Round(spacer/5);

            var tally = roundedScore + roundedSpacer;
            for (var i = 0; i < count - 1; i++)
            {
                choices.Add(tally);
                tally += roundedSpacer;
            }
            return choices;
        }
    }

    public class DonationExperienceSettings
    {
        public int SuggestionCount { get; set; }
        public double Multiplier { get; set; }
    }
}