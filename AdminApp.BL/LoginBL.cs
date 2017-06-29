using System;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminApp.Model;
using AdminApp.DAO;

namespace AdminApp.BL
{
    public class LoginBL : BaseDAL
    {
        // Login lg = new Login();

        public LoginModel LoginUser(string username, string password)
        {
            using (IDbConnection con = OpenConnection())
            {
                var obj = con.Query<LoginModel>("select UserTypeId,Username,Password from loginuser where Username ='" + username + "' and Password = '" + password + "'").FirstOrDefault();
                return obj;
            }
        }
    }
}
