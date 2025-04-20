using System;
using System.Collections.Generic;
using NUnit.Framework;
using FinanaceManagementSystem.dao;
using FinanaceManagementSystem.model;
using FinanaceManagementSystem.myexceptions;

namespace TestProject
{
    [TestFixture]
    internal class TestCases
    {
        private FinanceRepositoryImpl repository;

        [SetUp]
        public void SetUp()
        {
            repository = new FinanceRepositoryImpl();
        }

        [Test]
        public void CreateUserShouldReturnTrueWhenUserIsValid()
        {
            var user = new Users(115, "newuser1", "pass456", "newuser1@example.com");
            var result = repository.CreateUser(user);
            Assert.IsTrue(result);
        }

        [Test]
        public void CreateExpenseShouldReturnTrueWhenExpenseIsValid()
        {
            var expense = new Expenses(1015, 1, 250.0m, 101, DateTime.Now, "Test Expense");
            var result = repository.CreateExpense(expense);
            Assert.IsTrue(result);
        }

        [Test]
        public void GetAllExpensesShouldReturnListWhenUserHasExpenses()
        {
            int userId = 1;
            var result = repository.GetAllExpenses(userId);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<Expenses>>(result);
            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        public void GetAllExpensesShouldThrowExpenseNotFoundExceptionWhenNoExpensesExist()
        {
            int nonExistingUserId = 9999;
            var ex = Assert.Throws<ExpenseNotFoundException>(() => repository.GetAllExpenses(nonExistingUserId));
            Assert.That(ex.Message, Does.Contain("No expenses found"));
        }

        [Test]
        public void DeleteUserShouldThrowUserNotFoundExceptionWhenUserDoesNotExist()
        {
            int userId = -1;
            var ex = Assert.Throws<UserNotFoundException>(() => repository.DeleteUser(userId));
            Assert.That(ex.Message, Does.Contain("User ID not found"));
        }

        [Test]
        public void DeleteExpenseShouldThrowExpenseNotFoundExceptionWhenExpenseDoesNotExist()
        {
            int expenseId = -1;
            var ex = Assert.Throws<ExpenseNotFoundException>(() => repository.DeleteExpense(expenseId));
            Assert.That(ex.Message, Does.Contain("Expense ID not found"));
        }
    }
}
