namespace RA.SPCore.Lib.BLL
{
    public class Login
    {
        public static List<BE.Login> GetLogin(string searchText, string constr)
        {
            return Lib.DAL.Login.GetLogin(searchText,constr);
        }

    }
}