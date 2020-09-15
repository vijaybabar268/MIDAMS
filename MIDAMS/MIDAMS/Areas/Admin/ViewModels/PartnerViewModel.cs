using MIDAMS.Models;
using System.Collections.Generic;
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
}