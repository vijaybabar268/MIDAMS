using MIDAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIDAMS.Areas.Admin.Controllers
{
    [Authorize(Roles =RoleName.Admin)]
    public class DashboardController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }
    }
}