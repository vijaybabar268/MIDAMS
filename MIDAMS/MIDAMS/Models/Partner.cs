﻿using System;
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
    public class PartnerDocumentDetails
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

        public int PartnerId { get; set; }
    }

    [Table("tbl_partner_bank_details")]
    public class PartnerBankDetails
    {
        [Column("id")]
        public int Id { get; set; }

        public string AccountNo { get; set; }
        public string BankName { get; set; }
        public string IFSCCode { get; set; }
        public string BranchName { get; set; }
        public string NameOfAccountHolder1 { get; set; }
        public string NameOfAccountHolder2 { get; set; }

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