using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace RA.SPCore.Lib.DAL
{

    
    public class Login
    {
        
        public static List<BE.Login> Authenticate(string searchText,String connStr)
        {

            //ConnectionStringSettingsCollection strs = ConfigurationManager.ConnectionStrings;
            //var val = strs.CurrentConfiguration;
            //var connectionStr = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            //string connectionStr = _configuration["ConnectionStrings:DefaultConnection"];

            SqlConnection sqlConnection = new SqlConnection(connStr);
            sqlConnection.Open();

            string query = $"select OID,id,firstName,lastName,status,email1,email2 from Login_SP where firstName LIKE '%{searchText}%' or lastName LIKE '%{searchText}%' or status LIKE '%{searchText}%' or email1 LIKE '%{searchText}%' or email2 LIKE '%{searchText}%' or id LIKE '%{searchText}%'";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            cmd.CommandType = System.Data.CommandType.Text;
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<BE.Login> list = new List<BE.Login>();
            int len = dt.Rows.Count;
            
            foreach (DataRow dr in dt.Rows)
            {
                BE.Login login = new BE.Login();
                login.OID = dr[0].ToString();
                login.Username = dr[1].ToString();
                login.FirstName = dr[2].ToString();
                login.LastName = dr[3].ToString();
                login.Status = dr[4].ToString();
                login.EmailOne = dr[5].ToString();
                login.EmailTwo = dr[6].ToString();

                list.Add(login);
            }
            return list;
            //return new List<BE.Login>()
            //{
            //    new BE.Login { OID="1", Name = "Prime", Email = "prime@gmail.com"},
            //    new BE.Login { OID="2", Name = "Prime2", Email = "prime2@gmail.com"},
            //    new BE.Login { OID="3", Name = "Prime3", Email = "prime3@gmail.com"}
            //};

        }


    }
}