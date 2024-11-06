using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Service.Interfaces
{
    public interface ITripService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int TripId);
        Task<IServiceResult> Save(Trip trip);
        Task<IServiceResult> DeleteById(int TripId);
    }
}
