using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Service.Interfaces
{
    public interface ITripScheduleService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int ScheduleId);
        Task<IServiceResult> Save(TripSchedule tripSchedule);
        Task<IServiceResult> DeleteById(int ScheduleId);
    }
}
