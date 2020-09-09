using MIDAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIDAMS.Areas.Admin.Repositories
{
    public class MapClientsRepository
    {
        private readonly ApplicationDbContext _context;

        public MapClientsRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<MapClientsToPartner> GetMapClientsToPartners()
        {
            return _context.MapClientsToPartners.ToList();
        }

        public IEnumerable<User> Getsers()
        {
            return _context.Users.ToList();
        }

        public MapClientsToPartner GetMapClientsToPartner(int id)
        {
            return _context.MapClientsToPartners.FirstOrDefault(p => p.Id == id);
        }

        public void AddMapClientsToPartner(MapClientsToPartner mapClientsToPartner)
        {
            _context.MapClientsToPartners.Add(mapClientsToPartner);
            _context.SaveChanges();
        }

        public void EditMapClientsToPartner(MapClientsToPartner mapClientsToPartner)
        {
            _context.Entry(mapClientsToPartner).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveMapClientsToPartner(MapClientsToPartner mapClientsToPartner)
        {
            _context.MapClientsToPartners.Remove(mapClientsToPartner);
            _context.SaveChanges();
        }
    }
}