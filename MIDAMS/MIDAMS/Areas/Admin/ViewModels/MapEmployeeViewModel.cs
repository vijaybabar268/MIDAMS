using MIDAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIDAMS.Areas.Admin.ViewModels
{
    public class MapEmployeeViewModel
    {
        public IEnumerable<MapEmployeesToClient> MapEmployeesToClients { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Client> Clients { get; set; }
        public string ClientName { get; set; }  
    }
}