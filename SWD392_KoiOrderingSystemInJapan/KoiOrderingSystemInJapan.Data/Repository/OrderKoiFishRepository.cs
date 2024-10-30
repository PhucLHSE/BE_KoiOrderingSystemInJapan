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
    public class OrderKoiFishRepository : GenericRepository<OrderKoiFish>
    {
        public OrderKoiFishRepository() { }
        public OrderKoiFishRepository(KoiOrderingSystemInJapanContext context) => _context = context;

        public async Task<List<OrderKoiFish>> GetAllKoiFishesAsync()
        {
            return await _context.OrderKoiFishes
                .Include(o => o.Customer)          
                .Include(o => o.Feedbacks)         
                .Include(o => o.Insurance)         
                .Include(o => o.KoiFish)           
                .Include(o => o.OrderHistories) 
                .Include(o => o.Payments)      
                .Include(o => o.RefundRequests) 
                .ToListAsync();
        }

        public async Task<OrderKoiFish> GetByIdOrderKoiFishAsync(int id)
        {
            return await _context.OrderKoiFishes
                .Include(o => o.Customer)
                .Include(o => o.Feedbacks)
                .Include(o => o.Insurance)
                .Include(o => o.KoiFish)
                .Include(o => o.OrderHistories)
                .Include(o => o.Payments)
                .Include(o => o.RefundRequests)
                .FirstOrDefaultAsync(o => o.OrderKoiId == id);
        }
    }
}
