using MIDAMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static MIDAMS.Models.ManageDependancyData;

namespace MIDAMS.Areas.Admin.ViewModels
{
    public class PartnerDetailsViewModel
    {
        /*Login Info*/
        [Display(Name ="Username :-")]
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
}