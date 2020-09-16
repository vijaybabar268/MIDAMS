using MIDAMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MIDAMS.Models.ManageDependancyData;

namespace MIDAMS.Areas.Admin.ViewModels
{    
    public class PartnerViewModel
    {
        public string Title
        {
            get
            {
                return "Manage Partners";
            }
        }
        public IEnumerable<Partner> Partners { get; set; }
        public IEnumerable<Dropdown> EducationQualifications { get; set; }
        public IEnumerable<Dropdown> Designations { get; set; }
        public IEnumerable<Dropdown> MaritalStatus { get; set; }
        public IEnumerable<Dropdown> Genders { get; set; }
    }
        
    public class PartnerFormViewModel
    {
        /*Login Info*/
        //[Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        //public string Title
        //{
        //    get
        //    {
        //        return Id == 0 ? "Create Partner" : "Edit Partner";
        //    }
        //}

        /*Partner Info*/
        public int PartnerId { get; set; }

        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Father Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Mother Name")]
        public string MotherName { get; set; }

        public IEnumerable<Dropdown> EducationQualifications { get; set; }

        [Required]
        [Display(Name = "Select Education")]
        public int EducationQualificationId { get; set; }

        public IEnumerable<Dropdown> Designations { get; set; }

        [Required]
        [Display(Name = "Select Designation")]
        public int DesignationId { get; set; }

        public IEnumerable<Dropdown> MaritalStatus { get; set; }

        [Required]
        [Display(Name = "Select Marital Status")]
        public int MaritalStatusId { get; set; }

        public IEnumerable<Dropdown> Genders { get; set; }

        [Required]
        [Display(Name = "Select Gender")]
        public int GenderId { get; set; }

        //[Required]
        [Display(Name = "Email")]
        public string EmailId { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Date Of Joining")]
        public DateTime? DateOfJoining { get; set; }

        [Required]
        [Display(Name = "Present Address")]
        public string PresentAddress { get; set; }

        [Required]
        [Display(Name = "Permanent Address")]
        public string PermanentAddress { get; set; }

        [Required]
        [Display(Name = "Mobile No")]
        public string MobileNumber { get; set; }

        [Required]
        [Display(Name = "Tel No")]
        public string TelNumber { get; set; }

        [Required]
        [Display(Name = "Identification Mark On Body")]
        public string IndetificationMarkOnBody { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [Display(Name = "Remark")]
        public string Remark { get; set; }

        public int UserId { get; set; }

        public string Title
        {
            get
            {
                return Id == 0 ? "Create Partner" : "Edit Partner";
            }
        }
    }

    public class PartnerDetailsViewModel
    {
        /*Login Info*/
        [Display(Name = "Username :-")]
        public string UserName { get; set; }

        [Display(Name = "Email :-")]
        public string Email { get; set; }

        [Display(Name = "Password :-")]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        /*Partner Info*/
        public int PartnerId { get; set; }

        public int Id { get; set; }

        [Display(Name = "First Name :-")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name :-")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name :-")]
        public string LastName { get; set; }

        [Display(Name = "Mother Name :-")]
        public string MotherName { get; set; }

        public IEnumerable<Dropdown> EducationQualifications { get; set; }

        [Display(Name = "Education/Qualification :-")]
        public int EducationQualificationId { get; set; }

        public IEnumerable<Dropdown> Designations { get; set; }

        [Display(Name = "Designation :-")]
        public int DesignationId { get; set; }

        public IEnumerable<Dropdown> MaritalStatus { get; set; }

        [Display(Name = "Marital Status :-")]
        public int MaritalStatusId { get; set; }

        public IEnumerable<Dropdown> Genders { get; set; }

        [Display(Name = "Gender :-")]
        public int GenderId { get; set; }

        [Display(Name = "Email Id :-")]
        public string EmailId { get; set; }

        [Display(Name = "Date Of Birth :-")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Date Of Joining :-")]
        public DateTime? DateOfJoining { get; set; }

        [Display(Name = "Present Address :-")]
        public string PresentAddress { get; set; }

        [Display(Name = "Permanent Address :-")]
        public string PermanentAddress { get; set; }

        [Display(Name = "Mobile Number :-")]
        public string MobileNumber { get; set; }

        [Display(Name = "Telephone Number :-")]
        public string TelNumber { get; set; }

        [Display(Name = "Indetification Mark On Body :-")]
        public string IndetificationMarkOnBody { get; set; }

        [Display(Name = "Status :-")]
        public bool IsActive { get; set; }

        [Display(Name = "Created On :-")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Remarks :-")]
        public string Remark { get; set; }

        public int UserId { get; set; }

        public string Title
        {
            get
            {
                return "Partner Details";
            }
        }
    }

    // Partner Document Details
    public class DocumentDetailViewModel
    {
        public IEnumerable<PartnerDocumentDetail> PartnerDocumentDetails { get; set; }

        public int PartnerId { get; set; }

        public string PartnerName { get; set; }
    }

    public class DocumentDetailFormViewModel
    {
        public int Id { get; set; }

        [Display(Name ="Adhar No")]
        public string AdharNo { get; set; }

        [Display(Name = "Adhar Name")]
        public string AdharName { get; set; }

        [Display(Name = "Adhar Birthdate")]
        public DateTime AdharDateOfBirth { get; set; }

        [Display(Name = "Adhar Address")]
        public string AdharAddress { get; set; }

        [Display(Name = "Pan No")]
        public string PanNo { get; set; }

        [Display(Name = "Pan Name")]
        public string PanName { get; set; }

        [Display(Name = "Pan Father Name")]
        public string PanFatherName { get; set; }

        [Display(Name = "Pan Birthdate")]
        public DateTime PanDateOfBirth { get; set; }
                
        public int PartnerId { get; set; }
    }

    public class ViewDocumentDetailViewModel
    {
        [Display(Name = "Adhar No :-")]
        public string AdharNo { get; set; }

        [Display(Name = "Adhar Name :-")]
        public string AdharName { get; set; }

        [Display(Name = "Adhar Birthdate :-")]
        public DateTime AdharDateOfBirth { get; set; }

        [Display(Name = "Adhar Address :-")]
        public string AdharAddress { get; set; }

        [Display(Name = "Pan No :-")]
        public string PanNo { get; set; }

        [Display(Name = "Pan Name :-")]
        public string PanName { get; set; }

        [Display(Name = "Pan Father Name :-")]
        public string PanFatherName { get; set; }

        [Display(Name = "Pan Birthdate :-")]
        public DateTime PanDateOfBirth { get; set; }

        public int PartnerId { get; set; }
    }

    // Partner Bank Details
    public class BankDetailsViewModel
    {
        public IEnumerable<PartnerBankDetail> PartnerBankDetails { get; set; }

        public int PartnerId { get; set; }

        public string PartnerName { get; set; }
    }

    public class BankDetailsFormViewModel
    {
        public int Id { get; set; }

        [Display(Name ="Account No")]
        public string AccountNo { get; set; }

        [Display(Name = "Bank Name")]
        public string BankName { get; set; }

        [Display(Name = "IFSC Code")]
        public string IFSCCode { get; set; }

        [Display(Name = "Branch Name")]
        public string BranchName { get; set; }

        [Display(Name = "Name Of Account Holder 1")]
        public string NameOfAccountHolder1 { get; set; }

        [Display(Name = "Name Of Account Holder 2")]
        public string NameOfAccountHolder2 { get; set; }

        public int PartnerId { get; set; }
    }

    public class ViewBankDetailsViewModel
    {
        [Display(Name = "Account No :-")]
        public string AccountNo { get; set; }

        [Display(Name = "Bank Name :-")]
        public string BankName { get; set; }

        [Display(Name = "IFSC Code :-")]
        public string IFSCCode { get; set; }

        [Display(Name = "Branch Name :-")]
        public string BranchName { get; set; }

        [Display(Name = "Name Of Account Holder 1 :-")]
        public string NameOfAccountHolder1 { get; set; }

        [Display(Name = "Name Of Account Holder 2 :-")]
        public string NameOfAccountHolder2 { get; set; }

        public int PartnerId { get; set; }
    }

    // Partner Responsible Site
    public class ResponsibleSiteViewModel
    {
        public IEnumerable<PartnerResponsibleSite> PartnerResponsibleSites { get; set; }

        public int PartnerId { get; set; }

        public string PartnerName { get; set; }
    }

    public class ResponsibleSiteFormViewModel
    {
        public int Id { get; set; }

        [Display(Name ="Name Of The Site")]
        public string NameOfTheSite { get; set; }

        [Display(Name ="Location")]
        public string Location { get; set; }

        [Display(Name ="Site Code")]
        public string SiteCode { get; set; }

        [Display(Name ="Start Date Of Site")]
        public DateTime StartDateOfSite { get; set; }

        [Display(Name ="Management Fees Percent Amount")]
        public decimal ManagementFeesPercentAmount { get; set; }

        [Column("Total Billing Value Of Site")]
        public decimal TotalBillingValueOfSite { get; set; }

        public int PartnerId { get; set; }
    }

    public class ViewResponsibleSiteViewModel
    {
        [Display(Name = "Name Of The Site :-")]
        public string NameOfTheSite { get; set; }

        [Display(Name = "Location :-")]
        public string Location { get; set; }

        [Display(Name = "Site Code :-")]
        public string SiteCode { get; set; }

        [Display(Name = "Start Date Of Site :-")]
        public DateTime StartDateOfSite { get; set; }

        [Display(Name = "Management Fees Percent Amount :-")]
        public decimal ManagementFeesPercentAmount { get; set; }

        [Column("Total Billing Value Of Site :-")]
        public decimal TotalBillingValueOfSite { get; set; }

        public int PartnerId { get; set; }
    }
}