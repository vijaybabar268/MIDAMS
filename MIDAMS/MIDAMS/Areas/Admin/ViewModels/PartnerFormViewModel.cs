using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static MIDAMS.Models.ManageDependancyData;

namespace MIDAMS.Areas.Admin.ViewModels
{
    public class PartnerFormViewModel
    {
        public int Id { get; set; }

        [Required]
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

        public string Title
        {
            get
            {
                return Id == 0 ? "Create Partner" : "Edit Partner";
            }
        }       
    }

    public class PartnerFormViewModel2
    {
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

        [Required]
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
}