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
    public class TripRepository : GenericRepository<Trip>
    {
        public TripRepository() { }
        public TripRepository(KoiOrderingSystemInJapanContext context) => _context = context;

        public async Task<List<Trip>> GetAllTripsAsync()
        {
            return await _context.Trips
                .Include(t => t.OrderTrips)
                .Include(t => t.TripSchedules)
                .ToListAsync();
        }

        public async Task<Trip> GetByIdTripAsync(int id)
        {
            return await _context.Trips
                .Include(t => t.OrderTrips)
                .Include(t => t.TripSchedules)
                .FirstOrDefaultAsync(t => t.TripId == id);
        }
    }
}
