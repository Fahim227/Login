namespace RA.SPCore.Web.UI.Utilities
{
    public class UIHelper
    {
        public static HttpClient Initial(string url,string key,string value)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);

            client.DefaultRequestHeaders.Add(key, value);
            return client;
        }
    }
}
