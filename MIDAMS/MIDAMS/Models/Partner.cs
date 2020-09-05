using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIDAMS.Models
{
    [Table("tbl_partner")]
    public class Partner
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("remarks")]
        public string Remarks { get; set; }
                
        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("created_on")]
        public DateTime CreatedOn { get; set; }

        // Manage Details Of Responsible Site
        /*
            Name Of The Site	
            Location	
            Site Code	
            Start Date Of Site	
            Management Fees % / Amount	
            Total Billing Value Of Site
         */

        // Manage Agreed Terms Between Both Parties
        /*
            Profit / Loss Sharing %	
            Monthly Incentives If Any	
            Yearly Incentives If Any	
            Other Perks If Any	
            Notice Period	
            Other Terms If Any
         */
    }
}