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
            Partner partnerinDb2 = _repo.GetPartner2(id);

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
        public ActionResult BankDetail(int id)
        {
            var bankDetails = _repo.GetBankDetails().Where(c => c.PartnerId == id).ToList();
            var PartnerInfo = _repo.GetPartner3(id);

            var viewModel = new BankDetailsViewModel()
            {
                PartnerBankDetails = bankDetails,
                PartnerId = PartnerInfo.Id,
                PartnerName = string.Format("{0} {1} {2}", PartnerInfo.FirstName, PartnerInfo.MiddleName, PartnerInfo.LastName),
            };

            return View("BankDetail", viewModel);
        }

        public ActionResult AddBankDetail(int partnerId)
        {
            var viewModel = new BankDetailsFormViewModel()
            {
                Id = 0,
                PartnerId = partnerId
            };

            return View("BankDetailForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveBankDetail(BankDetailsFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("BankDetailForm", viewModel);
            }

            if (viewModel.Id == 0)
            {
                var bankDetail = new PartnerBankDetail
                {
                    AccountNo = viewModel.AccountNo,
                    BankName = viewModel.BankName,
                    IFSCCode = viewModel.IFSCCode,
                    BranchName = viewModel.BranchName,
                    NameOfAccountHolder1 = viewModel.NameOfAccountHolder1,
                    NameOfAccountHolder2 = viewModel.NameOfAccountHolder2,
                    PartnerId = viewModel.PartnerId
                };

                _repo.AddBankDetail(bankDetail);
            }
            else
            {
                var bankDetailInDb = _repo.GetBankDetail(viewModel.Id);

                if (bankDetailInDb == null)
                {
                    ModelState.AddModelError("", "Something went wrong.");
                    return View("BankDetailForm", viewModel);
                }

                bankDetailInDb.AccountNo = viewModel.AccountNo;
                bankDetailInDb.BankName = viewModel.BankName;
                bankDetailInDb.IFSCCode = viewModel.IFSCCode;
                bankDetailInDb.BranchName = viewModel.BranchName;
                bankDetailInDb.NameOfAccountHolder1 = viewModel.NameOfAccountHolder1;
                bankDetailInDb.NameOfAccountHolder2 = viewModel.NameOfAccountHolder2;
                bankDetailInDb.PartnerId = viewModel.PartnerId;

                _repo.UpdateBankDetail(bankDetailInDb);
            }

            return RedirectToAction("BankDetail", "Partners", new { id = viewModel.PartnerId });
        }

        public ActionResult EditBankDetail(int id)
        {
            var bankDetailsInDb = _repo.GetBankDetail(id);

            var viewModel = new BankDetailsFormViewModel()
            {
                AccountNo = bankDetailsInDb.AccountNo,
                BankName = bankDetailsInDb.BankName,
                IFSCCode = bankDetailsInDb.IFSCCode,
                BranchName = bankDetailsInDb.BranchName,
                NameOfAccountHolder1 = bankDetailsInDb.NameOfAccountHolder1,
                NameOfAccountHolder2 = bankDetailsInDb.NameOfAccountHolder2,
                PartnerId = bankDetailsInDb.PartnerId
            };

            if (bankDetailsInDb == null)
            {
                ModelState.AddModelError("", "Something went wrong.");
                return View("BankDetailForm", viewModel);
            }

            return View("BankDetailForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBankDetail(int BankDetailId, int PartnerId)
        {
            var bankDetail = _repo.GetBankDetail(BankDetailId);

            _repo.RemoveBankDetail(bankDetail);

            return RedirectToAction("BankDetail", "Partners", new { id = PartnerId });
        }

        public ActionResult ViewbankDetail(int id)
        {
            var bankDetailsInDb = _repo.GetBankDetail(id);

            var viewModel = new ViewBankDetailsViewModel()
            {
                AccountNo = bankDetailsInDb.AccountNo,
                BankName = bankDetailsInDb.BankName,
                IFSCCode = bankDetailsInDb.IFSCCode,
                BranchName = bankDetailsInDb.BranchName,
                NameOfAccountHolder1 = bankDetailsInDb.NameOfAccountHolder1,
                NameOfAccountHolder2 = bankDetailsInDb.NameOfAccountHolder2,
                PartnerId = bankDetailsInDb.PartnerId
            };

            return View("ViewBankDetail", viewModel);
        }

        // Partner Responsible Site
        public ActionResult ResponsibleSite(int id)
        {
            var responsibleSites = _repo.GetResponsibleSites().Where(c => c.PartnerId == id).ToList();
            var PartnerInfo = _repo.GetPartner3(id);

            var viewModel = new ResponsibleSiteViewModel()
            {
                PartnerResponsibleSites = responsibleSites,
                PartnerId = PartnerInfo.Id,
                PartnerName = string.Format("{0} {1} {2}", PartnerInfo.FirstName, PartnerInfo.MiddleName, PartnerInfo.LastName),
            };

            return View("ResponsibleSite", viewModel);
        }

        public ActionResult AddResponsibleSite(int partnerId)
        {
            var viewModel = new ResponsibleSiteFormViewModel()
            {
                Id = 0,
                PartnerId = partnerId
            };

            return View("ResponsibleSiteForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveResponsibleSite(ResponsibleSiteFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("ResponsibleSiteForm", viewModel);
            }

            if (viewModel.Id == 0)
            {
                var partnerResponsibleSite = new PartnerResponsibleSite
                {
                    NameOfTheSite = viewModel.NameOfTheSite,
                    Location = viewModel.Location,
                    SiteCode = viewModel.SiteCode,
                    StartDateOfSite = viewModel.StartDateOfSite,
                    ManagementFeesPercentAmount = viewModel.ManagementFeesPercentAmount,
                    TotalBillingValueOfSite = viewModel.TotalBillingValueOfSite,
                    PartnerId = viewModel.PartnerId
                };

                _repo.AddResponsibleSite(partnerResponsibleSite);
            }
            else
            {
                var partnerResponsibleSiteInDb = _repo.GetResponsibleSite(viewModel.Id);

                if (partnerResponsibleSiteInDb == null)
                {
                    ModelState.AddModelError("", "Something went wrong.");
                    return View("ResponsibleSiteForm", viewModel);
                }

                partnerResponsibleSiteInDb.NameOfTheSite = viewModel.NameOfTheSite;
                partnerResponsibleSiteInDb.Location = viewModel.Location;
                partnerResponsibleSiteInDb.SiteCode = viewModel.SiteCode;
                partnerResponsibleSiteInDb.StartDateOfSite = viewModel.StartDateOfSite;
                partnerResponsibleSiteInDb.ManagementFeesPercentAmount = viewModel.ManagementFeesPercentAmount;
                partnerResponsibleSiteInDb.TotalBillingValueOfSite = viewModel.TotalBillingValueOfSite;
                partnerResponsibleSiteInDb.PartnerId = viewModel.PartnerId;

                _repo.UpdateResponsibleSite(partnerResponsibleSiteInDb);
            }

            return RedirectToAction("ResponsibleSite", "Partners", new { id = viewModel.PartnerId });
        }

        public ActionResult EditResponsibleSite(int id)
        {
            var responsibleSiteInDb = _repo.GetResponsibleSite(id);

            var viewModel = new ResponsibleSiteFormViewModel()
            {
                NameOfTheSite = responsibleSiteInDb.NameOfTheSite,
                Location = responsibleSiteInDb.Location,
                SiteCode = responsibleSiteInDb.SiteCode,
                StartDateOfSite = responsibleSiteInDb.StartDateOfSite,
                ManagementFeesPercentAmount = responsibleSiteInDb.ManagementFeesPercentAmount,
                TotalBillingValueOfSite = responsibleSiteInDb.TotalBillingValueOfSite,
                PartnerId = responsibleSiteInDb.PartnerId
            };

            if (responsibleSiteInDb == null)
            {
                ModelState.AddModelError("", "Something went wrong.");
                return View("ResponsibleSiteForm", viewModel);
            }

            return View("ResponsibleSiteForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteResponsibleSite(int ResponsibleSiteId, int PartnerId)
        {
            var responsibleSiteInDb = _repo.GetResponsibleSite(ResponsibleSiteId);

            _repo.RemoveResponsibleSite(responsibleSiteInDb);

            return RedirectToAction("ResponsibleSite", "Partners", new { id = PartnerId });
        }

        public ActionResult ViewResponsibleSite(int id)
        {
            var responsibleSiteInDb = _repo.GetResponsibleSite(id);

            var viewModel = new ViewResponsibleSiteViewModel()
            {
                NameOfTheSite = responsibleSiteInDb.NameOfTheSite,
                Location = responsibleSiteInDb.Location,
                SiteCode = responsibleSiteInDb.SiteCode,
                StartDateOfSite = responsibleSiteInDb.StartDateOfSite,
                ManagementFeesPercentAmount = responsibleSiteInDb.ManagementFeesPercentAmount,
                TotalBillingValueOfSite = responsibleSiteInDb.TotalBillingValueOfSite,
                PartnerId = responsibleSiteInDb.PartnerId
            };

            return View("ViewResponsibleSite", viewModel);
        }

        // Partner Tearms and Conditions
        public ActionResult TearmsCondition(int id)
        {
            var tearmsConditions = _repo.GetTearmsConditions().Where(c => c.PartnerId == id).ToList();
            var PartnerInfo = _repo.GetPartner3(id);

            var viewModel = new TearmsConditionViewModel()
            {
                PartnerTearmsConditions = tearmsConditions,
                PartnerId = PartnerInfo.Id,
                PartnerName = string.Format("{0} {1} {2}", PartnerInfo.FirstName, PartnerInfo.MiddleName, PartnerInfo.LastName),
            };

            return View("TearmsCondition", viewModel);
        }

        public ActionResult AddTearmsCondition(int partnerId)
        {
            var viewModel = new TearmsConditionFormViewModel()
            {
                Id = 0,
                PartnerId = partnerId
            };

            return View("TearmsConditionForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveTearmsCondition(TearmsConditionFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("TearmsConditionForm", viewModel);
            }

            if (viewModel.Id == 0)
            {
                var partnerTearmsCondition = new PartnerTearmsCondition
                {
                    ProfitLossSharingPercent = viewModel.ProfitLossSharingPercent,
                    MonthlyIncentivesIfAny = viewModel.MonthlyIncentivesIfAny,
                    YearlyIncentivesIfAny = viewModel.YearlyIncentivesIfAny,
                    OtherPerksIfAny = viewModel.OtherPerksIfAny,
                    NoticePeriod = viewModel.NoticePeriod,
                    OtherTermsIfAny = viewModel.OtherTermsIfAny,
                    PartnerId = viewModel.PartnerId
                };

                _repo.AddTearmsCondition(partnerTearmsCondition);
            }
            else
            {
                var partnerTearmsConditionInDb = _repo.GetTearmsCondition(viewModel.Id);

                if (partnerTearmsConditionInDb == null)
                {
                    ModelState.AddModelError("", "Something went wrong.");
                    return View("TearmsConditionForm", viewModel);
                }

                partnerTearmsConditionInDb.ProfitLossSharingPercent = viewModel.ProfitLossSharingPercent;
                partnerTearmsConditionInDb.MonthlyIncentivesIfAny = viewModel.MonthlyIncentivesIfAny;
                partnerTearmsConditionInDb.YearlyIncentivesIfAny = viewModel.YearlyIncentivesIfAny;
                partnerTearmsConditionInDb.OtherPerksIfAny = viewModel.OtherPerksIfAny;
                partnerTearmsConditionInDb.NoticePeriod = viewModel.NoticePeriod;
                partnerTearmsConditionInDb.OtherTermsIfAny = viewModel.OtherTermsIfAny;
                partnerTearmsConditionInDb.PartnerId = viewModel.PartnerId;

                _repo.UpdateTearmsCondition(partnerTearmsConditionInDb);
            }

            return RedirectToAction("TearmsCondition", "Partners", new { id = viewModel.PartnerId });
        }

        public ActionResult EditTearmsCondition(int id)
        {
            var tearmsConditionInDb = _repo.GetTearmsCondition(id);

            var viewModel = new TearmsConditionFormViewModel()
            {
                ProfitLossSharingPercent = tearmsConditionInDb.ProfitLossSharingPercent,
                MonthlyIncentivesIfAny = tearmsConditionInDb.MonthlyIncentivesIfAny,
                YearlyIncentivesIfAny = tearmsConditionInDb.YearlyIncentivesIfAny,
                OtherPerksIfAny = tearmsConditionInDb.OtherPerksIfAny,
                NoticePeriod = tearmsConditionInDb.NoticePeriod,
                OtherTermsIfAny = tearmsConditionInDb.OtherTermsIfAny,
                PartnerId = tearmsConditionInDb.PartnerId
            };

            if (tearmsConditionInDb == null)
            {
                ModelState.AddModelError("", "Something went wrong.");
                return View("TearmsConditionForm", viewModel);
            }

            return View("TearmsConditionForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTearmsCondition(int TearmsConditionId, int PartnerId)
        {
            var tearmsConditionInDb = _repo.GetTearmsCondition(TearmsConditionId);

            _repo.RemoveTearmsCondition(tearmsConditionInDb);

            return RedirectToAction("TearmsCondition", "Partners", new { id = PartnerId });
        }

        public ActionResult ViewTearmsCondition(int id)
        {
            var tearmsConditionInDb = _repo.GetTearmsCondition(id);

            var viewModel = new ViewTearmsConditionViewModel()
            {
                ProfitLossSharingPercent = tearmsConditionInDb.ProfitLossSharingPercent,
                MonthlyIncentivesIfAny = tearmsConditionInDb.MonthlyIncentivesIfAny,
                YearlyIncentivesIfAny = tearmsConditionInDb.YearlyIncentivesIfAny,
                OtherPerksIfAny = tearmsConditionInDb.OtherPerksIfAny,
                NoticePeriod = tearmsConditionInDb.NoticePeriod,
                OtherTermsIfAny = tearmsConditionInDb.OtherTermsIfAny,
                PartnerId = tearmsConditionInDb.PartnerId
            };

            return View("ViewTearmsCondition", viewModel);
        }
    }
}