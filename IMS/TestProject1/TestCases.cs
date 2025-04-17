using NUnit.Framework;
using InsuranceManagementSystem;
using InsuranceManagementSystem.myexceptions;
using InsuranceManagementSystem.dao;
using InsuranceManagementSystem.Models;

namespace TestProject1
{
    [TestFixture]
    public class TestCases
    {
        private InsuranceServiceImpl service;

        [SetUp]
        public void Setup()
        {
            service = new InsuranceServiceImpl();
        }

        [Test]
        public void CreatePolicyWithValidPolicyShouldReturnTrue()
        {
            // Arrange
            var policy = new Policy
            {
                PolicyId = 1240,         
                PolicyName = "Life Secure",
                PolicyType = "Life",
                CoverageAmount = 500000,
                Premium = 2500
            };

            // Act
            bool result = service.CreatePolicy(policy);

            // Assert
            Assert.IsTrue(result, "Policy should be created successfully.");
        }

        [Test]
        public void UpdatePolicyValidPolicyShouldReturnTrue()
        {
            // Arrange
            var policy = new Policy
            {
                PolicyId = 1234,
                PolicyName = "Life Secure",
                PolicyType = "Life",
                CoverageAmount = 500000,
                Premium = 2500
            };
            service.CreatePolicy(policy);

            // Act
            bool result = service.UpdatePolicy(updatedPolicy);

            // Assert
            Assert.IsTrue(result, "Policy should be updated successfully.");
        }

        [Test]
        public void GetPolicyValidPolicyIdShouldReturnPolicy()
        {
            // Arrange
            var policy = new Policy
            {
                PolicyId = 1234,
                PolicyName = "Life Secure",
                PolicyType = "Life",
                CoverageAmount = 500000,
                Premium = 2500
            };
            service.CreatePolicy(policy);

            // Act
            var result = service.GetPolicy(1234);

            // Assert
            Assert.AreEqual(1234, result.PolicyId, "Policy ID should match.");
            Assert.AreEqual("Life Secure", result.PolicyName, "Policy Name should match.");
        }

        [Test]
        public void DeletePolicyValidPolicyIdShouldReturnTrue()
        {
            // Arrange

            var policy = new Policy
            {
                PolicyId = 1234,
                PolicyName = "Life Secure",
                PolicyType = "Life",
                CoverageAmount = 500000,
                Premium = 2500
            };
            service.CreatePolicy(policy);

            // Act
            bool result = service.DeletePolicy(1234);

            // Assert
            Assert.IsTrue(result, "Policy should be deleted successfully.");
        }

       
    }
}
