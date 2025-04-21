using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanaceManagementSystem.model;
using FinanaceManagementSystem.myexceptions;
using FinanaceManagementSystem.util;
namespace FinanaceManagementSystem.dao
{
    public class FinanceRepositoryImpl:IFinaceRepository
    {
        public bool CreateUser(Users users)
        {
            string query = "INSERT INTO Users VALUES (@UserId, @Username, @Password, @Email)";
            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserId", users.UserId);
                    cmd.Parameters.AddWithValue("@Username", users.Username);
                    cmd.Parameters.AddWithValue("@Password", users.Password);
                    cmd.Parameters.AddWithValue("@Email", users.Email);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("PRIMARY KEY") || ex.Message.Contains("UNIQUE KEY"))
                    Console.WriteLine("Error: Duplicate User ID. This user already exists.");
                else
                    Console.WriteLine("SQL Error while creating user: " + ex.Message);
                return false;
            }
        }
        public bool CreateExpense(Expenses expenses)
        {
            string query = "INSERT INTO Expenses VALUES (@ExpenseId, @UserId, @Amount, @CategoryId, @Date, @Description)";
            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ExpenseId", expenses.ExpenseId);
                    cmd.Parameters.AddWithValue("@UserId", expenses.UserId);
                    cmd.Parameters.AddWithValue("@Amount", expenses.Amount);
                    cmd.Parameters.AddWithValue("@CategoryId", expenses.CategoryId);
                    cmd.Parameters.AddWithValue("@Date", expenses.Date);
                    cmd.Parameters.AddWithValue("@Description", expenses.Description);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("FOREIGN KEY"))
                    Console.WriteLine("Error: Invalid User ID or Category ID.");
                else if (ex.Message.Contains("PRIMARY KEY"))
                    Console.WriteLine("Error: Duplicate Expense ID. This expense already exists.");
                else
                    Console.WriteLine("SQL Error while creating expense: " + ex.Message);
                return false;
            }
        }
        public bool DeleteUser(int userId)
        {
            string query = "DELETE FROM Users WHERE User_Id = @UserId";
            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new UserNotFoundException("User ID not found: " + userId);
                    return true;
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("REFERENCE"))
                    Console.WriteLine("Error: Cannot delete user.");
                else
                    Console.WriteLine("SQL Error while deleting user: " + ex.Message);
                return false;
            }
        }

        public bool DeleteExpense(int expenseId)
        {
            string query = "DELETE FROM Expenses WHERE Expense_Id = @ExpenseId";
            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ExpenseId", expenseId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new ExpenseNotFoundException("Expense ID not found: " + expenseId);
                    return true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error while deleting expense: " + ex.Message);
                return false;
            }
        }

        public List<Expenses> GetAllExpenses(int userId)
        {
            List<Expenses> expenses = new List<Expenses>();
            string query = "SELECT * FROM Expenses WHERE User_Id = @UserId";
            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            expenses.Add(new Expenses(
                                reader.GetInt32(0),
                                reader.GetInt32(1),
                                reader.GetDecimal(2),
                                reader.GetInt32(3),
                                reader.GetDateTime(4),
                                reader.GetString(5)
                            ));
                        }
                    }
                }
                if (expenses.Count == 0)
                {
                    string message = $"No expenses found for user: {userId}";
                    Console.WriteLine(message);
                    throw new ExpenseNotFoundException(message);
                }
                return expenses;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error while fetching expenses: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error while fetching expenses: " + ex.Message);
                throw;
            }
        }

        public bool UpdateExpense(int userId, Expenses updatedExpense)
        {
            string query = "UPDATE Expenses SET Amount = @Amount, Category_Id = @CategoryId, Date = @Date, Description = @Description WHERE Expense_Id = @ExpenseId AND User_Id = @UserId";
            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Amount", updatedExpense.Amount);
                    cmd.Parameters.AddWithValue("@CategoryId", updatedExpense.CategoryId);
                    cmd.Parameters.AddWithValue("@Date", updatedExpense.Date);
                    cmd.Parameters.AddWithValue("@Description", updatedExpense.Description);
                    cmd.Parameters.AddWithValue("@ExpenseId", updatedExpense.ExpenseId);
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                        throw new ExpenseNotFoundException("No matching expense to update.");
                    return true;
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("FOREIGN KEY"))
                    Console.WriteLine("Error: Invalid Category ID.");
                else
                    Console.WriteLine("SQL Error while updating expense: " + ex.Message);
                return false;
            }
        }
    }
}
