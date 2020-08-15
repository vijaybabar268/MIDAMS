using MIDAMS.Areas.Admin.Repositories;
using MIDAMS.Areas.Admin.ViewModels;
using MIDAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIDAMS.Areas.Admin.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeRepository _repo;

        public EmployeesController()
        {
            _repo = new EmployeeRepository();
            
        }

        public ActionResult Index()
        {
            var viewModel = new EmployeeViewModel()
            {
                Employees = _repo.GetEmployees().ToList(),
                EducationQualifications = ManageDependancyData.GetEducationQualification(),
                Designations = ManageDependancyData.GetDesignations(),
                MaritalStatus = ManageDependancyData.GetMaritalStatus(),
                Genders = ManageDependancyData.GetGenders()
            };

            return View(viewModel);
        }
    }
}