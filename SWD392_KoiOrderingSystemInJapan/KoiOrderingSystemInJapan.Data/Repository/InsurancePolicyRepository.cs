using KoiOrderingSystemInJapan.Data.Base;
using KoiOrderingSystemInJapan.Data.DBContext;
using KoiOrderingSystemInJapan.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Data.Repository
{
    public class InsurancePolicyRepository : GenericRepository<InsurancePolicy>
    {
        public InsurancePolicyRepository() { }
        public InsurancePolicyRepository(KoiOrderingSystemInJapanContext context) => _context = context;

        public async Task<List<InsurancePolicy>> GetAllInsurancePoliciesAsync()
        {
            return await _context.InsurancePolicies
                .Include(ip => ip.OrderKoiFishes) 
                .ToListAsync();
        }

        public async Task<InsurancePolicy> GetByIdInsurancePolicyAsync(int id)
        {
            return await _context.InsurancePolicies
                .Include(ip => ip.OrderKoiFishes)
                .FirstOrDefaultAsync(ip => ip.InsuranceId == id);
        }
    }
}
