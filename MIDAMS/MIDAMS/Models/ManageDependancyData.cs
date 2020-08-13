using System.Collections.Generic;
using System.Linq;

namespace MIDAMS.Models
{
    public static class ManageDependancyData
    {
        public class Dropdown
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public static IEnumerable<Dropdown> GetRegions()
        {
            return new List<Dropdown>()
            {
                new Dropdown {Id =1, Name = "East"},
                new Dropdown {Id =2, Name = "West"},
                new Dropdown {Id =3, Name = "North"},
                new Dropdown {Id =4, Name = "South"}
            };
        }

        public static IEnumerable<Dropdown> GetBranchLocations()
        {
            return new List<Dropdown>()
            {
                new Dropdown {Id =1, Name = "Mumbai"},
                new Dropdown {Id =2, Name = "Tardev"},
                new Dropdown {Id =3, Name = "Vashi"},
                new Dropdown {Id =4, Name = "Andheri"}
            };
        }

        public static IEnumerable<Dropdown> GetIndustryTypes()
        {
            return new List<Dropdown>()
            {
                new Dropdown {Id =1, Name = "Corporate"},
                new Dropdown {Id =2, Name = "Manufacturing Unit"},
                new Dropdown {Id =3, Name = "Institute"},
                new Dropdown {Id =4, Name = "Bank"},
                new Dropdown {Id =5, Name = "Retail"},
                new Dropdown {Id =6, Name = "Healthcare"},
                new Dropdown {Id =7, Name = "Residential"},
                new Dropdown {Id =8, Name = "Educational"},
                new Dropdown {Id =9, Name = "Commercial"}
            };
        }

        public static IEnumerable<Dropdown> GetRoleResponsibilities()
        {
            return new List<Dropdown>()
            {
                new Dropdown {Id =1, Name = "Finance"},
                new Dropdown {Id =2, Name = "Administration"},
                new Dropdown {Id =3, Name = "Operations"},
                new Dropdown {Id =4, Name = "Facility Management"},
                new Dropdown {Id =5, Name = "Procurement"},
                new Dropdown {Id =6, Name = "Human Resource"}
            };
        }

        public static IEnumerable<Dropdown> GetDesignations()
        {
            return new List<Dropdown>()
            {
                new Dropdown {Id =1, Name = "Jr. Executive"},
                new Dropdown {Id =2, Name = "Executive"},
                new Dropdown {Id =3, Name = "Sr. Executive"},
                new Dropdown {Id =4, Name = "Deputy Manager"},
                new Dropdown {Id =5, Name = "Manager"},
                new Dropdown {Id =6, Name = "General Manager"},
                new Dropdown {Id =7, Name = "AVP"},
                new Dropdown {Id =8, Name = "VP"}
            };
        }

        public static IEnumerable<Dropdown> GetDepartments()
        {
            return new List<Dropdown>()
            {
                new Dropdown {Id =1, Name = "Finance"},
                new Dropdown {Id =2, Name = "Administration"},
                new Dropdown {Id =3, Name = "Operations"},
                new Dropdown {Id =4, Name = "Facility Management"},
                new Dropdown {Id =5, Name = "Procurement"},
                new Dropdown {Id =6, Name = "Human Resource"}
            };
        }

        public static IEnumerable<Dropdown> GetRelations()
        {
            return new List<Dropdown>()
            {
                new Dropdown {Id =1, Name = "Weak"},
                new Dropdown {Id =2, Name = "Developing"},
                new Dropdown {Id =3, Name = "Strong"},
                new Dropdown {Id =4, Name = "Excellent"}                
            };
        }

        public static IEnumerable<Dropdown> GetManagementLevels()
        {
            return new List<Dropdown>()
            {
                new Dropdown {Id =1, Name = "Junior"},
                new Dropdown {Id =2, Name = "Middle"},
                new Dropdown {Id =3, Name = "Senior"},
                new Dropdown {Id =4, Name = "Corporate"}
            };
        }
    }
}