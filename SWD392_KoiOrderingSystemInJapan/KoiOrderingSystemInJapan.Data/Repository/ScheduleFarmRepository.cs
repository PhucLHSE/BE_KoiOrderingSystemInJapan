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
    public class ScheduleFarmRepository : GenericRepository<ScheduleFarm>
    {
        public ScheduleFarmRepository() { }
        public ScheduleFarmRepository(KoiOrderingSystemInJapanContext context) => _context = context;

        public async Task<List<ScheduleFarm>> GetAllScheduleFarmsAsync()
        {
            return await _context.ScheduleFarms
                .Include(sf => sf.Farm)        
                .Include(sf => sf.Schedule)     
                .ToListAsync();
        }

        public async Task<ScheduleFarm> GetByIdScheduleFarmAsync(int id)
        {
            return await _context.ScheduleFarms
                .Include(sf => sf.Farm)
                .Include(sf => sf.Schedule)
                .FirstOrDefaultAsync(sf => sf.ScheduleFarmId == id);
        }
    }
}
