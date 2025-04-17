using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.dao
{
    internal interface IClientPolicyService
    {
        bool AssignPolicyToClient(int clientId, int policyId);
        bool RemovePolicyFromClient(int clientId, int policyId);
        List<Policy> GetPoliciesByClient(int clientId);
        List<Client> GetClientsByPolicy(int policyId);
    }
}
