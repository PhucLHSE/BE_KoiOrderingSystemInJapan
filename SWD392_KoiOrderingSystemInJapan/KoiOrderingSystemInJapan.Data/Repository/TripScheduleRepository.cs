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
    public class TripScheduleRepository : GenericRepository<TripSchedule>
    {
        public TripScheduleRepository() { }
        public TripScheduleRepository(KoiOrderingSystemInJapanContext context) => _context = context;

        public async Task<List<TripSchedule>> GetAllTripSchedulesAsync()
        {
            return await _context.TripSchedules
                .Include(ts => ts.CheckIns)    
                .Include(ts => ts.OrderTrips)  
                .Include(ts => ts.ScheduleFarms) 
                .Include(ts => ts.Trip)         
                .ToListAsync();
        }

        public async Task<TripSchedule> GetByIdTripScheduleAsync(int id)
        {
            return await _context.TripSchedules
                .Include(ts => ts.CheckIns)
                .Include(ts => ts.OrderTrips)
                .Include(ts => ts.ScheduleFarms)
                .Include(ts => ts.Trip)
                .FirstOrDefaultAsync(ts => ts.ScheduleId == id);
        }
    }
}
