using DataAccessLayer;
using Hangfire;
using Hangfire.Storage;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServiceLayer;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TwiiterFaceDetectionApp.Models;

namespace TwiiterFaceDetectionApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TwitsDataContext _twitsContext;
        private readonly TwittService _TwittService;
        private readonly TwittImageService _TwittImageService;
        private readonly HubManager _HubManager;
        private readonly TwitterApiService _TwitterApiService;
        private static string _track;
        public static string TweetJobId = "";
        public static string FaceJobId = "";

        public HomeController(TwitsDataContext twitsContext, TwittService TwittService, TwittImageService TwittImageService, HubManager HubManager, TwitterApiService TwitterApiService)
        {
            _twitsContext = twitsContext;
            _TwittService = TwittService;
            _TwittImageService = TwittImageService;
            _HubManager = HubManager;
            _TwitterApiService = TwitterApiService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string track)
        {
            _track = track;
            ViewData["track"] = track;

            handeleBackgroundJobs();

            var sq = _TwittImageService.GetLastTenPicture(_track);

            List<TwittImageViewModel> viewRes = new List<TwittImageViewModel>();
            foreach (var item in sq)
            {
                viewRes.Add(new TwittImageViewModel() { Url = item.Url, MaleCount = item.MaleCount, FemaleCount = item.FemaleCount });
            }

            return View(viewRes);
        }

        private void handeleBackgroundJobs()
        {

            BackgroundJob.Delete(TweetJobId);
            TweetJobId = BackgroundJob.Enqueue(() => _TwitterApiService.checkForPhotosInTwitsByText(_track));

            using (var connection = JobStorage.Current.GetConnection())
            {
                foreach (var recurringJob in connection.GetRecurringJobs())
                {
                    RecurringJob.RemoveIfExists(recurringJob.Id);
                }
            }

            RecurringJob.AddOrUpdate(() => detectFacesAndUpdateUi(), Cron.MinuteInterval(1));
        }


        public async Task detectFacesAndUpdateUi()
        {
            var res = await _TwittImageService.DetectFacesIntoredTwittsImages(_track);

            if (res.Count > 0)
            {
                res.Reverse();
                var aa = JsonConvert.SerializeObject(res.Take(10));
                _HubManager.InvokeAsync("showNewDetectedImages", aa);
            }
        }

        public IActionResult RrunningAverage()
        {
            var totalTweetAverage = _TwittService.GetHourlyAverage(_track);
            var genderAverage = _TwittImageService.GetHourlyGenderAverage(_track);
            return Json(new { track = _track, totalTweetAverage = totalTweetAverage, MalesAverage = genderAverage.Item1, femalesAverage = genderAverage.Item2 });
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
