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

        public IEnumerable<Partner> GetPartners2()
        {
            return _context.Partners.ToList();
        }

        public User GetPartner(int id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }

        public Partner GetPartner2(int id)
        {
            return _context.Partners.FirstOrDefault(p => p.UserId == id);
        }

        public Partner GetPartner3(int id)
        {
            return _context.Partners.FirstOrDefault(p => p.Id == id);
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

        public void UpdatePartner2(Partner partner)
        {
            _context.Entry(partner).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemovePartner(User partner)
        {
            _context.Users.Remove(partner);
            _context.SaveChanges();
        }

        public void RemovePartner2(Partner partner)
        {
            _context.Partners.Remove(partner);
            _context.SaveChanges();
        }

        // Partner Document Details
        #region
        public IEnumerable<PartnerDocumentDetail> GetDocumentDetails()
        {
            return _context.PartnerDocumentDetails.ToList();
        }

        public PartnerDocumentDetail GetDocumentDetail(int id)
        {
            return _context.PartnerDocumentDetails.FirstOrDefault(c => c.Id == id);
        }

        public void AddDocumentDetail(PartnerDocumentDetail documentDetail)
        {
            _context.PartnerDocumentDetails.Add(documentDetail);
            _context.SaveChanges();
        }

        public void UpdateDocumentDetail(PartnerDocumentDetail documentDetail)
        {
            _context.Entry(documentDetail).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveDocumentDetail(PartnerDocumentDetail documentDetail)
        {
            _context.PartnerDocumentDetails.Remove(documentDetail);
            _context.SaveChanges();
        }
        #endregion
    }
}