using MIDAMS.Areas.Admin.Repositories;
using MIDAMS.Areas.Admin.ViewModels;
using MIDAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIDAMS.Areas.Admin.Controllers
{
    public class PartnersController : Controller
    {
        private readonly PartnerRepositry _repo;

        public PartnersController()
        {
            _repo = new PartnerRepositry();
        }

        public ActionResult Index()
        {
            var partners = _repo.GetPartners()
                            .Where(r => r.RoleId == 3)
                            .ToList();

            return View(partners);
        }

        public ActionResult New()
        {
            var viewModel = new PartnerFormViewModel()
            {

            };

            return View("PartnerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PartnerFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("PartnerForm", viewModel);
            }

            if (viewModel.Id == 0)
            {
                var partner = new User
                {
                    UserName = viewModel.UserName,
                    Email = viewModel.Email,
                    Password = viewModel.Password,
                    RoleId = 3,
                    IsActive = true
                };

                _repo.AddPartner(partner);
            }
            else
            {
                var partnerInDb = _repo.GetPartner(viewModel.Id);

                if (partnerInDb == null)
                {
                    ModelState.AddModelError("", "Something went wrong.");
                    return View("AdminForm", viewModel);
                }

                partnerInDb.UserName = viewModel.UserName;
                partnerInDb.Email = viewModel.Email;
                partnerInDb.Password = viewModel.Password;

                _repo.UpdatePartner(partnerInDb);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var partnerInDb = _repo.GetPartner(id);

            var viewModel = new PartnerFormViewModel()
            {
                Id = partnerInDb.Id,
                UserName = partnerInDb.UserName,
                Email = partnerInDb.Email
            };

            if (partnerInDb == null)
            {
                ModelState.AddModelError("", "Something went wrong.");
                return View("PartnerForm", viewModel);
            }

            return View("PartnerForm", viewModel);
        }


        public ActionResult ToggleStatus(int id)
        {
            var partnerInDb = _repo.GetPartner(id);

            if (partnerInDb.IsActive)
                partnerInDb.IsActive = false;
            else
                partnerInDb.IsActive = true;

            _repo.UpdatePartner(partnerInDb);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _repo.RemovePartner(_repo.GetPartner(id));

            return RedirectToAction("Index");
        }
    }
}