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
    public class KoiFishVarietyRepository:GenericRepository<KoiFishVariety>
    {
        public KoiFishVarietyRepository() { }
        public KoiFishVarietyRepository(KoiOrderingSystemInJapanContext context) => _context = context;

        public async Task<List<KoiFishVariety>> GetAllKoiFishVarietiesAsync()
        {
            return await _context.KoiFishVarieties
                .Include(kfv => kfv.KoiFishes)  
                .ToListAsync();
        }

        public async Task<KoiFishVariety> GetByIdKoiFishVarietyAsync(int id)
        {
            return await _context.KoiFishVarieties
                .Include(kfv => kfv.KoiFishes)
                .FirstOrDefaultAsync(kfv => kfv.KoiFishVarietyId == id);
        }
    }
}
