using MIDAMS.Areas.Admin.Repositories;
using MIDAMS.Areas.Admin.ViewModels;
using MIDAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MIDAMS.Areas.Admin.ViewModels.PartnerFormViewModel;

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

                // Newly insert record id.
                var id = _repo.GetPartnerByEmail(viewModel.Email.ToLower().Trim()).Id;

                return RedirectToAction("Save2", new { TempId = id });
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

        public ActionResult Save2(string TempId)
        {
            var viewModel = new PartnerFormViewModel2()
            {
                Id = 0,
                EducationQualifications = ManageDependancyData.GetEducationQualification(),
                Designations = ManageDependancyData.GetDesignations(),
                MaritalStatus = ManageDependancyData.GetMaritalStatus(),
                Genders = ManageDependancyData.GetGenders(),
                UserId = int.Parse(TempId)
            };

            return View("PartnerForm2", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save2(PartnerFormViewModel2 viewModel)
        {
            if (viewModel.Id == 0)
            {
                var partner = new Partner
                {
                    FirstName = viewModel.FirstName,
                    MiddleName = viewModel.MiddleName,
                    LastName = viewModel.LastName,
                    MotherName = viewModel.MotherName,
                    EducationQualificationId = viewModel.EducationQualificationId,
                    DesignationId = viewModel.DesignationId,
                    MaritalStatusId = viewModel.MaritalStatusId,
                    GenderId = viewModel.GenderId,
                    EmailId = viewModel.EmailId,
                    DateOfBirth = (DateTime)viewModel.DateOfBirth,
                    DateOfJoining = (DateTime)viewModel.DateOfJoining,
                    PresentAddress = viewModel.PresentAddress,
                    PermanentAddress = viewModel.PermanentAddress,
                    MobileNumber = viewModel.MobileNumber,
                    TelNumber = viewModel.TelNumber,
                    IndetificationMarkOnBody = viewModel.IndetificationMarkOnBody,                    
                    Remarks = viewModel.Remark,
                    UserId = viewModel.UserId
                };

                _repo.AddPartner2(partner);
            }
            else
            {
                /*var employeeInDb = _repo.GetEmployee(viewModel.Id);

                if (employeeInDb == null)
                {
                    ModelState.AddModelError("", "Something went wrong.");
                    return View("EmployeeForm", viewModel);
                }

                employeeInDb.FirstName = viewModel.FirstName;
                employeeInDb.MiddleName = viewModel.MiddleName;
                employeeInDb.LastName = viewModel.LastName;
                employeeInDb.MotherName = viewModel.MotherName;
                employeeInDb.EducationQualificationId = viewModel.EducationQualificationId;
                employeeInDb.DesignationId = viewModel.DesignationId;
                employeeInDb.MaritalStatusId = viewModel.MaritalStatusId;
                employeeInDb.GenderId = viewModel.GenderId;
                employeeInDb.EmailId = viewModel.EmailId;
                employeeInDb.DateOfBirth = (DateTime)viewModel.DateOfBirth;
                employeeInDb.DateOfJoining = (DateTime)viewModel.DateOfJoining;
                employeeInDb.PresentAddress = viewModel.PresentAddress;
                employeeInDb.PermanentAddress = viewModel.PermanentAddress;
                employeeInDb.MobileNumber = viewModel.MobileNumber;
                employeeInDb.TelNumber = viewModel.TelNumber;
                employeeInDb.IndetificationMarkOnBody = viewModel.IndetificationMarkOnBody;
                employeeInDb.NameAndContactReference1 = viewModel.NameAndContactReference1;
                employeeInDb.NameAndContactReference2 = viewModel.NameAndContactReference2;
                employeeInDb.Photo = viewModel.Photo;

                _repo.UpdateEmployee(employeeInDb);*/
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