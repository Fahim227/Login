using Microsoft.AspNetCore.Mvc;
using RA.SPCore.Lib.BE;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RA.SPCore.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ServiceController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public bool CheckRequestHeader()
        {
            return Utilities.RequestData.CheckRequestHeader(HttpContext);
        }

        // All action should be Post.
        // POST: api/Service/GetLogin
        [HttpPost("GetLogin")]
        public List<Login> GetLogin(CommonUtils utils)
        {
            List<Login> loginList = new List<Login>();
            if (!CheckRequestHeader())
            {
                return loginList;
            }
            string constr = _configuration["ConnectionStrings:DefaultConnection"];
            loginList = Lib.BLL.Login.Authenticate(utils.Text,constr );
            return loginList;

        }


    }
}
