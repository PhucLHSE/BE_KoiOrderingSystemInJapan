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
    public class OrderHistoryRepository : GenericRepository<OrderHistory>
    {
        public OrderHistoryRepository() { }
        public OrderHistoryRepository(KoiOrderingSystemInJapanContext context) => _context = context;

        public async Task<List<OrderHistory>> GetAllOrderHistoriesAsync()
        {
            return await _context.OrderHistories
                .Include(oh => oh.Customer)     
                .Include(oh => oh.OrderKoi)     
                .Include(oh => oh.OrderTrip)    
                .ToListAsync();
        }

        public async Task<OrderHistory> GetByIdOrderHistoryAsync(int id)
        {
            return await _context.OrderHistories
                .Include(oh => oh.Customer)
                .Include(oh => oh.OrderKoi)
                .Include(oh => oh.OrderTrip)
                .FirstOrDefaultAsync(oh => oh.OrderHistoryId == id);
        }
    }
}
