using InsuranceWebApi.AppDbContextEntity;
using InsuranceWebApi.Interfaces;
using InsuranceWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InsuranceWebApi.Repositories
{
    public class InsurancePolicyRepository : IInsurancePolicyRepository
    {
        private readonly AppDbContext _dbContext;

        public InsurancePolicyRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteInsurancePolicyById(int policyId)
        {
            var policyToDelete = await _dbContext.Policies.FindAsync(policyId);
            _dbContext.Policies.Remove(policyToDelete);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public IEnumerable<InsurancePolicyModel?> GetAllInsurancePoliciesByUserId(int userId)
        {
            var relevantPoliciesToUser = _dbContext.Policies.Where(policy => policy.UserId.Equals(userId));
            return relevantPoliciesToUser;
        }

        public async Task<InsurancePolicyModel?> GetInsurancePolicyById(int policyId)
        {
            return await _dbContext.Policies.FindAsync(policyId);
        }

        public async Task<bool> InsertInsurancePolicy(InsurancePolicyModel policyToInsert)
        {
            await _dbContext.Policies.AddAsync(policyToInsert);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateInsurancePolicy(InsurancePolicyModel policyToUpdate)
        {
            var updatedPolicy = _dbContext.Policies.Update(policyToUpdate);
            await _dbContext.SaveChangesAsync();
            return policyToUpdate.Equals(updatedPolicy);
        }
    }
}
