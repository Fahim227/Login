using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RA.SPCore.Lib.BE;
using RA.SPCore.Web.UI.Models;
using RA.SPCore.Web.UI.Utilities;
using System.Diagnostics;
using System.Text;

namespace RA.SPCore.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            // Parameters send to the api using CommonUtils model
            CommonUtils utils = new CommonUtils();
            utils.Text = searchString;

            List<Login> loginList = new();

            HttpClient client = UIHelper.Initial();
            // Calling service API
            try
            {
                HttpResponseMessage resNews = await client.PostAsync("api/Service/GetLogin", new StringContent(JsonConvert.SerializeObject(utils), Encoding.UTF8, "application/json"));
                if (resNews.IsSuccessStatusCode)
                {
                    var result = resNews.Content.ReadAsStringAsync().Result;
                    if (!string.IsNullOrEmpty(result))
                    {
                        loginList = JsonConvert.DeserializeObject<List<Login>>(result);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return View(loginList);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}