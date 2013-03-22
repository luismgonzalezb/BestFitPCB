using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BestFitPCBWeb.Models;

namespace BestFitPCBWeb.Controllers
{

    public class DashboardController : BaseController
    {

        public ActionResult Index(string returnUrl)
        {
            return View();
        }


    }
}
