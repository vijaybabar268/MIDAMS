using MIDAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MIDAMS.Models.ManageDependancyData;

namespace MIDAMS.Areas.Admin.ViewModels
{
    public class EmployeeViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Dropdown> EducationQualifications { get; set; }
        public IEnumerable<Dropdown> Designations { get; set; }
        public IEnumerable<Dropdown> MaritalStatus { get; set; }
        public IEnumerable<Dropdown> Genders { get; set; }
    }
}