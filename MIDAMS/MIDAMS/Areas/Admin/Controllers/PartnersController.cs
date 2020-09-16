using MIDAMS.Areas.Admin.Repositories;
using MIDAMS.Areas.Admin.ViewModels;
using MIDAMS.Models;
using System;
using System.Linq;
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
            var partners = _repo.GetPartners2()                            
                            .ToList();

            var viewModel = new PartnerViewModel
            {
                Partners = partners,
                EducationQualifications = ManageDependancyData.GetEducationQualification(),
                Designations = ManageDependancyData.GetDesignations(),
                MaritalStatus = ManageDependancyData.GetMaritalStatus(),
                Genders = ManageDependancyData.GetGenders(),
            };

            return View(viewModel);
        }

        public ActionResult New()
        {
            var viewModel = new PartnerFormViewModel()
            {
                Id = 0,
                EducationQualifications = ManageDependancyData.GetEducationQualification(),
                Designations = ManageDependancyData.GetDesignations(),
                MaritalStatus = ManageDependancyData.GetMaritalStatus(),
                Genders = ManageDependancyData.GetGenders(),
                UserId = 0
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

                // Insert partner more information
                var partnerinfo = new Partner
                {
                    FirstName = viewModel.FirstName,
                    MiddleName = viewModel.MiddleName,
                    LastName = viewModel.LastName,
                    MotherName = viewModel.MotherName,
                    EducationQualificationId = viewModel.EducationQualificationId,
                    DesignationId = viewModel.DesignationId,
                    MaritalStatusId = viewModel.MaritalStatusId,
                    GenderId = viewModel.GenderId,
                    EmailId = viewModel.Email,
                    DateOfBirth = (DateTime)viewModel.DateOfBirth,
                    DateOfJoining = (DateTime)viewModel.DateOfJoining,
                    PresentAddress = viewModel.PresentAddress,
                    PermanentAddress = viewModel.PermanentAddress,
                    MobileNumber = viewModel.MobileNumber,
                    TelNumber = viewModel.TelNumber,
                    IndetificationMarkOnBody = viewModel.IndetificationMarkOnBody,
                    Remarks = viewModel.Remark,
                    UserId = id,
                    IsActive = true,
                    CreatedOn = DateTime.Now
                };

                _repo.AddPartner2(partnerinfo);
            }
            else
            {
                var partnerInDb = _repo.GetPartner(viewModel.Id);
                var partnerInDb2 = _repo.GetPartner2(viewModel.Id);

                if (partnerInDb == null)
                {
                    ModelState.AddModelError("", "Something went wrong.");
                    return View("AdminForm", viewModel);
                }

                partnerInDb.UserName = viewModel.UserName;
                partnerInDb.Email = viewModel.Email;
                partnerInDb.Password = viewModel.Password;

                partnerInDb2.FirstName = viewModel.FirstName;
                partnerInDb2.MiddleName = viewModel.MiddleName;
                partnerInDb2.LastName = viewModel.LastName;
                partnerInDb2.MotherName = viewModel.MotherName;
                partnerInDb2.EducationQualificationId = viewModel.EducationQualificationId;
                partnerInDb2.DesignationId = viewModel.DesignationId;
                partnerInDb2.MaritalStatusId = viewModel.MaritalStatusId;
                partnerInDb2.GenderId = viewModel.GenderId;
                partnerInDb2.EmailId = viewModel.EmailId;
                partnerInDb2.DateOfBirth = (DateTime)viewModel.DateOfBirth;
                partnerInDb2.DateOfJoining = (DateTime)viewModel.DateOfJoining;
                partnerInDb2.PresentAddress = viewModel.PresentAddress;
                partnerInDb2.PermanentAddress = viewModel.PermanentAddress;
                partnerInDb2.MobileNumber = viewModel.MobileNumber;
                partnerInDb2.TelNumber = viewModel.TelNumber;
                partnerInDb2.IndetificationMarkOnBody = viewModel.IndetificationMarkOnBody;
                partnerInDb2.Remarks = viewModel.Remark;

                _repo.UpdatePartner(partnerInDb);
                _repo.UpdatePartner2(partnerInDb2);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var partnerInDb = _repo.GetPartner(id);
            var partnerInDb2 = _repo.GetPartner2(id);

            var viewModel = new PartnerFormViewModel()
            {
                Id = partnerInDb.Id,
                EducationQualifications = ManageDependancyData.GetEducationQualification(),
                Designations = ManageDependancyData.GetDesignations(),
                MaritalStatus = ManageDependancyData.GetMaritalStatus(),
                Genders = ManageDependancyData.GetGenders(),
                UserName = partnerInDb.UserName,
                Email = partnerInDb.Email,
                Password = partnerInDb.Password,
                UserId = partnerInDb2.UserId,
                PartnerId = partnerInDb2.Id,
                FirstName = partnerInDb2.FirstName,
                MiddleName = partnerInDb2.MiddleName,
                LastName = partnerInDb2.LastName,
                MotherName = partnerInDb2.MotherName,
                EducationQualificationId = partnerInDb2.EducationQualificationId,
                DesignationId = partnerInDb2.DesignationId,
                MaritalStatusId = partnerInDb2.MaritalStatusId,
                GenderId = partnerInDb2.GenderId,
                EmailId = partnerInDb2.EmailId,
                DateOfBirth = (DateTime)partnerInDb2.DateOfBirth,
                DateOfJoining = (DateTime)partnerInDb2.DateOfJoining,
                PresentAddress = partnerInDb2.PresentAddress,
                PermanentAddress = partnerInDb2.PermanentAddress,
                MobileNumber = partnerInDb2.MobileNumber,
                TelNumber = partnerInDb2.TelNumber,
                IndetificationMarkOnBody = partnerInDb2.IndetificationMarkOnBody,
                Remark = partnerInDb2.Remarks
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
            var partnerInDb2 = _repo.GetPartner2(id);

            if (partnerInDb.IsActive)
                partnerInDb.IsActive = false;
            else
                partnerInDb.IsActive = true;

            _repo.UpdatePartner(partnerInDb);


            if (partnerInDb2.IsActive)
                partnerInDb2.IsActive = false;
            else
                partnerInDb2.IsActive = true;

            _repo.UpdatePartner2(partnerInDb2);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _repo.RemovePartner2(_repo.GetPartner2(id));

            _repo.RemovePartner(_repo.GetPartner(id));

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            User partnerinDb = _repo.GetPartner(id);
            Partner partnerinDb2  = _repo.GetPartner2(id);

            PartnerDetailsViewModel partnerDetailsViewModel = new PartnerDetailsViewModel()
            {
                UserName = partnerinDb.UserName,
                Email = partnerinDb.Email,
                Password = partnerinDb.Password,

                EducationQualifications = ManageDependancyData.GetEducationQualification(),
                Designations = ManageDependancyData.GetDesignations(),
                MaritalStatus = ManageDependancyData.GetMaritalStatus(),
                Genders = ManageDependancyData.GetGenders(),

                FirstName = partnerinDb2.FirstName,
                MiddleName = partnerinDb2.MiddleName,
                LastName = partnerinDb2.LastName,
                MotherName = partnerinDb2.MotherName,
                EducationQualificationId = partnerinDb2.EducationQualificationId,
                DesignationId = partnerinDb2.DesignationId,
                MaritalStatusId = partnerinDb2.MaritalStatusId,
                GenderId = partnerinDb2.GenderId,
                EmailId = partnerinDb2.EmailId,
                DateOfBirth = (DateTime)partnerinDb2.DateOfBirth,
                DateOfJoining = (DateTime)partnerinDb2.DateOfJoining,
                PresentAddress = partnerinDb2.PresentAddress,
                PermanentAddress = partnerinDb2.PermanentAddress,
                MobileNumber = partnerinDb2.MobileNumber,
                TelNumber = partnerinDb2.TelNumber,
                IndetificationMarkOnBody = partnerinDb2.IndetificationMarkOnBody,
                Remark = partnerinDb2.Remarks,                
                IsActive = true,
                CreatedOn = DateTime.Now
            };

            return View("Details", partnerDetailsViewModel);
        }


        // Partner Document Details
        public ActionResult DocumentDetail(int id)
        {
            var DocumentDetails = _repo.GetDocumentDetails().Where(c => c.PartnerId == id).ToList();
            var PartnerInfo = _repo.GetPartner3(id);

            var viewModel = new DocumentDetailViewModel()
            {
                PartnerDocumentDetails = DocumentDetails,
                PartnerId = PartnerInfo.Id,
                PartnerName = string.Format("{0} {1} {2}", PartnerInfo.FirstName, PartnerInfo.MiddleName, PartnerInfo.LastName),
            };

            return View("DocumentDetail", viewModel);
        }

        public ActionResult AddDocumentDetail(int partnerId)
        {
            var viewModel = new DocumentDetailFormViewModel()
            {
                Id = 0,                
                PartnerId = partnerId
            };

            return View("DocumentDetailForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveDocumentDetail(DocumentDetailFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("DocumentDetailForm", viewModel);
            }

            if (viewModel.Id == 0)
            {
                var documentDetail = new PartnerDocumentDetail
                {
                    AdharNo = viewModel.AdharNo,
                    AdharName = viewModel.AdharName,
                    AdharDateOfBirth = viewModel.AdharDateOfBirth,
                    AdharAddress = viewModel.AdharAddress,
                    PanNo = viewModel.PanNo,
                    PanName = viewModel.PanName,
                    PanFatherName = viewModel.PanFatherName,
                    PanDateOfBirth = viewModel.PanDateOfBirth,
                    PartnerId = viewModel.PartnerId
                };

                _repo.AddDocumentDetail(documentDetail);
            }
            else
            {
                var DocumentDetailInDb = _repo.GetDocumentDetail(viewModel.Id);

                if (DocumentDetailInDb == null)
                {
                    ModelState.AddModelError("", "Something went wrong.");
                    return View("DocumentDetailForm", viewModel);
                }

                DocumentDetailInDb.AdharNo = viewModel.AdharNo;
                DocumentDetailInDb.AdharName = viewModel.AdharName;
                DocumentDetailInDb.AdharDateOfBirth = viewModel.AdharDateOfBirth;
                DocumentDetailInDb.AdharAddress = viewModel.AdharAddress;
                DocumentDetailInDb.PanNo = viewModel.PanNo;
                DocumentDetailInDb.PanName = viewModel.PanName;
                DocumentDetailInDb.PanFatherName = viewModel.PanFatherName;
                DocumentDetailInDb.PanDateOfBirth = viewModel.PanDateOfBirth;
                DocumentDetailInDb.PartnerId = viewModel.PartnerId;

                _repo.UpdateDocumentDetail(DocumentDetailInDb);
            }

            return RedirectToAction("DocumentDetail", "Partners", new { id = viewModel.PartnerId });
        }

        public ActionResult EditDocumentDetail(int id)
        {
            var documentDetailsInDb = _repo.GetDocumentDetail(id);

            var viewModel = new DocumentDetailFormViewModel()
            {
                AdharNo = documentDetailsInDb.AdharNo,
                AdharName = documentDetailsInDb.AdharName,
                AdharDateOfBirth = documentDetailsInDb.AdharDateOfBirth,
                AdharAddress = documentDetailsInDb.AdharAddress,
                PanNo = documentDetailsInDb.PanNo,
                PanName = documentDetailsInDb.PanName,
                PanFatherName = documentDetailsInDb.PanFatherName,
                PanDateOfBirth = documentDetailsInDb.PanDateOfBirth,
                PartnerId = documentDetailsInDb.PartnerId
            };

            if (documentDetailsInDb == null)
            {
                ModelState.AddModelError("", "Something went wrong.");
                return View("DocumentDetailForm", viewModel);
            }

            return View("DocumentDetailForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDocumentDetail(int DocumentDetailId, int PartnerId)
        {
            var documentDetail = _repo.GetDocumentDetail(DocumentDetailId);

            _repo.RemoveDocumentDetail(documentDetail);

            return RedirectToAction("DocumentDetail", "Partners", new { id = PartnerId });
        }

        public ActionResult ViewDocumentDetail(int id)
        {
            var documentDetailsInDb = _repo.GetDocumentDetail(id);

            var viewModel = new ViewDocumentDetailViewModel()
            {
                AdharNo = documentDetailsInDb.AdharNo,
                AdharName = documentDetailsInDb.AdharName,
                AdharDateOfBirth = documentDetailsInDb.AdharDateOfBirth,
                AdharAddress = documentDetailsInDb.AdharAddress,
                PanNo = documentDetailsInDb.PanNo,
                PanName = documentDetailsInDb.PanName,
                PanFatherName = documentDetailsInDb.PanFatherName,
                PanDateOfBirth = documentDetailsInDb.PanDateOfBirth,
                PartnerId = documentDetailsInDb.PartnerId
            };
                        
            return View("viewDocumentDetail", viewModel);
        }

        // Partner Bank Details

    }
}