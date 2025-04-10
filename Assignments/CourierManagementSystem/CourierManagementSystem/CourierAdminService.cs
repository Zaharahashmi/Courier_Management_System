using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem
{
    internal class CourierAdminService : ICourierAdminService
    {
        private List<Employee> employeeList = new List<Employee>();
        private int employeeId = 1001;

        public int AddCourierStaff(Employee obj)
        {
            obj.EmployeeID = employeeId++;
            employeeList.Add(obj);
            return (int)obj.EmployeeID;
        }
        public Employee GetEmployeeById(int id)
        {
            foreach (Employee emp in employeeList)
            {
                if (emp.EmployeeID == id)
                {
                    return emp;
                }
            }

            throw new InvalidEmployeeIdException($"No employee found with ID: {id}");
        }
    }
}
