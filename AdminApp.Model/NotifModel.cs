using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.Model
{
    public class NotifModel
    {
        public int id { get; set; }        
        public string notificationMessage { get; set; }
        public int notifCount { get; set; }
    }
}
