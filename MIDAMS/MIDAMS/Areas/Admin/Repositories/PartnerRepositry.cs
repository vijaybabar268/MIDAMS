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

        // Partner Bank Details
        #region
        public IEnumerable<PartnerBankDetail> GetBankDetails()
        {
            return _context.PartnerBankDetails.ToList();
        }

        public PartnerBankDetail GetBankDetail(int id)
        {
            return _context.PartnerBankDetails.FirstOrDefault(c => c.Id == id);
        }

        public void AddBankDetail(PartnerBankDetail bankDetail)
        {
            _context.PartnerBankDetails.Add(bankDetail);
            _context.SaveChanges();
        }

        public void UpdateBankDetail(PartnerBankDetail bankDetail)
        {
            _context.Entry(bankDetail).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveBankDetail(PartnerBankDetail bankDetail)
        {
            _context.PartnerBankDetails.Remove(bankDetail);
            _context.SaveChanges();
        }

        // Partner Responsible Site
        public IEnumerable<PartnerResponsibleSite> GetResponsibleSites()
        {
            return _context.PartnerResponsibleSites.ToList();
        }

        public PartnerResponsibleSite GetResponsibleSite(int id)
        {
            return _context.PartnerResponsibleSites.FirstOrDefault(c => c.Id == id);
        }

        public void AddResponsibleSite(PartnerResponsibleSite responsibleSite)
        {
            _context.PartnerResponsibleSites.Add(responsibleSite);
            _context.SaveChanges();
        }

        public void UpdateResponsibleSite(PartnerResponsibleSite responsibleSite)
        {
            _context.Entry(responsibleSite).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveResponsibleSite(PartnerResponsibleSite responsibleSite)
        {
            _context.PartnerResponsibleSites.Remove(responsibleSite);
            _context.SaveChanges();
        }

        // Partner Tearms and Conditions
        public IEnumerable<PartnerTearmsCondition> GetTearmsConditions()
        {
            return _context.PartnerTearmsConditions.ToList();
        }

        public PartnerTearmsCondition GetTearmsCondition(int id)
        {
            return _context.PartnerTearmsConditions.FirstOrDefault(c => c.Id == id);
        }

        public void AddTearmsCondition(PartnerTearmsCondition partnerTearmsCondition)
        {
            _context.PartnerTearmsConditions.Add(partnerTearmsCondition);
            _context.SaveChanges();
        }

        public void UpdateTearmsCondition(PartnerTearmsCondition partnerTearmsCondition)
        {
            _context.Entry(partnerTearmsCondition).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveTearmsCondition(PartnerTearmsCondition partnerTearmsCondition)
        {
            _context.PartnerTearmsConditions.Remove(partnerTearmsCondition);
            _context.SaveChanges();
        }
        #endregion
    }
}