using InsuranceWebApi.Interfaces;
using InsuranceWebApi.Logger;
using InsuranceWebApi.Models;
using InsuranceWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsurancePoliciesController : ControllerBase
    {
        private readonly IInsurancePolicyService _insurancePolicyService;

        public InsurancePoliciesController(IInsurancePolicyService insurancePolicyService)
        {
            _insurancePolicyService = insurancePolicyService;
        }

        [HttpGet("Find/{id}")]
        public async Task<IActionResult> GetInsurancePolicy(int id)
        {
            var policy = await _insurancePolicyService.GetInsurancePolicyById(id);

            if (policy == null)
                return NotFound();

            return Ok(policy);
        }
        
        [HttpGet("Find/AllByUserId/{userId}")]
        public IActionResult GetAllInsurancePoliciesByUserId(int userId)
        {
            var policiesOfUser = _insurancePolicyService.GetAllInsurancePoliciesByUserId(userId);

            if (policiesOfUser == null)
                return NotFound();

            if (policiesOfUser.Any())
                return NoContent();

            return Ok(policiesOfUser);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> InsertInsurancePolicy([FromBody] InsurancePolicyModel policy)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _insurancePolicyService.InsertInsurancePolicy(policy);

                if (!result)
                    return StatusCode(500);

                CustomLogger.Instance.Info($"Policy {policy.ID} succussfully inserted to the db");
                return CreatedAtAction(nameof(GetInsurancePolicy), new { id = policy.ID }, policy);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateInsurancePolicy(int id, [FromBody] InsurancePolicyModel policy)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _insurancePolicyService.UpdateInsurancePolicy(policy);

                if (!result)
                    return StatusCode(500);

                CustomLogger.Instance.Info($"Policy {id} updated succussfully");
                return CreatedAtAction(nameof(GetInsurancePolicy), new { id = policy.ID }, policy);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsurancePolicy(int id)
        {
            var isDeleted = await _insurancePolicyService.DeleteInsurancePolicyById(id);

            if (!isDeleted)
                return NotFound();

            CustomLogger.Instance.Info($"Policy {id} deleted succussfully");
            return Ok(isDeleted);
        }
    }
}
