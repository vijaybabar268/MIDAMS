using System.Configuration;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;

namespace MIDAMS.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ApplicationDbContext : DbContext
    {
        //string isProduction = ConfigurationManager.AppSettings["IsProduction"];                

        public ApplicationDbContext()
            : base("MySql_CS")
        {
            this.Configuration.ValidateOnSaveEnabled = false;
        }
                
        public static ApplicationDbContext Create()
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
            return new ApplicationDbContext();
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientRoleResponsibility> ClientRoleResponsibilities { get; set; }
        // Ajit will add Client Contact Details Module
        // Ajit will add Client Relation Module

        public DbSet<Employee> Employees { get; set; }
        // Ajit will add employee doc details
        // Ajit will add employee bank details
        // Ajit will add employee pf details
        // Ajit will add employee state insurance details

        // Ajit will add Vendor module

        public DbSet<MapEmployeesToClient> MapEmployeesToClients { get; set; }
        public DbSet<MapClientsToPartner> MapClientsToPartners { get; set; }

        public DbSet<Partner> Partners { get; set; }
        public DbSet<PartnerDocumentDetail> PartnerDocumentDetails { get; set; }
        public DbSet<PartnerBankDetail> PartnerBankDetails { get; set; }
        public DbSet<PartnerResponsibleSite> PartnerResponsibleSites { get; set; }

    }
}