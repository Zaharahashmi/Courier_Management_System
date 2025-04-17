using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceManagementSystem.Models;
using InsuranceManagementSystem.myexceptions;
using InsuranceManagementSystem.util;

namespace InsuranceManagementSystem.dao
{
    public class InsuranceServiceImpl: IPolicyService
    {

        public bool CreatePolicy(Policy policy)
        {
            string query = "INSERT INTO Policy (PolicyId, PolicyName, PolicyType, CoverageAmount, Premium) " +
                           "VALUES (@PolicyId, @PolicyName, @PolicyType, @CoverageAmount, @Premium)";
            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PolicyId", policy.PolicyId);
                    cmd.Parameters.AddWithValue("@PolicyName", policy.PolicyName);
                    cmd.Parameters.AddWithValue("@PolicyType", policy.PolicyType);
                    cmd.Parameters.AddWithValue("@CoverageAmount", policy.CoverageAmount);
                    cmd.Parameters.AddWithValue("@Premium", policy.Premium);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("PRIMARY KEY") || ex.Message.Contains("UNIQUE KEY"))
                {
                    Console.WriteLine("Error: Duplicate Policy ID. This Policy already exists.");
                }
                else
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
                return false;
            }
        }

        public Policy GetPolicy(int policyId)
        {
            string query = "SELECT * FROM Policy WHERE PolicyId = @PolicyId";
            using (SqlConnection connection = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@PolicyId", policyId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Policy(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetDecimal(3),
                            reader.GetDecimal(4)
                        );
                    }
                }
            }
            throw new PolicyNotFoundException("Policy not found with ID: " + policyId);
        }

        public List<Policy> GetAllPolicies()
        {
            string query = "SELECT * FROM Policy";
            List<Policy> policies = new List<Policy>();
            using (SqlConnection connection = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, connection))
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
            return policies;
        }

        public bool UpdatePolicy(Policy policy)
        {
            string query = "UPDATE Policy SET PolicyName = @PolicyName, PolicyType = @PolicyType, " +
                           "CoverageAmount = @CoverageAmount, Premium = @Premium WHERE PolicyId = @PolicyId";
            using (SqlConnection connection = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@PolicyId", policy.PolicyId);
                cmd.Parameters.AddWithValue("@PolicyName", policy.PolicyName);
                cmd.Parameters.AddWithValue("@PolicyType", policy.PolicyType);
                cmd.Parameters.AddWithValue("@CoverageAmount", policy.CoverageAmount);
                cmd.Parameters.AddWithValue("@Premium", policy.Premium);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeletePolicy(int policyId)
        {
            string query = "DELETE FROM Policy WHERE PolicyId = @PolicyId";
            using (SqlConnection connection = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@PolicyId", policyId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}

