using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Service.Interfaces
{

    public interface IPaymentService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int PaymentId);
        Task<IServiceResult> Save(Payment payment);
        Task<IServiceResult> DeleteById(int PaymentId);
    }
}
