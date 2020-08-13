using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIDAMS.Models
{
    [Table("tbl_clients")]
    public class Client
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("region_id")]
        public int RegionId { get; set; }

        [Column("branch_location_id")]
        public int BranchLocationId { get; set; }

        [Column("industry_type_id")]
        public int IndustryTypeId  { get; set; }

        [Column("client_name")]
        public string ClientName { get; set; }

        [Column("site_address")]
        public string SiteAddress { get; set; }

        [Column("corp_office_address")]
        public string CorpOfficeAddress { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("created_on")]
        public DateTime CreatedOn { get; set; }

        // Manage Role
        // Manage Contact Details
        // Manage Relations
    }

    [Table("tbl_client_role_responsibilities")]
    public class ClientRoleResponsibility
    {
        [Column("id")]
        public byte Id { get; set; }

        public string Name { get; set; }

        public int HoId { get; set; }

        public int SiteId { get; set; }

        public int ClientId { get; set; }
    }

    [Table("tbl_client_contact_details")]
    public class ClientContactDetail
    {
        [Column("id")]
        public byte Id { get; set; }

        public string Name { get; set; }

        public int DesignationId { get; set; }

        public int ManagementLevelId { get; set; }

        public int DepartmentId { get; set; }

        public string ReportingManager { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime? WeddingAnniversaryDate { get; set; }

        public string OfficialEmailId { get; set; }

        public string OfficialMobileNo { get; set; }

        public string OfficialLandlineNo { get; set; }


        public string PersonalEmailId { get; set; }

        public string PersonalMobileNo { get; set; }

        public string PersonalLandlineNo { get; set; }

        public int ClientId { get; set; }
    }

    [Table("tbl_client_relations")]
    public class ClientRelation
    {
        [Column("id")]
        public byte Id { get; set; }

        public string Name { get; set; }

        public string FurtherPlansToImproveMaitainRelationship { get; set; }

        public string Remark { get; set; }

        public int ClientId { get; set; }
    }
}