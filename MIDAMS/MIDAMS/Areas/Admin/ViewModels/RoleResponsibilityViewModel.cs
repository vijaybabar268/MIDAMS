using MIDAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MIDAMS.Models.ManageDependancyData;

namespace MIDAMS.Areas.Admin.ViewModels
{
    public class RoleResponsibilityViewModel
    {
        public IEnumerable<ClientRoleResponsibility> ClientRoleResponsibilities { get; set; }

        public IEnumerable<Dropdown> Hos { get; set; }

        public IEnumerable<Dropdown> Sites { get; set; }

        public int ClientId { get; set; }

        public string  ClientName { get; set; }
    }
}