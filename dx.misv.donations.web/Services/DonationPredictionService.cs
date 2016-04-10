using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using dx.misv.donations.data;
using Microsoft.ApplicationInsights;

namespace dx.misv.donations.web.Services
{
    public class DonationPredictionService : IDonationPredictionService
    {
        private readonly PredictionServiceConfiguration configuration;

        public DonationPredictionService(PredictionServiceConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<DonationPredictionResponse> InvokeRequestResponseService(Donater donater)
        {
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {
                    Inputs = new Dictionary<string, StringTable>
                    {
                        {
                            "input1",
                            new StringTable
                            {
                                ColumnNames =
                                    new[]
                                    {
                                        "Age", "Sex", "Income", "Zip", "Education", "MaritalStatus", "Children",
                                        "Interactions", "Amount", "WeekDay", "Month", "Hour", "Location", "Device",
                                        "Profile"
                                    },
                                Values =
                                    new[,]
                                    {
                                        {
                                            donater.Age.ToString(),
                                            donater.Sex,
                                            donater.Income.ToString(),
                                            donater.Zip,
                                            donater.Education,
                                            donater.MaritalStatus,
                                            donater.Children,
                                            donater.Interactions.ToString(),
                                            donater.Amount.ToString(),
                                            donater.WeekDay.ToString(),
                                            donater.Month.ToString(),
                                            donater.Hour.ToString(),
                                            donater.Location,
                                            donater.Device,
                                            donater.Profile
                                        }
                                    }
                            }
                        }
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                        {"Allow unknown categorical levels", "true"}
                    }
                };
                var apiKey = configuration.ApiKey; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = configuration.Uri;
                HttpResponseMessage response = null;
                var ai = new TelemetryClient();
                var startTime = DateTime.UtcNow;
                var timer = System.Diagnostics.Stopwatch.StartNew();
                try
                {
                    response = await client.PostAsJsonAsync("", scoreRequest);
                }
                finally
                {
                    timer.Stop();
                    ai.TrackDependency("MachineLearning", "ApiCall", startTime, timer.Elapsed, response != null && response.IsSuccessStatusCode);
                }

                if (!response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();;
                    return new DonationPredictionResponse() { RequestTime= timer.Elapsed, Success = false, Response =
                        $"status:{response.StatusCode}\r\nheaders:{response.Headers}\r\ncontent:{responseContent}\r\n"
                    };
                }
                var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return new DonationPredictionResponse() { RequestTime = timer.Elapsed, Success = true, Response = result};
            }
        }
    }
}