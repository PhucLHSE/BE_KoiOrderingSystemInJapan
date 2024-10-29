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
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository() { }
        public UserRepository(KoiOrderingSystemInJapanContext context) => _context = context;

        public async Task<List<User>> GetAlLUsersAsync()
        {
            /* return await _dbSet
                 .Include(u => u.Role.RoleName) // Assuming User entity has a navigation property to Role
                 .ToListAsync();*/
            return await _context.Users
                .Include(u => u.Role)
                .Include(u => u.CheckInConsultingStaffs)
                .Include(u => u.CheckInCustomers)
                .Include(u => u.Feedbacks)
                .Include(u => u.OrderHistories)
                .Include(u => u.OrderKoiFishes)
                .Include(u => u.OrderTrips)
                .Include(u => u.Payments)
                .ToListAsync();
        }
        public async Task<User> GetByIdUserAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Role)
                .Include(u => u.CheckInConsultingStaffs)
                .Include(u => u.CheckInCustomers)
                .Include(u => u.Feedbacks)
                .Include(u => u.OrderHistories)
                .Include(u => u.OrderKoiFishes)
                .Include(u => u.OrderTrips)
                .Include(u => u.Payments)
                .FirstOrDefaultAsync(u => u.UserId == id);
        }
    }
}
