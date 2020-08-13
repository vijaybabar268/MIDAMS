using System.Web.Mvc;

namespace MIDAMS.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.RemoveAll();

            var baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority;
            var url = baseUrl + "/Account/Login";
            return Redirect(url);
        }               
    }
}