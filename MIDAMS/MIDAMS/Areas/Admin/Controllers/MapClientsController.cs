using MIDAMS.Areas.Admin.Repositories;
using MIDAMS.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIDAMS.Areas.Admin.Controllers
{
    public class MapClientsController : Controller
    {
        private readonly MapClientsRepository _repo;

        public MapClientsController()
        {
            _repo = new MapClientsRepository();
        }
                
        public ActionResult Index()
        {
            var viewModel = new MapClientsViewModel()
            {
                MapClientsToPartners = _repo.GetMapClientsToPartners().ToList()
            };

            return View(viewModel);
        }
    }
}