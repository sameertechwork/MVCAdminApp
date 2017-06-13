using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace AdminApp.Common
{
    public static class AppSettings
    {
        public static string ReadKey(string Key)
        {
            string KeyValue = "";

            try
            {
                KeyValue = WebConfigurationManager.AppSettings[Key].ToString();
            }
            catch (Exception expc)
            {
                Common.ErrorLog.WriteLog(expc);
            }

            return KeyValue;

        }
    }
}
