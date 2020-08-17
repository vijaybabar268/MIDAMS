using MIDAMS.Areas.Admin.Repositories;
using MIDAMS.Areas.Admin.ViewModels;
using MIDAMS.Models;
using System.Linq;
using System.Web.Mvc;

namespace MIDAMS.Areas.Admin.Controllers
{
    public class AdminsController : Controller
    {
        private readonly AdminRepository _repo;
        
        public AdminsController()
        {
            _repo = new AdminRepository();
        }
                        
        public ActionResult Index()
        {
            var admins = _repo.GetAdmins()
                        .Where(a => a.RoleId == 1)
                        .ToList();

            return View(admins);
        }

        public ActionResult New()
        {
            var viewModel = new AdminFormViewModel() 
            { 
            
            };            

            return View("AdminForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(AdminFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AdminForm", viewModel);
            }

            if (viewModel.Id == 0)
            {
                var totalAdminCount = _repo.GetAdmins()
                                    .Where(a => a.IsActive == true && a.RoleId == 1)
                                    .Count();

                if (totalAdminCount >= 5)
                {
                    ModelState.AddModelError("", "You can create only five admins.");
                    return View("AdminForm", viewModel);
                }

                var admin = new User
                {
                    UserName = viewModel.UserName,
                    Email = viewModel.Email,
                    Password = viewModel.Password,
                    RoleId = 1,
                    IsActive = true
                };

                _repo.AddAdmin(admin);
            }
            else
            {
                var adminInDb = _repo.GetAdmin(viewModel.Id);

                if (adminInDb == null)
                {
                    ModelState.AddModelError("", "Something went wrong.");
                    return View("AdminForm", viewModel);
                }

                adminInDb.UserName = viewModel.UserName;
                adminInDb.Email = viewModel.Email;
                adminInDb.Password = viewModel.Password;

                _repo.UpdateAdmin(adminInDb);
            }
            
            return RedirectToAction("Index", "Admins");
        }

        public ActionResult Edit(int id)
        {
            var adminInDb = _repo.GetAdmin(id);

            var viewModel = new AdminFormViewModel()
            {
                Id = adminInDb.Id,
                UserName = adminInDb.UserName,
                Email = adminInDb.Email
            };

            if (adminInDb == null)
            {
                ModelState.AddModelError("", "Something went wrong.");
                return View("AdminForm", viewModel);
            }

            return View("AdminForm", viewModel);
        }


        public ActionResult ToggleStatus(int id)
        {
            var adminInDb = _repo.GetAdmin(id);

            if (adminInDb.IsActive)
                adminInDb.IsActive = false;
            else
                adminInDb.IsActive = true;

            _repo.UpdateAdmin(adminInDb);

            return RedirectToAction("Index", "Admins");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _repo.RemoveAdmin(_repo.GetAdmin(id));

            return RedirectToAction("Index", "Admins");
        }
    }
}