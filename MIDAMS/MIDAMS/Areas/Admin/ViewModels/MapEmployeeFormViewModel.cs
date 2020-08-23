using MIDAMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIDAMS.Areas.Admin.ViewModels
{
    public class MapEmployeeFormViewModel
    {
        public int Id { get; set; }

        [Display(Name="Select Client")]
        public int ClientId { get; set; }

        [Display(Name = "Select Employees")]
        public IEnumerable<int> EmployeeIds { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        public IEnumerable<Client> Clients { get; set; }
    }
}