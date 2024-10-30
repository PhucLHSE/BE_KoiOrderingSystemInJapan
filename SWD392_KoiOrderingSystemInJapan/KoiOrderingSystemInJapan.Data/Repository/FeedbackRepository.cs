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
    public class FeedbackRepository : GenericRepository<Feedback>
    {
        public FeedbackRepository() { }
        public FeedbackRepository(KoiOrderingSystemInJapanContext context) => _context = context;

        public async Task<List<Feedback>> GetAllFeedbacksAsync()
        {
            return await _context.Feedbacks
                .Include(fb => fb.Customer)      
                .Include(fb => fb.OrderKoi)     
                .Include(fb => fb.OrderTrip)     
                .ToListAsync();
        }

        // Method to get Feedback by ID
        public async Task<Feedback> GetByIdFeedbackAsync(int id)
        {
            return await _context.Feedbacks
                .Include(fb => fb.Customer)
                .Include(fb => fb.OrderKoi)
                .Include(fb => fb.OrderTrip)
                .FirstOrDefaultAsync(fb => fb.FeedbackId == id);
        }
    }
}
