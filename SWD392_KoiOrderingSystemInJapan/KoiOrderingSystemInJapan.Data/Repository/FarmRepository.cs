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
    public class FarmRepository : GenericRepository<Farm>
    {
        public FarmRepository() { }
        public FarmRepository(KoiOrderingSystemInJapanContext context) => _context = context;

        public async Task<List<Farm>> GetAllFarmsAsync()
        {
            return await _context.Farms
                .Include(f => f.KoiFishes)
                .Include(f => f.ScheduleFarms)
                .ToListAsync();
        }

        public async Task<Farm> GetByIdFarmAsync(int id)
        {
            return await _context.Farms
                .Include(f => f.KoiFishes)
                .Include(f => f.ScheduleFarms)
                .FirstOrDefaultAsync(f => f.FarmId == id);
        }
    }
}
