using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanaceManagementSystem.model
{
    public class ExpenseCategories
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ExpenseCategories() { }
        public ExpenseCategories(int categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }
        public override string ToString()
        {
            return $"CategoryId: {CategoryId}, CategoryName: {CategoryName}";
        }
    }
}
