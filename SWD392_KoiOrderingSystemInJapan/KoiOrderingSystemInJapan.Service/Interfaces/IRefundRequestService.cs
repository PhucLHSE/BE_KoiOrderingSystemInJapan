using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Service.Interfaces
{

    public interface IRefundRequestService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int RefundRequestId);
        Task<IServiceResult> Save(RefundRequest refundRequest);
        Task<IServiceResult> DeleteById(int RefundRequestId);
    }
}
