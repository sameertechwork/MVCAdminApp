using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminApp.Model;
using AdminApp.BL;

namespace AdminApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ShowNotifCount()
        {
            try
            {
                LayoutBL objCount = new LayoutBL();

                var jsonData = new
                {
                    dataCount = objCount.NotifCount()
                };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
