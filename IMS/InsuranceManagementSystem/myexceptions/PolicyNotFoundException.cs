using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagementSystem.myexceptions
{
    internal class PolicyNotFoundException: Exception
    {
        public PolicyNotFoundException() { }
        public PolicyNotFoundException(string message) : base(message) { }
    }
}
