using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Service.Interfaces
{
    public interface IOrderTripService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int OrderTripId);
        Task<IServiceResult> Save(OrderTrip trip);
        Task<IServiceResult> DeleteById(int OrderTripId);
    }
}
