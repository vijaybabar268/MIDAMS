using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIDAMS.Models
{
    [Table("tbl_employees")]
    public class Employee
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("firstname")]
        public string FirstName { get; set; }

        [Column("middlename")]
        public string MiddleName { get; set; }

        [Column("lastname")]
        public string LastName { get; set; }

        [Column("mothername")]
        public string MotherName { get; set; }

        [Column("education_qualification_id")]
        public int EducationQualificationId { get; set; }

        [Column("designation_id")]
        public int DesignationId { get; set; }

        // DeploySiteName

        [Column("marital_status_id")]
        public int MaritalStatusId { get; set; }

        [Column("gender_id")]
        public int GenderId { get; set; }

        [Column("email_id")]
        public string EmailId { get; set; }

        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }

        [Column("date_of_joining")]
        public DateTime DateOfJoining { get; set; }

        [Column("Present_address")]
        public string PresentAddress { get; set; }

        [Column("permanent_address")]
        public string PermanentAddress { get; set; }

        [Column("mobile_number")]
        public string MobileNumber { get; set; }

        [Column("tel_number")]
        public string TelNumber { get; set; }

        [Column("indetification_mark_on_body")]
        public string IndetificationMarkOnBody { get; set; }

        [Column("name_and_contact_reference_1")]
        public string NameAndContactReference1 { get; set; }

        [Column("name_and_contact_reference_2")]
        public string NameAndContactReference2 { get; set; }

        [Column("photo")]
        public string Photo { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("created_on")]
        public DateTime CreatedOn { get; set; }
    }

    [Table("tbl_employee_document_details")]
    public class EmployeeDocumentDetails
    {
        [Column("id")]
        public int Id { get; set; }

        public string AdharNo { get; set; }
        public string AdharName { get; set; }
        public DateTime AdharDateOfBirth { get; set; }
        public string AdharAddress { get; set; }

        public string PanNo { get; set; }
        public string PanName { get; set; }
        public string PanFatherName { get; set; }
        public DateTime PanDateOfBirth { get; set; }

        public int EmployeeId { get; set; }
    }

    [Table("tbl_employee_bank_details")]
    public class EmployeeBankDetails
    {
        [Column("id")]
        public int Id { get; set; }

        public string AccountNo { get; set; }
        public string BankName { get; set; }
        public string IFSCCode { get; set; }
        public string BranchName { get; set; }
        public string NameOfAccountHolder1 { get; set; }
        public string NameOfAccountHolder2 { get; set; }

        public int EmployeeId { get; set; }
    }

    [Table("tbl_employee_pf_details")]
    public class EmployeePFDetails
    {
        [Column("id")]
        public int Id { get; set; }

        public string UANOfPreviousCompany { get; set; }
        public string PFAccNoPreviousCompany { get; set; }
        public DateTime DOJPreviousCompany { get; set; }
        public DateTime DOLPreviousCompany { get; set; }

        public int EmployeeId { get; set; }
    }

    [Table("tbl_employee_state_insurance_details")]
    public class EmployeeStateInsuranceDetails
    {
        [Column("id")]
        public int Id { get; set; }

        public int DisabilityId { get; set; }

        public string PreviousEmployerCodeNo { get; set; }

        public string PreviousIPNo { get; set; }

        public string PreviousEmployerName { get; set; }

        public string PreviousEmployerAddress { get; set; }

        public string NomineeName { get; set; }

        public string NomineeAddress { get; set; }

        public int RelationWithNomineeId { get; set; }

        public int PercentShareTowardsNominee { get; set; }

        public int EmployeeId { get; set; }
    }

    [Table("tbl_employee_state_insurance_family_details")]
    public class EmployeeStateInsuranceFamilyDetails
    {
        [Column("id")]
        public int Id { get; set; }

        public string Name { get; set; }

        public int RelationIP { get; set; }

        public int MinorMajorId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool IsResidingWithIP { get; set; }

        public string State { get; set; }

        public string District { get; set; }

        public int EmployeeStateInsuranceDetailId { get; set; }        
    }
}