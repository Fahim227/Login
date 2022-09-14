namespace RA.SPCore.Web.UI.Utilities
{
    public class UIHelper
    {
        public static HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7066/");

            client.DefaultRequestHeaders.Add("RA_Token", "1234");
            return client;
        }
    }
}
