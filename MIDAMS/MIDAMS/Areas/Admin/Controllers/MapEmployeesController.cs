using MIDAMS.Areas.Admin.ViewModels;
using MIDAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIDAMS.Areas.Admin.Controllers
{
    public class MapEmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MapEmployeesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {                        
            var viewModel = new MapEmployeeViewModel()
            {
                MapEmployeesToClients = _context.MapEmployeesToClients.ToList(),
                Clients = _context.Clients.ToList()
            };

            return View(viewModel);
        }

        public ActionResult New()
        {
            var viewModel = new MapEmployeeFormViewModel()
            {
                Id = 0,
                Employees = _context.Employees.ToList(),
                Clients = _context.Clients.ToList()
            };

            return View("MapEmployeeForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MapEmployeeFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("MapEmployeeForm", viewModel);
            }

            if (viewModel.Id == 0)
            {
                foreach (var employeeId in viewModel.EmployeeIds)
                {
                    var mapEmployees = new MapEmployeesToClient()
                    {
                        ClientId = viewModel.ClientId,
                        EmployeeId = employeeId,
                        CreatedOn = DateTime.Now
                    };

                    _context.MapEmployeesToClients.Add(mapEmployees);
                }                

                _context.SaveChanges();
            }
            else
            {

            }

            return RedirectToAction("Index");
        }
    }
}