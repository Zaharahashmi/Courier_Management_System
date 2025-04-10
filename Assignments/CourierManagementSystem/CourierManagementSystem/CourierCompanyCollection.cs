using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem
{
    internal class CourierCompanyCollection
    {
        public List<Courier> Couriers { get; set; } = new List<Courier>();
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<User> Users { get; set; } = new List<User>();
        public List<CourierServices> Services { get; set; } = new List<CourierServices>();
        public List<Location> Locations { get; set; } = new List<Location>();
    }
}
