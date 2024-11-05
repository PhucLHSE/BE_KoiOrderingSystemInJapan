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
    public class PaymentRepository : GenericRepository<Payment>
    {
        public PaymentRepository() { }
        public PaymentRepository(KoiOrderingSystemInJapanContext context) => _context = context;

        public async Task<List<Payment>> GetAllPaymentsAsync()
        {
            return await _context.Payments
                .Include(p => p.Customer)      
                .Include(p => p.OrderKoi)      
                .Include(p => p.OrderTrip)     
                .ToListAsync();
        }

        public async Task<Payment> GetByIdPaymentAsync(int id)
        {
            return await _context.Payments
                .Include(p => p.Customer)
                .Include(p => p.OrderKoi)
                .Include(p => p.OrderTrip)
                .FirstOrDefaultAsync(p => p.PaymentId == id);
        }

        public async Task UpdatePayment(Payment payment)
        {
            _context.Update(payment);
            await _context.SaveChangesAsync();
        }
        public async Task CreatePayment(Payment payment)
        {
            _context.Add(payment);
            await _context.SaveChangesAsync();
        }
        public async Task<Payment> GetPayment(int orderKoiId)
        {
            return await _context.Payments.FirstOrDefaultAsync(p => p.OrderKoiId == orderKoiId);
        }
        //public async Task<List<Payment>> GetAllPayment()
        //{
        //    return await _context.Payments.Where(x => x.Status == "Completed").ToListAsync();
        //}
        //public async Task<bool> HasSuccessfulPayment(int customerId, int koiFishId)
        //{
        //    return await _context.Payments
        //        .Include(p => p.OrderKoi)
        //        .AnyAsync(p => p.OrderKoi.CustomerId == customerId &&
        //                       p.OrderKoi.KoiFishId == koiFishId && // Sử dụng Where
        //                       p.OrderKoi.Status == "Completed");
        //}
    }
}
