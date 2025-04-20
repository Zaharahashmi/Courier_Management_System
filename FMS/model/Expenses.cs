using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanaceManagementSystem.model
{
    public class Expenses
    {
        public int ExpenseId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Expenses() { }
        public Expenses(int expenseId, int userId, decimal amount, int categoryId, DateTime date, string description)
        {
            ExpenseId = expenseId;
            UserId = userId;
            Amount = amount;
            CategoryId = categoryId;
            Date = date;
            Description = description;
        }
        public override string ToString()
        {
            return $"ExpenseId: {ExpenseId}, UserId: {UserId}, Amount: {Amount}, CategoryId: {CategoryId}, Date: {Date.ToShortDateString()}, Description: {Description}";
        }
    }
}
