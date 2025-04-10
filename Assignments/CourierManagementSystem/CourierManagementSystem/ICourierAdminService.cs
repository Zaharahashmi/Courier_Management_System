using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem
{
    internal interface ICourierAdminService
    {
        int AddCourierStaff(Employee obj);
        Employee GetEmployeeById(int id);
    }
}
