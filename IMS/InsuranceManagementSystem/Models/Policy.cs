using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagementSystem.Models
{
    public class Policy
    {
        public int PolicyId { get; set; }
        public string PolicyName { get; set; }
        public string PolicyType { get; set; }
        public decimal CoverageAmount { get; set; }
        public decimal Premium { get; set; }

        public Policy() { }

        public Policy(int policyId, string policyName, string policyType, decimal coverageAmount, decimal premium)
        {
            PolicyId = policyId;
            PolicyName = policyName;
            PolicyType = policyType;
            CoverageAmount = coverageAmount;
            Premium = premium;
        }

        public override string ToString()
        {
            return $"PolicyId: {PolicyId}, Name: {PolicyName}, Type: {PolicyType}, Coverage: {CoverageAmount}, Premium: {Premium}";
        }
    }
}
