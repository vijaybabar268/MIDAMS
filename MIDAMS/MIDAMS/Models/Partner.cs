using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIDAMS.Models
{
    [Table("tbl_partner")]
    public class Partner
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

        [Column("remarks")]
        public string Remarks { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("created_on")]
        public DateTime CreatedOn { get; set; }
    }

    [Table("tbl_partner_document_details")]
    public class PartnerDocumentDetail
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("adhar_no")]
        public string AdharNo { get; set; }

        [Column("adhar_name")]
        public string AdharName { get; set; }

        [Column("adhar_date_of_birth")]
        public DateTime AdharDateOfBirth { get; set; }

        [Column("adhar_address")]
        public string AdharAddress { get; set; }

        [Column("pan_no")]
        public string PanNo { get; set; }

        [Column("pan_name")]
        public string PanName { get; set; }

        [Column("pan_father_name")]
        public string PanFatherName { get; set; }

        [Column("pan_date_of_birth")]
        public DateTime PanDateOfBirth { get; set; }

        [Column("partner_id")]
        public int PartnerId { get; set; }
    }

    [Table("tbl_partner_bank_details")]
    public class PartnerBankDetail
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("account_no")]
        public string AccountNo { get; set; }

        [Column("bank_name")]
        public string BankName { get; set; }

        [Column("ifsc_code")]
        public string IFSCCode { get; set; }

        [Column("branch_code")]
        public string BranchName { get; set; }

        [Column("account_holder_name_1")]
        public string NameOfAccountHolder1 { get; set; }

        [Column("account_holder_name_2")]
        public string NameOfAccountHolder2 { get; set; }

        [Column("partner_id")]
        public int PartnerId { get; set; }
    }

    [Table("tbl_partner_responsible_site")]
    public class PartnerResponsibleSite
    {
        [Column("id")]
        public int Id { get; set; }

        public string NameOfTheSite { get; set; }
        public string Location { get; set; }
        public string SiteCode { get; set; }
        public string StartDateOfSite	 { get; set; }
        public string ManagementFeesPercentAmount { get; set; }
        public string TotalBillingValueOfSite { get; set; }

        public int PartnerId { get; set; }
    }

    [Table("tbl_partner_tearms_Condition")]
    public class PartnerTearmsCondition
    {
        [Column("id")]
        public int Id { get; set; }

        public string ProfitLossSharingPercent { get; set; }
        public string MonthlyIncentivesIfAny { get; set; }
        public string YearlyIncentivesIfAny { get; set; }
        public string OtherPerksIfAny { get; set; }
        public string NoticePeriod { get; set; }
        public string OtherTermsIfAny { get; set; }

        public int PartnerId { get; set; }
    }
}