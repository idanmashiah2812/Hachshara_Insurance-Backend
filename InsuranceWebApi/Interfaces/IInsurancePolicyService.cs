using InsuranceWebApi.Models;

namespace InsuranceWebApi.Interfaces
{
    /// <summary>
    /// The interface defines InsurancePolicy functionallity which has been called and invoked by the api
    /// </summary>
    public interface IInsurancePolicyService
    {
        Task<InsurancePolicyModel?> GetInsurancePolicyById(int policyId);
        IEnumerable<InsurancePolicyModel?> GetAllInsurancePoliciesByUserId(int userId);
        Task<bool> InsertInsurancePolicy(InsurancePolicyModel policyToInsert);
        Task<bool> UpdateInsurancePolicy(InsurancePolicyModel policyToUpdate);
        Task<bool> DeleteInsurancePolicyById(int policyId);
    }
}
