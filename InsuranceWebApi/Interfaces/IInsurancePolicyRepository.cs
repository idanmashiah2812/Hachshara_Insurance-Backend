using InsuranceWebApi.Models;

namespace InsuranceWebApi.Interfaces
{
    /// <summary>
    /// The interface defines InsurancePolicy functionallity among a db repository
    /// </summary>
    public interface IInsurancePolicyRepository
    {
        Task<InsurancePolicyModel?> GetInsurancePolicyById(int policyId);
        IEnumerable<InsurancePolicyModel?> GetAllInsurancePoliciesByUserId(int userId);
        Task<bool> InsertInsurancePolicy(InsurancePolicyModel policyToInsert);
        Task<bool> UpdateInsurancePolicy(InsurancePolicyModel policyToUpdate);
        Task<bool> DeleteInsurancePolicyById(int policyId);
    }
}
