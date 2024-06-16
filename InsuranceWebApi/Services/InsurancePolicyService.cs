using InsuranceWebApi.Interfaces;
using InsuranceWebApi.Models;

namespace InsuranceWebApi.Services
{
    public class InsurancePolicyService : IInsurancePolicyService
    {
        private readonly IInsurancePolicyRepository _insurancePolicyRepository;

        public InsurancePolicyService(IInsurancePolicyRepository insurancePolicyRepository)
        {
            _insurancePolicyRepository = insurancePolicyRepository;
        }

        public async Task<bool> DeleteInsurancePolicyById(int policyId)
        {
            return await _insurancePolicyRepository.DeleteInsurancePolicyById(policyId);
        }

        public IEnumerable<InsurancePolicyModel?> GetAllInsurancePoliciesByUserId(int userId)
        {
            return _insurancePolicyRepository.GetAllInsurancePoliciesByUserId(userId);
        }

        public async Task<InsurancePolicyModel?> GetInsurancePolicyById(int policyId)
        {
            return await _insurancePolicyRepository.GetInsurancePolicyById(policyId);
        }

        public async Task<bool> InsertInsurancePolicy(InsurancePolicyModel policyToInsert)
        {
            return await _insurancePolicyRepository.InsertInsurancePolicy(policyToInsert);
        }

        public async Task<bool> UpdateInsurancePolicy(InsurancePolicyModel policyToUpdate)
        {
            return await _insurancePolicyRepository.UpdateInsurancePolicy(policyToUpdate);
        }
    }
}
