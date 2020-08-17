using MIDAMS.Areas.Admin.Repositories;
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
        private readonly ClientRepository _repo;        

        public ClientsController()
        {
            _repo = new ClientRepository();
        }

        public ActionResult Index()
        {
            var viewModel = new ClientViewModel()
            {
                Clients = _repo.GetClients(),
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

                _repo.AddClient(client);                
            }
            else
            {
                var clientInDb = _repo.GetClient(viewModel.Id);

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

                _repo.UpdateClient(clientInDb);
            }
                                    
            return RedirectToAction("Index", "Clients");
        }

        public ActionResult Edit(int id)
        {
            var clientInDb = _repo.GetClient(id);

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
            var clientInDb = _repo.GetClient(id);

            if (clientInDb.IsActive)
                clientInDb.IsActive = false;
            else
                clientInDb.IsActive = true;

            _repo.UpdateClient(clientInDb);
            
            return RedirectToAction("Index", "Clients");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _repo.RemoveClient(_repo.GetClient(id));

            return RedirectToAction("Index", "Clients");
        }

        // Role & Responsibility
        public ActionResult RoleAndResponsibility(int id)
        {
            var rolesResponsibilities = _repo.GetClientRoleResponsibilities().Where(c => c.ClientId == id).ToList();

            var viewModel = new RoleResponsibilityViewModel()
            {
                ClientRoleResponsibilities = rolesResponsibilities,
                ClientId = _repo.GetClient(id).Id,
                ClientName = _repo.GetClient(id).ClientName,
                Hos = ManageDependancyData.GetRoleResponsibilities(),
                Sites = ManageDependancyData.GetRoleResponsibilities()
            };
                        
            return View("RoleAndResponsibility", viewModel);
        }

        public ActionResult AddRoleAndResponsibility(int ClientId)
        {   
            var viewModel = new ClientRoleResponsibilityFormViewModel()
            { 
                Id = 0,
                Hos = ManageDependancyData.GetRoleResponsibilities(),
                Sites = ManageDependancyData.GetRoleResponsibilities(),
                ClientId = ClientId
            };
        
            return View("RoleAndResponsibilityForm", viewModel);        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveRoleAndResponsibility(ClientRoleResponsibilityFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("RoleAndResponsibilityForm", viewModel);
            }

            if (viewModel.Id == 0)
            {
                var clientRoleResponsibility = new ClientRoleResponsibility
                {
                    HoId = viewModel.HoId,
                    SiteId = viewModel.SiteId,
                    ClientId = viewModel.ClientId                                        
                };

                _repo.AddClientRoleResponsibility(clientRoleResponsibility);
            }
            else
            {
                var clientRoleResponsibilityInDb = _repo.GetClientRoleResponsibility(viewModel.Id);

                if (clientRoleResponsibilityInDb == null)
                {
                    ModelState.AddModelError("", "Something went wrong.");
                    return View("ClientForm", viewModel);
                }

                clientRoleResponsibilityInDb.HoId = viewModel.HoId;
                clientRoleResponsibilityInDb.SiteId = viewModel.SiteId;
                clientRoleResponsibilityInDb.ClientId = viewModel.ClientId;

                _repo.UpdateClientRoleResponsibility(clientRoleResponsibilityInDb);
            }

            return RedirectToAction("RoleAndResponsibility", "Clients", new { id = viewModel.ClientId });
        }

        public ActionResult EditRoleAndResponsibility(int id)
        {
            var clientRoleResponsibilityInDb = _repo.GetClientRoleResponsibility(id);

            var viewModel = new ClientRoleResponsibilityFormViewModel()
            {
                Id = clientRoleResponsibilityInDb.Id,
                HoId = clientRoleResponsibilityInDb.HoId,
                SiteId = clientRoleResponsibilityInDb.SiteId,
                ClientId = clientRoleResponsibilityInDb.ClientId,
                Hos = ManageDependancyData.GetRoleResponsibilities(),
                Sites = ManageDependancyData.GetRoleResponsibilities()
            };

            if (clientRoleResponsibilityInDb == null)
            {
                ModelState.AddModelError("", "Something went wrong.");
                return View("RoleAndResponsibilityForm", viewModel);
            }

            return View("RoleAndResponsibilityForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleAndResponsibility(int RoleResponsilinityId, int ClientId)
        {
            var client = _repo.GetClientRoleResponsibility(RoleResponsilinityId);

            _repo.RemoveClientRoleResponsibility(client);

            return RedirectToAction("RoleAndResponsibility", "Clients", new { id = ClientId });
        }

        // Manage Contact Details


        // Manage Relations
    }
}