using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem
{
    internal class CourierCompany
    {
        public Courier[] Couriers = new Courier[100];
        public Employee[] Employees = new Employee[100];
        public User[] Users = new User[100];
        public CourierServices[] Services = new CourierServices[100];
        public Location[] Locations = new Location[100];

        public int courierIndex = 0;
        public int employeeIndex = 0;
        public int userIndex = 0;
        public int serviceIndex = 0;
        public int locationIndex = 0;
    }
}
