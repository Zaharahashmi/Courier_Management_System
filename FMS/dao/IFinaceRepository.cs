using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanaceManagementSystem.model;

namespace FinanaceManagementSystem.dao
{
    internal interface IFinaceRepository
    {
        bool CreateUser(Users users);
        bool CreateExpense(Expenses expenses);
        bool DeleteUser(int userId);
        bool DeleteExpense(int expenseId);
        List<Expenses> GetAllExpenses(int userId);
        bool UpdateExpense(int userId, Expenses expenses);
    }
}
