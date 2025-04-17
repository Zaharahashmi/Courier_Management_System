using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceManagementSystem.dao;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.mainmod
{
    internal class MainModule1
    {
        private IClientPolicyService service;

        public MainModule1()
        {
            service = new ClientPolicyServiceImpl();
        }

        public void Main1()
        {
            while (true)
            {
                Console.WriteLine("\nInsurance Management System");
                Console.WriteLine("----------------------------");
                Console.WriteLine("1. Create New Client and Assign Policies");
                Console.WriteLine("2. View Clients and Policies");
                Console.WriteLine("3. Assign Policy to Client");
                Console.WriteLine("4. Remove Policy from Client");
                Console.WriteLine("5. View Policies by Client");
                Console.WriteLine("6. View Clients by Policy");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        CreateClientWithPolicies();
                        break;
                    case "2":
                        ViewClientsWithPolicies();
                        break;
                    case "3":
                        AssignPolicyToClient();
                        break;
                    case "4":
                        RemovePolicyFromClient();
                        break;
                    case "5":
                        ViewPoliciesByClient();
                        break;
                    case "6":
                        ViewClientsByPolicy();
                        break;
                    case "7":
                        Console.WriteLine("Exit");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        private void CreateClientWithPolicies()
        {
            Console.Write("Enter Client ID: ");
            int clientId = int.Parse(Console.ReadLine());
            Console.Write("Enter Client Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Contact Info: ");
            string contact = Console.ReadLine();
            Console.Write("Enter Policy IDs: ");
            var policyIds = Console.ReadLine().Split(',').Select(int.Parse).ToList();
            bool result = false;
            foreach (var policyId in policyIds)
            {
                result = service.AssignPolicyToClient(clientId, policyId);
            }

            if (result)
                Console.WriteLine("Client created and policies assigned successfully.");
            else
                Console.WriteLine("Failed to create client or assign policies.");
        }


        private void ViewClientsWithPolicies()
        {
            Console.Write("Enter Client ID: ");
            int clientId3 = int.Parse(Console.ReadLine());

            List<Policy> policies = service.GetPoliciesByClient(clientId3);
            if (policies.Count == 0)
            {
                Console.WriteLine("No policies found for this client.");
            }
            else
            {
                Console.WriteLine("Policies assigned to the client:");
                foreach (Policy p in policies)
                {
                    Console.WriteLine($"ID: {p.PolicyId}, Name: {p.PolicyName}, Type: {p.PolicyType}, Coverage: {p.CoverageAmount}, Premium: {p.Premium}");
                }
            }
        }


        private void AssignPolicyToClient()
        {
            Console.Write("Enter Client ID: ");
            int clientId = int.Parse(Console.ReadLine());
            Console.Write("Enter Policy ID: ");
            int policyId = int.Parse(Console.ReadLine());

            bool result = service.AssignPolicyToClient(clientId, policyId);

            if (result)
                Console.WriteLine("Policy assigned successfully.");
            else
                Console.WriteLine("Failed to assign policy to the client.");
        }

        private void RemovePolicyFromClient()
        {
            Console.Write("Enter Client ID: ");
            int clientId = int.Parse(Console.ReadLine());
            Console.Write("Enter Policy ID: ");
            int policyId = int.Parse(Console.ReadLine());

            bool result = service.RemovePolicyFromClient(clientId, policyId);

            if (result)
                Console.WriteLine("Policy removed successfully.");
            else
                Console.WriteLine("Failed to remove policy from the client.");
        }

        private void ViewPoliciesByClient()
        {
            Console.Write("Enter Client ID: ");
            int clientId = int.Parse(Console.ReadLine());

            var policies = service.GetPoliciesByClient(clientId);
            Console.WriteLine($"Policies for Client {clientId}:");

            foreach (var policy in policies)
            {
                Console.WriteLine($"Policy: {policy.PolicyName}, Coverage: {policy.CoverageAmount}");
            }
        }

        private void ViewClientsByPolicy()
        {
            Console.Write("Enter Policy ID: ");
            int policyId = int.Parse(Console.ReadLine());

            var clients = service.GetClientsByPolicy(policyId);
            Console.WriteLine($"Clients for Policy {policyId}:");

            foreach (var client in clients)
            {
                Console.WriteLine($"Client: {client.ClientName}, Contact: {client.ContactInfo}");
            }
        }
    }
}
 



