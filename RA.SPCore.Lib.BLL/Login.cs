namespace RA.SPCore.Lib.BLL
{
    public class Login
    {
        public static List<BE.Login> Authenticate(string searchText, string constr)
        {
            return Lib.DAL.Login.Authenticate(searchText,constr);
        }

    }
}