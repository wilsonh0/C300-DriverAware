using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DriverAware_WebApp.Models;
using Abp.Web.Mvc.Models;

namespace DriverAware_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Drivers()
        {

            RestClient restClient = new RestClient("https://driverawareapi.azurewebsites.net/");

            RestRequest restRequest = new RestRequest("api/drivers", Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);

            string response = restResponse.Content;

            var listDetect = JsonConvert.DeserializeObject<List<Driver>>(response);


            return View(listDetect);
        }

        public IActionResult RecordedIncidents()
        {

            RestClient restClient = new RestClient("https://driverawareapi.azurewebsites.net/");

            RestRequest restRequest = new RestRequest("api/recordedincidents", Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);

            string response = restResponse.Content;

            var listDetect = JsonConvert.DeserializeObject<List<RecordedIncident>>(response);


            return View(listDetect);
        }

        public IActionResult Shifts()
        {

            RestClient restClient = new RestClient("https://driverawareapi.azurewebsites.net/");

            RestRequest restRequest = new RestRequest("api/shifts", Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);

            string response = restResponse.Content;

            var listDetect = JsonConvert.DeserializeObject<List<Shift>>(response);


            return View(listDetect);
        }

        public IActionResult Vehicles()
        {

            RestClient restClient = new RestClient("https://driverawareapi.azurewebsites.net/");

            RestRequest restRequest = new RestRequest("api/vehicles", Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);

            string response = restResponse.Content;

            var listDetect = JsonConvert.DeserializeObject<List<Vehicle>>(response);


            return View(listDetect);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        /*[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(model: new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}
