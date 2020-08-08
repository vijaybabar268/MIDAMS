using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using MIDAMS.Areas.Admin.Data;
using MIDAMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MIDAMS.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class AdminsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;

        public AdminsController()
        {
            _context = new ApplicationDbContext();
        }

        public AdminsController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Index()
        {
            var admins = _context.Users
                        .Where(r => r.Roles.Any(u => u.RoleId == "faa1d0c0-48b0-44de-8e1b-42f4f85e3c6e"))
                        .ToList();

            return View(admins);
        }

        public ActionResult New()
        {
            var viewModel = new AdminFormViewModel()
            {
                Id = "",                
            };

            return View("AdminForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(AdminFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AdminForm", viewModel);
            }

            if (string.IsNullOrWhiteSpace(viewModel.Id))
            {
                var totalAdminCount = _context.Users.Where(r => r.Roles.Any(u => u.RoleId == "faa1d0c0-48b0-44de-8e1b-42f4f85e3c6e")).Count();

                if (totalAdminCount >= 5)
                {
                    ModelState.AddModelError("", "You can create only five admins.");
                    return View("AdminForm", viewModel);
                }

                var admin = new ApplicationUser
                {
                    UserName = viewModel.UserName,
                    Email = viewModel.Email,
                    Status = true
                };

                var result = await UserManager.CreateAsync(admin, viewModel.Password);

                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(admin.Id, "Admin");
                                        
                    return RedirectToAction("Index", "Admins");
                }
                else
                {                    
                    ModelState.AddModelError("", string.Join(", ", result.Errors));
                    return View("AdminForm", viewModel);
                }
            }
            else
            {
                var adminInDb = _context.Users.SingleOrDefault(x => x.Id == viewModel.Id);

                if (adminInDb == null)
                {
                    return HttpNotFound();
                }

                adminInDb.UserName = viewModel.UserName;
                adminInDb.Email = viewModel.Email;

                var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
                var manager = new UserManager<ApplicationUser>(store);
                await manager.UpdateAsync(adminInDb);
                _context.SaveChanges();

                UserManager.RemovePassword(viewModel.Id);
                UserManager.AddPassword(viewModel.Id, viewModel.Password);
                
                return RedirectToAction("Index", "Admins");
            }            
        }

        public ActionResult Edit(string id)
        {
            var adminInDb = _context.Users.FirstOrDefault(x => x.Id == id);

            if (adminInDb == null)
                return HttpNotFound();

            var viewModel = new AdminFormViewModel()
            {
                Id = adminInDb.Id,
                UserName = adminInDb.UserName,
                Email = adminInDb.Email
            };

            return View("AdminForm", viewModel);
        }


        public ActionResult ToggleStatus(string id)
        {
            var adminInDb = _context.Users.Find(id);

            if (adminInDb.Status)
                adminInDb.Status = false;
            else
                adminInDb.Status = true;

            _context.SaveChanges();

            return RedirectToAction("Index", "Admins");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            var adminInDb = _context.Users.Find(id);

            _context.Users.Remove(adminInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Admins");
        }
    }
}