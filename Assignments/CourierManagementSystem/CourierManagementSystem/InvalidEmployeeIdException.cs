using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem
{
    internal class InvalidEmployeeIdException : Exception
    {
        public InvalidEmployeeIdException(string message) : base(message) { }
    }
}
