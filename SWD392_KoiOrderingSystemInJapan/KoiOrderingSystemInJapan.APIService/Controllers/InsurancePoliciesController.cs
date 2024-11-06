using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystemInJapan.Data.DBContext;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using KoiOrderingSystemInJapan.Service.Services;
using KoiOrderingSystemInJapan.Service.Interfaces;
namespace KoiOrderingSystemInJapan.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsurancePoliciesController : ControllerBase
    {
        private readonly IInsurancePolicyService _insurancePolicyService;
        public InsurancePoliciesController(IInsurancePolicyService insurancePolicyService) => _insurancePolicyService = insurancePolicyService;
        // GET: api/InsurancePolicies
        [HttpGet]
        public async Task<IServiceResult> GetInsurancePolicies()
        {
            return await _insurancePolicyService.GetAll();
        }
        // GET: api/InsurancePolicies/5
        [HttpGet("{id}")]
        public async Task<IServiceResult> GetInsurancePolicy(int id)
        {
            var insurancePolicy = await _insurancePolicyService.GetById(id);
            return insurancePolicy;
        }
        // PUT: api/InsurancePolicies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IServiceResult> PutInsurancePolicy(int id, InsurancePolicy insurancePolicy)
        {
            return await _insurancePolicyService.Save(insurancePolicy);
        }
        // POST: api/InsurancePolicies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IServiceResult> PostInsurancePolicy(InsurancePolicy insurancePolicy)
        {
            return await _insurancePolicyService.Save(insurancePolicy);
        }
        // DELETE: api/InsurancePolicies/5
        [HttpDelete("{id}")]
        public async Task<IServiceResult> DeleteInsurancePolicy(int id)
        {
            return await _insurancePolicyService.DeleteById(id);
        }
        private bool InsurancePolicyExists(int id)
        {
            return _insurancePolicyService.GetById(id) != null;
        }
    }
}
