using MIDAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MIDAMS.Models.ManageDependancyData;

namespace MIDAMS.Areas.Admin.ViewModels
{
    public class ClientViewModel
    {
        public IEnumerable<Client> Clients { get; set; }

        public IEnumerable<Dropdown> Regions { get; set; }

        public IEnumerable<Dropdown> BranchLocations { get; set; }

        public IEnumerable<Dropdown> IndustryTypes { get; set; }
    }
}