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
    public class KoiFishRepository : GenericRepository<KoiFish>
    {
        public KoiFishRepository() { }
        public KoiFishRepository (KoiOrderingSystemInJapanContext context)
        {
            _context = context;
        }

        public async Task<List<KoiFish>> GetAllKoiFishesAsync()
        {
            return await _context.KoiFishes
                .Include(k => k.Farm)
                .Include(k => k.KoiFishVariety)
                .ToListAsync();
        }

        public async Task<KoiFish> GetByIdKoiFishAsync(int id)
        {
            return await _context.KoiFishes
                .Include(k => k.Farm)
                .Include(k => k.KoiFishVariety)
                .FirstOrDefaultAsync(k => k.KoiFishId == id);
        }
    }
}
