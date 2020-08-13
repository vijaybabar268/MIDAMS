using MIDAMS.Areas.Admin.ViewModels;
using MIDAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MIDAMS.Models.ManageDependancyData;

namespace MIDAMS.Areas.Admin.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var viewModel = new ClientViewModel()
            {
                Clients = _context.Clients.ToList(),
                Regions = ManageDependancyData.GetRegions(),
                BranchLocations = ManageDependancyData.GetBranchLocations(),
                IndustryTypes = ManageDependancyData.GetIndustryTypes()
            };

            return View(viewModel);
        }

        public ActionResult New()
        {            
            var viewModel = new ClientFormViewModel()
            {
                Regions = ManageDependancyData.GetRegions(),
                BranchLocations = ManageDependancyData.GetBranchLocations(),
                IndustryTypes = ManageDependancyData.GetIndustryTypes()
            };
        
            return View("ClientForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ClientFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("ClientForm", viewModel);
            }

            if (viewModel.Id == 0)
            {
                var client = new Client
                {
                    ClientName = viewModel.ClientName,
                    RegionId = viewModel.RegionId,
                    BranchLocationId = viewModel.BranchLocationId,
                    IndustryTypeId = viewModel.IndustryTypeId,
                    SiteAddress = viewModel.SiteAddress,
                    CorpOfficeAddress = viewModel.CorpOfficeAddress,
                    CreatedOn = DateTime.Now,
                    IsActive = true
                };

                _context.Clients.Add(client);
            }
            else
            {
                var clientInDb = _context.Clients.SingleOrDefault(a => a.Id == viewModel.Id);

                if (clientInDb == null)
                {
                    ModelState.AddModelError("", "Something went wrong.");
                    return View("ClientForm", viewModel);
                }

                clientInDb.ClientName = viewModel.ClientName;
                clientInDb.RegionId = viewModel.RegionId;
                clientInDb.BranchLocationId = viewModel.BranchLocationId;
                clientInDb.IndustryTypeId = viewModel.IndustryTypeId;
                clientInDb.SiteAddress = viewModel.SiteAddress;
                clientInDb.CorpOfficeAddress = viewModel.CorpOfficeAddress;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Clients");
        }

        public ActionResult Edit(int id)
        {
            var clientInDb = _context.Clients.FirstOrDefault(a => a.Id == id);

            var viewModel = new ClientFormViewModel()
            {
                Regions = ManageDependancyData.GetRegions(),
                BranchLocations = ManageDependancyData.GetBranchLocations(),
                IndustryTypes = ManageDependancyData.GetIndustryTypes(),
                ClientName = clientInDb.ClientName,
                RegionId = clientInDb.RegionId,
                BranchLocationId = clientInDb.BranchLocationId,
                IndustryTypeId = clientInDb.IndustryTypeId,
                SiteAddress = clientInDb.SiteAddress,
                CorpOfficeAddress = clientInDb.CorpOfficeAddress,
                Id = clientInDb.Id
            };

            if (clientInDb == null)
            {
                ModelState.AddModelError("", "Something went wrong.");
                return View("ClientForm", viewModel);
            }

            return View("ClientForm", viewModel);
        }

        public ActionResult ToggleStatus(int id)
        {
            var clientInDb = _context.Clients.Find(id);

            if (clientInDb.IsActive)
                clientInDb.IsActive = false;
            else
                clientInDb.IsActive = true;

            _context.SaveChanges();

            return RedirectToAction("Index", "Clients");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var clientInDb = _context.Clients.Find(id);

            _context.Clients.Remove(clientInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Clients");
        }
    }
}