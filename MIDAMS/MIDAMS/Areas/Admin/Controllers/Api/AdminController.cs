using MIDAMS.Areas.Admin.Repositories;
using MIDAMS.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace MIDAMS.Areas.Admin.Controllers.Api
{
    public class AdminController : ApiController
    {
        private readonly AdminRepository _repo;

        public AdminController()
        {
            _repo = new AdminRepository();
        }

        [HttpGet]
        public IEnumerable<User> Admins()
        {
            return _repo.GetAdmins();
        }

        [HttpGet]
        public User Admin(int id)
        {
            return _repo.GetAdmin(id);
        }

        [HttpPost]
        public User AddAdmin(User admin)
        {
            if(!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            admin.IsActive = true;
            admin.RoleId = 1;

            _repo.AddAdmin(admin);

            return admin;
        }

        [HttpPut]
        public void UpdateAdmin(int id, User admin)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var adminInDb = _repo.GetAdmin(id);

            if (adminInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            adminInDb.UserName = admin.UserName;
            adminInDb.Email = admin.Email;
            adminInDb.Password = admin.Password;
            adminInDb.PhoneNumber = admin.PhoneNumber;            

            _repo.UpdateAdmin(adminInDb);
        }

        [HttpDelete]
        public void DeleteAdmin(int id)
        {
            _repo.RemoveAdmin(_repo.GetAdmin(id));
        }
    }
}
