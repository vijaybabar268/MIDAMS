using MIDAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIDAMS.Areas.Admin.Repositories
{
    public class PartnerRepositry
    {
        private readonly ApplicationDbContext _context;

        public PartnerRepositry()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<User> GetPartners()
        {
            return _context.Users.ToList();
        }

        public User GetPartner(int id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }

        public User GetPartnerByEmail(string email)
        {
            return _context.Users.FirstOrDefault(p => p.Email.ToLower().Trim() == email);
        }

        public void AddPartner(User partner)
        {
            _context.Users.Add(partner);
            _context.SaveChanges();
        }

        public void AddPartner2(Partner partner2)
        {
            _context.Partners.Add(partner2);
            _context.SaveChanges();
        }

        public void UpdatePartner(User partner)
        {
            _context.Entry(partner).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemovePartner(User partner)
        {
            _context.Users.Remove(partner);
            _context.SaveChanges();
        }
    }
}