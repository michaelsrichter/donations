using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;
using dx.misv.donations.data;
using dx.misv.donations.web.Services;

namespace dx.misv.donations.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEnumerable<ZipsAndIncome> _zips;
        private readonly IDonationPredictionService donationPredictionService;
        private readonly IDonationExperienceService donationExperienceService;
        public HomeController()
        {
            var predctionConfiguration = new PredictionServiceConfiguration
            {
                ApiKey = WebConfigurationManager.AppSettings["ApiKey"],
                Uri = new Uri(WebConfigurationManager.AppSettings["MachineLearningUri"])
            };
            var experienceSettings = new DonationExperienceSettings
            {
                Multiplier = Convert.ToDouble(WebConfigurationManager.AppSettings["SuggestionMultiplier"]),
                SuggestionCount = Convert.ToInt32(WebConfigurationManager.AppSettings["SuggestionCount"])
            };
            this.donationPredictionService = new DonationPredictionService(predctionConfiguration);
            this.donationExperienceService = new DonationExperienceService(experienceSettings, donationPredictionService);
            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", "ZipsAndIncome.txt");
            _zips = new ZipsDataService().GetZips(path).Reverse();

        }


        public ActionResult Index()
        {
            ViewBag.Zips = _zips;
            return View();

        }

        [HttpPost]
        public async Task<ActionResult> Index(Donater donater)
        {
                var response = await this.donationExperienceService.GetValuesForDonator(donater);
                TempData["response"] = response;
                return RedirectToAction("Suggestions");
        }

        public ActionResult Suggestions()
        {
            return View("Suggestions", TempData["response"]);
        }

        public ActionResult Data()
        {
            return View();
        }

        public ActionResult Model()
        {
            return View();
        }
    }
}