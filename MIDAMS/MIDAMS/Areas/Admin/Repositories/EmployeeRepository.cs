using MIDAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIDAMS.Areas.Admin.Repositories
{
    public class EmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployee(int id)
        {
            return _context.Employees.FirstOrDefault(c => c.Id == id);
        }

        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            _context.Entry(employee).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
    }
}