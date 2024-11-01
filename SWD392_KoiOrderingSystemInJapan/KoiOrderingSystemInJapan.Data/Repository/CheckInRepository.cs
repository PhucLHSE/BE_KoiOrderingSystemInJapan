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
    public class CheckInRepository : GenericRepository<CheckIn>
    {
        public CheckInRepository() { }
        public CheckInRepository(KoiOrderingSystemInJapanContext context) => _context = context;

        public async Task<List<CheckIn>> GetAllCheckInsAsync()
        {
            return await _context.CheckIns
                .Include(ci => ci.ConsultingStaff) 
                .Include(ci => ci.Customer)       
                .Include(ci => ci.Schedule)      
                .ToListAsync();
        }

        // Method to get CheckIn by ID
        public async Task<CheckIn> GetByIdCheckInAsync(int id)
        {
            return await _context.CheckIns
                .Include(ci => ci.ConsultingStaff)
                .Include(ci => ci.Customer)
                .Include(ci => ci.Schedule)
                .FirstOrDefaultAsync(ci => ci.CheckInId == id);
        }
    }
}
