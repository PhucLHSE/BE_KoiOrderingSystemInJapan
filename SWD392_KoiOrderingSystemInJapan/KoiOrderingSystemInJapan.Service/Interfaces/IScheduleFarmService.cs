using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Service.Interfaces
{
    public interface IScheduleFarmService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int ScheduleFarmId);
        Task<IServiceResult> Save(ScheduleFarm scheduleFarm);
        Task<IServiceResult> DeleteById(int ScheduleFarmId);
    }
}
