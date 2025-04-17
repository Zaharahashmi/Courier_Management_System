using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceManagementSystem.Models;
using InsuranceManagementSystem.util;
namespace InsuranceManagementSystem.dao
{
    internal class ClientPolicyServiceImpl: IClientPolicyService
    {
        public bool AssignPolicyToClient(int clientId, int policyId)
        {
            string query = "INSERT INTO ClientPolicy (ClientId, PolicyId) VALUES (@ClientId, @PolicyId)";
            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ClientId", clientId);
                cmd.Parameters.AddWithValue("@PolicyId", policyId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool RemovePolicyFromClient(int clientId, int policyId)
        {
            string query = "DELETE FROM ClientPolicy WHERE ClientId = @ClientId AND PolicyId = @PolicyId";
            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ClientId", clientId);
                cmd.Parameters.AddWithValue("@PolicyId", policyId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<Policy> GetPoliciesByClient(int clientId)
        {
            List<Policy> policies = new List<Policy>();
            string query = @"SELECT p.PolicyId, p.PolicyName, p.PolicyType, p.CoverageAmount, p.Premium FROM Policy p JOIN ClientPolicy cp ON p.PolicyId = cp.PolicyId WHERE cp.ClientId = @ClientId";

            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ClientId", clientId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        policies.Add(new Policy(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetDecimal(3),
                            reader.GetDecimal(4)
                        ));
                    }
                }
            }
            return policies;
        }

        public List<Client> GetClientsByPolicy(int policyId)
        {
            List<Client> clients = new List<Client>();
            string query = @"SELECT c.ClientId, c.ClientName, c.ContactInfo FROM Client c JOIN ClientPolicy cp ON c.ClientId = cp.ClientId WHERE cp.PolicyId = @PolicyId";

            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@PolicyId", policyId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clients.Add(new Client
                        {
                            ClientId = reader.GetInt32(0),
                            ClientName = reader.GetString(1),
                            ContactInfo = reader.GetString(2)
                        });
                    }
                }
            }
            return clients;
        }
    }
}
