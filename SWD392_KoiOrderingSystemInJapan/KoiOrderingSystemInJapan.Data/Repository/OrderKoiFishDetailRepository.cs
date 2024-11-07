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
    public class OrderKoiFishDetailRepository : GenericRepository<OrderKoiFishDetail>
    {
        public OrderKoiFishDetailRepository() { }
        public OrderKoiFishDetailRepository(KoiOrderingSystemInJapanContext context) => _context = context;
        public async Task<List<OrderKoiFishDetail>> GetAllOrderKoiFishDetailAsync()
        {
            return await _context.OrderKoiFishDetails
                .Include(od => od.KoiFish)
                .Include(od => od.OrderKoi)
                .ToListAsync();
        }
        public async Task<OrderKoiFishDetail> GetByIdOrderKoiFishDetailAsync(int id)
        {
            return await _context.OrderKoiFishDetails
                .Include(od => od.KoiFish)
                .Include(od => od.OrderKoi)
                .FirstOrDefaultAsync(od => od.OrderKoiFishDetailId == id);
        }
    }
}
