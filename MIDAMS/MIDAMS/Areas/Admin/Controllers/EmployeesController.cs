﻿using MIDAMS.Areas.Admin.Repositories;
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

        public ActionResult New()
        {
            var viewModel = new EmployeeFormViewModel()
            {
                Id = 0,
                EducationQualifications = ManageDependancyData.GetEducationQualification(),
                Designations = ManageDependancyData.GetDesignations(),
                MaritalStatus = ManageDependancyData.GetMaritalStatus(),
                Genders = ManageDependancyData.GetGenders()
            };

            return View("EmployeeForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(EmployeeFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("EmployeeForm", viewModel);
            }

            if (viewModel.Id == 0)
            {
                var employee = new Employee
                {
                    FirstName = viewModel.FirstName,
                    MiddleName = viewModel.MiddleName,
                    LastName = viewModel.LastName,
                    MotherName = viewModel.MotherName,
                    EducationQualificationId = viewModel.EducationQualificationId,
                    DesignationId = viewModel.DesignationId,
                    MaritalStatusId = viewModel.MaritalStatusId,
                    GenderId = viewModel.GenderId,
                    EmailId = viewModel.EmailId,
                    DateOfBirth = (DateTime)viewModel.DateOfBirth,
                    DateOfJoining = (DateTime)viewModel.DateOfJoining,
                    PresentAddress = viewModel.PresentAddress,
                    PermanentAddress = viewModel.PermanentAddress,
                    MobileNumber = viewModel.MobileNumber,
                    TelNumber = viewModel.TelNumber,
                    IndetificationMarkOnBody = viewModel.IndetificationMarkOnBody,
                    NameAndContactReference1 = viewModel.NameAndContactReference1,
                    NameAndContactReference2 = viewModel.NameAndContactReference2,
                    Photo = viewModel.Photo,
                    CreatedOn = DateTime.Now,
                    IsActive = true
                };

                _repo.AddEmployee(employee);
            }
            else
            {
                var employeeInDb = _repo.GetEmployee(viewModel.Id);

                if (employeeInDb == null)
                {
                    ModelState.AddModelError("", "Something went wrong.");
                    return View("EmployeeForm", viewModel);
                }

                employeeInDb.FirstName = viewModel.FirstName;
                employeeInDb.MiddleName = viewModel.MiddleName;
                employeeInDb.LastName = viewModel.LastName;
                employeeInDb.MotherName = viewModel.MotherName;
                employeeInDb.EducationQualificationId = viewModel.EducationQualificationId;
                employeeInDb.DesignationId = viewModel.DesignationId;
                employeeInDb.MaritalStatusId = viewModel.MaritalStatusId;
                employeeInDb.GenderId = viewModel.GenderId;
                employeeInDb.EmailId = viewModel.EmailId;
                employeeInDb.DateOfBirth = (DateTime)viewModel.DateOfBirth;
                employeeInDb.DateOfJoining = (DateTime)viewModel.DateOfJoining;
                employeeInDb.PresentAddress = viewModel.PresentAddress;
                employeeInDb.PermanentAddress = viewModel.PermanentAddress;
                employeeInDb.MobileNumber = viewModel.MobileNumber;
                employeeInDb.TelNumber = viewModel.TelNumber;
                employeeInDb.IndetificationMarkOnBody = viewModel.IndetificationMarkOnBody;
                employeeInDb.NameAndContactReference1 = viewModel.NameAndContactReference1;
                employeeInDb.NameAndContactReference2 = viewModel.NameAndContactReference2;

                _repo.UpdateEmployee(employeeInDb);
            }

            return RedirectToAction("Index", "Employees");
        }

        public ActionResult Edit(int id)
        {
            var employeeInDb = _repo.GetEmployee(id);

            var viewModel = new EmployeeFormViewModel()
            {
                Id = employeeInDb.Id,
                EducationQualifications = ManageDependancyData.GetEducationQualification(),
                Designations = ManageDependancyData.GetDesignations(),
                MaritalStatus = ManageDependancyData.GetMaritalStatus(),
                Genders = ManageDependancyData.GetGenders(),
                FirstName = employeeInDb.FirstName,
                MiddleName = employeeInDb.MiddleName,
                LastName = employeeInDb.LastName,
                MotherName = employeeInDb.MotherName,
                EducationQualificationId = employeeInDb.EducationQualificationId,
                DesignationId = employeeInDb.DesignationId,
                MaritalStatusId = employeeInDb.MaritalStatusId,
                GenderId = employeeInDb.GenderId,
                EmailId = employeeInDb.EmailId,
                DateOfBirth = (DateTime)employeeInDb.DateOfBirth,
                DateOfJoining = (DateTime)employeeInDb.DateOfJoining,
                PresentAddress = employeeInDb.PresentAddress,
                PermanentAddress = employeeInDb.PermanentAddress,
                MobileNumber = employeeInDb.MobileNumber,
                TelNumber = employeeInDb.TelNumber,
                IndetificationMarkOnBody = employeeInDb.IndetificationMarkOnBody,
                NameAndContactReference1 = employeeInDb.NameAndContactReference1,
                NameAndContactReference2 = employeeInDb.NameAndContactReference2
            };

            if (employeeInDb == null)
            {
                ModelState.AddModelError("", "Something went wrong.");
                return View("EmployeeForm", viewModel);
            }

            return View("EmployeeForm", viewModel);
        }

        public ActionResult ToggleStatus(int id)
        {
            var employeeInDb = _repo.GetEmployee(id);

            if (employeeInDb.IsActive)
                employeeInDb.IsActive = false;
            else
                employeeInDb.IsActive = true;

            _repo.UpdateEmployee(employeeInDb);

            return RedirectToAction("Index", "Employees");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _repo.RemoveEmployee(_repo.GetEmployee(id));

            return RedirectToAction("Index", "Employees");
        }
    }
}