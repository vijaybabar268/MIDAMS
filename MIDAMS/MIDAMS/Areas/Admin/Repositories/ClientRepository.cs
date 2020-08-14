using MIDAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIDAMS.Areas.Admin.Repositories
{
    public class ClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Client> GetClients()
        {
            return _context.Clients.ToList();
        }
        
        public Client GetClient(int id)
        {
            return _context.Clients.FirstOrDefault(c => c.Id == id);
        }
        
        public void AddClient(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public void UpdateClient(Client client)
        {
            _context.Entry(client).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveClient(Client client)
        {
            _context.Clients.Remove(client);
            _context.SaveChanges();
        }
    }
}