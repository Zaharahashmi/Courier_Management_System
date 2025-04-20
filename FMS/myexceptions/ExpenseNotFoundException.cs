using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanaceManagementSystem.myexceptions
{
    public class ExpenseNotFoundException:Exception
    {
        public ExpenseNotFoundException() { }
        public ExpenseNotFoundException(string message) : base(message) { }
    }
}
