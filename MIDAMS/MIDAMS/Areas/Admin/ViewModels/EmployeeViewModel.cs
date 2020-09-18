using MIDAMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static MIDAMS.Models.ManageDependancyData;

namespace MIDAMS.Areas.Admin.ViewModels
{
    public class EmployeeViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Dropdown> EducationQualifications { get; set; }
        public IEnumerable<Dropdown> Designations { get; set; }
        public IEnumerable<Dropdown> MaritalStatus { get; set; }
        public IEnumerable<Dropdown> Genders { get; set; }
    }

    public class EmployeeDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "First Name :-")]
        public string FirstName { get; set; }

        [Display(Name = "Father Name :-")]
        public string MiddleName { get; set; }

        [Display(Name = "Surname :-")]
        public string LastName { get; set; }

        [Display(Name = "Mother Name :-")]
        public string MotherName { get; set; }

        [Display(Name = "Select Education :-")]
        public int EducationQualificationId { get; set; }

        [Display(Name = "Select Designation :-")]
        public int DesignationId { get; set; }

        [Display(Name = "Select Marital Status :-")]
        public int MaritalStatusId { get; set; }

        [Display(Name = "Select Gender :-")]
        public int GenderId { get; set; }

        [Display(Name = "Email :-")]
        public string EmailId { get; set; }

        [Display(Name = "Date Of Birth :-")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Date Of Joining :-")]
        public DateTime? DateOfJoining { get; set; }

        [Display(Name = "Present Address :-")]
        public string PresentAddress { get; set; }

        [Display(Name = "Permanent Address :-")]
        public string PermanentAddress { get; set; }

        [Display(Name = "Mobile No :-")]
        public string MobileNumber { get; set; }

        [Display(Name = "Tel No :-")]
        public string TelNumber { get; set; }

        [Display(Name = "Mark On Body :-")]
        public string IndetificationMarkOnBody { get; set; }

        [Display(Name = "Name & Contact Ref 1 :-")]
        public string NameAndContactReference1 { get; set; }

        [Display(Name = "Name & Contact Ref 1 :-")]
        public string NameAndContactReference2 { get; set; }

        [Display(Name = "Photo :-")]
        public string Photo { get; set; }

        [Display(Name = "Status :-")]
        public bool IsActive { get; set; }

        [Display(Name = "Created on :-")]
        public DateTime CreatedOn { get; set; }

        public IEnumerable<Dropdown> EducationQualifications { get; set; }

        public IEnumerable<Dropdown> Designations { get; set; }

        public IEnumerable<Dropdown> MaritalStatus { get; set; }

        public IEnumerable<Dropdown> Genders { get; set; }
    }

    public class EmployeeFormViewModel
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

        [Required]
        [Display(Name = "Name & Contact Ref 1")]
        public string NameAndContactReference1 { get; set; }

        [Required]
        [Display(Name = "Name & Contact Ref 2")]
        public string NameAndContactReference2 { get; set; }

        [Required]
        [Display(Name = "Photo")]
        public string Photo { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title
        {
            get
            {
                return Id == 0 ? "Create Employee" : "Edit Employee";
            }
        }
    }
}