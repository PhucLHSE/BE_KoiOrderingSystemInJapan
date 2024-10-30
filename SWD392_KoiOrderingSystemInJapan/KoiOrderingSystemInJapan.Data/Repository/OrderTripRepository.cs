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
    public class OrderTripRepository : GenericRepository<OrderTrip>
    {
        public OrderTripRepository() { }
        public OrderTripRepository(KoiOrderingSystemInJapanContext context) => _context = context;

        public async Task<List<OrderTrip>> GetAllOrderTripsAsync()
        {
            return await _context.OrderTrips
                .Include(o => o.Customer)          
                .Include(o => o.Feedbacks)      
                .Include(o => o.OrderHistories)    
                .Include(o => o.Payments)         
                .Include(o => o.Schedule)         
                .Include(o => o.Trip)           
                .ToListAsync();
        }

        public async Task<OrderTrip> GetByIdOrderTripAsync(int id)
        {
            return await _context.OrderTrips
                .Include(o => o.Customer)
                .Include(o => o.Feedbacks)
                .Include(o => o.OrderHistories)
                .Include(o => o.Payments)
                .Include(o => o.Schedule)
                .Include(o => o.Trip)
                .FirstOrDefaultAsync(o => o.OrderTripId == id);
        }
    }
}
