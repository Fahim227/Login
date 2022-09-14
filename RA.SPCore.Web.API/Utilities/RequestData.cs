namespace RA.SPCore.Web.API.Utilities
{
    public class RequestData
    {
        public static bool CheckRequestHeader(Microsoft.AspNetCore.Http.HttpContext currentContext)
        {

            bool isValid;

            string token = currentContext.Request.Headers["RA_Token"];

            isValid = false;

            if (!String.IsNullOrEmpty(token))
            {
                if (token == "1234")
                {
                    isValid = true;
                }
            }
            return isValid;
        }

    }
}
