using System;
using System.Collections.Generic;
using static MIDAMS.Models.ManageDependancyData;
using System.ComponentModel.DataAnnotations;

namespace MIDAMS.Areas.Admin.ViewModels
{
    public class ClientFormViewModel
    {
        public int Id { get; set; }
                
        public IEnumerable<Dropdown> Regions { get; set; }

        [Required]
        [Display(Name = "Select Region")]
        public  int RegionId { get; set; }

        public IEnumerable<Dropdown> BranchLocations { get; set; }

        [Required]
        [Display(Name = "Select Branch Location")]
        public int BranchLocationId { get; set; }

        public IEnumerable<Dropdown> IndustryTypes { get; set; }

        [Required]
        [Display(Name = "Select Industry Type")]
        public int IndustryTypeId { get; set; }

        [Required]
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }

        [Required]
        [Display(Name = "Site Address")]
        public string SiteAddress { get; set; }

        [Required]
        [Display(Name = "Corporate Office Address")]
        public string CorpOfficeAddress { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title
        {
            get
            {
                return Id == 0 ? "Create Client" : "Edit Client";
            }
        }
    }
}