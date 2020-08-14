using MIDAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIDAMS.Areas.Admin.Repositories
{
    public class AdminRepository
    {
        private readonly ApplicationDbContext _context;

        public AdminRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<User> GetAdmins()
        {
            return _context.Users.ToList();
        }

        public User GetAdmin(int id)
        {
            return _context.Users.FirstOrDefault(c => c.Id == id);
        }

        public void AddAdmin(User admin)
        {
            _context.Users.Add(admin);
            _context.SaveChanges();
        }

        public void UpdateAdmin(User user)
        {
            _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveAdmin(User admin)
        {
            _context.Users.Remove(admin);
            _context.SaveChanges();
        }
    }
}