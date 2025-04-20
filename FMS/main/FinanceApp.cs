using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanaceManagementSystem.dao;
using FinanaceManagementSystem.model;
using FinanaceManagementSystem.myexceptions;

namespace FinanaceManagementSystem.main
{
    public class FinanceApp
    {
        private FinanceRepositoryImpl repository;

        public FinanceApp()
        {
            repository = new FinanceRepositoryImpl();
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\nFinance Management System");
                Console.WriteLine("----------------------------");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Delete User");
                Console.WriteLine("3. Add Expense");
                Console.WriteLine("4. Update Expense");
                Console.WriteLine("5. View Expenses by User");
                Console.WriteLine("6. Delete Expense");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": AddUser(); break;
                    case "2": DeleteUser(); break;
                    case "3": AddExpense(); break;
                    case "4": UpdateExpense(); break;
                    case "5": ViewExpenses(); break;
                    case "6": DeleteExpense(); break;
                    case "7": Console.WriteLine("Exiting..."); return;
                    default: Console.WriteLine("Invalid choice. Try again."); break;
                }
            }
        }

        private void AddUser()
        {
            Console.Write("Enter User ID: ");
            int userId = int.Parse(Console.ReadLine());
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Users users = new Users(userId, username, password, email);
            if (repository.CreateUser(users))
                Console.WriteLine("User added successfully.");
            else
                Console.WriteLine("Failed to add user.");
        }

        private void DeleteUser()
        {
            Console.Write("Enter User ID to delete: ");
            int userId = int.Parse(Console.ReadLine());
            try
            {
                if (repository.DeleteUser(userId))
                    Console.WriteLine("User deleted successfully.");
            }
            catch (UserNotFoundException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void AddExpense()
        {
            Console.Write("Enter Expense ID: ");
            int expenseId = int.Parse(Console.ReadLine());
            Console.Write("Enter User ID: ");
            int userId = int.Parse(Console.ReadLine());
            Console.Write("Enter Amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Category ID: ");
            int categoryId = int.Parse(Console.ReadLine());
            Console.Write("Enter Date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Description: ");
            string description = Console.ReadLine();

            Expenses expenses = new Expenses(expenseId, userId, amount, categoryId, date, description);
            if (repository.CreateExpense(expenses))
                Console.WriteLine("Expense added successfully.");
            else
                Console.WriteLine("Failed to add expense.");
        }

        private void UpdateExpense()
        {
            Console.Write("Enter Expense ID to update: ");
            int expenseId = int.Parse(Console.ReadLine());
            Console.Write("Enter User ID: ");
            int userId = int.Parse(Console.ReadLine());

            try
            {
                Console.Write("Enter New Amount: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                Console.Write("Enter New Category ID: ");
                int categoryId = int.Parse(Console.ReadLine());
                Console.Write("Enter New Date (yyyy-mm-dd): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter New Description: ");
                string description = Console.ReadLine();

                Expenses updatedExpense = new Expenses(expenseId, userId, amount, categoryId, date, description);
                if (repository.UpdateExpense(userId, updatedExpense))
                    Console.WriteLine("Expense updated successfully.");
            }
            catch (ExpenseNotFoundException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void ViewExpenses()
        {
            Console.Write("Enter User ID to view expenses: ");
            int userId = int.Parse(Console.ReadLine());
            var expenses = repository.GetAllExpenses(userId);
            foreach (var expense in expenses)
            {
                Console.WriteLine(expense);
            }
        }

        private void DeleteExpense()
        {
            Console.Write("Enter Expense ID to delete: ");
            int expenseId = int.Parse(Console.ReadLine());
            try
            {
                if (repository.DeleteExpense(expenseId))
                    Console.WriteLine("Expense deleted successfully.");
            }
            catch (ExpenseNotFoundException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
