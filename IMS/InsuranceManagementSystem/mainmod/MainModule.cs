using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceManagementSystem.dao;
using InsuranceManagementSystem.Models;
using InsuranceManagementSystem.myexceptions;

namespace InsuranceManagementSystem.mainmod
{
    public class MainModule
    {
        private InsuranceServiceImpl service;

        public MainModule()
        {
            service = new InsuranceServiceImpl();
        }

        public void Main()
        {
            while (true)
            {
                Console.WriteLine("\nInsurance Management System");
                Console.WriteLine("----------------------------");
                Console.WriteLine("1. Create New Policy");
                Console.WriteLine("2. Update Policy");
                Console.WriteLine("3. View All Policies");
                Console.WriteLine("4. Get Policy by ID");
                Console.WriteLine("5. Delete Policy");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        CreatePolicy();
                        break;
                    case "2":
                        UpdatePolicy();
                        break;
                    case "3":
                        ViewAllPolicies();
                        break;
                    case "4":
                        GetPolicyById();
                        break;
                    case "5":
                        DeletePolicy();
                        break;
                    case "6":
                        Console.WriteLine("Exit");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        private void CreatePolicy()
        {
            Console.Write("Enter Policy ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Policy Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Policy Type: ");
            string type = Console.ReadLine();
            Console.Write("Enter Coverage Amount: ");
            decimal coverage = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Premium: ");
            decimal premium = decimal.Parse(Console.ReadLine());

            Policy policy = new Policy(id, name, type, coverage, premium);
            bool result = service.CreatePolicy(policy);

            if (result)
                Console.WriteLine("Policy created successfully.");
            else
                Console.WriteLine("Failed to create policy.");
        }

        private void UpdatePolicy()
        {
            Console.Write("Enter Policy ID to update: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                Policy existingPolicy = service.GetPolicy(id);
                Console.Write("Enter New Policy Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter New Policy Type: ");
                string type = Console.ReadLine();
                Console.Write("Enter New Coverage Amount: ");
                decimal coverage = decimal.Parse(Console.ReadLine());
                Console.Write("Enter New Premium: ");
                decimal premium = decimal.Parse(Console.ReadLine());

                Policy policy = new Policy(id, name, type, coverage, premium);

                bool result = service.UpdatePolicy(policy);
                if (result)
                    Console.WriteLine("Policy updated successfully.");
                else
                    Console.WriteLine("Failed to update policy.");
            }
            catch (PolicyNotFoundException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
        }

        private void ViewAllPolicies()
        {
            var policies = service.GetAllPolicies();
            Console.WriteLine("Policy List:");
            foreach (var policy in policies)
            {
                Console.WriteLine(policy);
            }
        }

        private void GetPolicyById()
        {
            Console.Write("Enter Policy ID: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                Policy policy = service.GetPolicy(id);
                Console.WriteLine("Policy Details:");
                Console.WriteLine(policy);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DeletePolicy()
        {
            Console.Write("Enter Policy ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            bool result = service.DeletePolicy(id);
            if (result)
                Console.WriteLine("Policy deleted successfully.");
            else
                Console.WriteLine("Policy not found or failed to delete.");
        }
    }
}
