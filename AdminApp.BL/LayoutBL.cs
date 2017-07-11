using Dapper;
using AdminApp.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminApp.Model;
using System.Data;

namespace AdminApp.BL
{
    public class LayoutBL : BaseDAL
    {
        public NotifModel NotifCount()
        {
            using (IDbConnection con = OpenConnection())
            {
                var obj = con.Query<NotifModel>("select count(id) as notifCount from tblNotification ").FirstOrDefault();
                return obj;
            }
        }
    }   
}
