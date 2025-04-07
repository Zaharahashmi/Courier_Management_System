using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement
{
    internal class CourierAdminService:ICourierAdminService
    {
        private static List<Employee> employeeList = new List<Employee>();
        private static long employeeIdSeed = 1001;

        public int AddCourierStaff(Employee obj)
        {
            obj.EmployeeID = employeeIdSeed++;
            employeeList.Add(obj);
            return (int)obj.EmployeeID;
        }
        public Employee GetEmployeeById(long id)
        {
            foreach (Employee emp in employeeList)
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
