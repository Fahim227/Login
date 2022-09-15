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
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
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
            string url = _configuration["base_url"];
            string token_key = _configuration["header_token:tokenOne:key"];
            string token_value = _configuration["header_token:tokenOne:value"];
            HttpClient client = UIHelper.Initial(url, token_key, token_value);
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



        public IActionResult Home2()
        {
            return View();
        }

        [HttpPost]
        public async Task<List<Login>> getData([FromBody] CommonUtils search)
        {
            // Parameters send to the api using CommonUtils model
            CommonUtils utils = new CommonUtils();
            utils.Text = search.Text;

            List<Login> loginList = new List<Login>();

            string url = _configuration["base_url"];
            string token_key = _configuration["header_token:tokenOne:key"];
            string token_value = _configuration["header_token:tokenOne:value"];
            HttpClient client = UIHelper.Initial(url,token_key,token_value);
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

            return loginList;

        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}