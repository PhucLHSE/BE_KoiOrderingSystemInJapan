using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Service.Interfaces
{
    public interface IOrderHistoryService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int OrderHistoryId);
        Task<IServiceResult> Save(OrderHistory history);
        Task<IServiceResult> DeleteById(int OrderHistoryId);
    }
}
