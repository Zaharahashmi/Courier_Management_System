using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem
{
    internal class CourierAdminServiceCollectionImpl : CourierUserServiceCollectionImpl, ICourierAdminService
    {

        private int employeeIdSeed = 1001;
        public CourierAdminServiceCollectionImpl(CourierCompanyCollection companyObj) : base(companyObj) { }

        public int AddCourierStaff(Employee obj)
        {
            obj.EmployeeID = employeeIdSeed++;
            companyObj.Employees.Add(obj);
            return obj.EmployeeID;
        }
        public Employee GetEmployeeById(int id)
        {
            foreach (Employee emp in companyObj.Employees)
            {
                if (emp.EmployeeID == id)
                {
                    return emp;
                }
            }
            throw new InvalidEmployeeIdException($"Employee with ID {id} does not exist.");
        }
    }
}
