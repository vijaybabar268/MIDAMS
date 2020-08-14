using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static MIDAMS.Models.ManageDependancyData;

namespace MIDAMS.Areas.Admin.ViewModels
{
    public class ClientRoleResponsibilityFormViewModel
    {
        public int Id { get; set; }

        public IEnumerable<Dropdown> Hos { get; set; }

        [Display(Name ="HO")]
        public int HoId { get; set; }

        public IEnumerable<Dropdown> Sites { get; set; }

        [Display(Name = "Site")]
        public int SiteId { get; set; }

        public int ClientId { get; set; }
    }
}