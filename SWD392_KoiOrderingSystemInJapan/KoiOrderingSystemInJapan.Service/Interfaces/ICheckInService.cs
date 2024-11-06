using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Service.Interfaces
{
    public interface ICheckInService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int CheckInId);
        Task<IServiceResult> Save(CheckIn checkIn);
        Task<IServiceResult> DeleteById(int CheckInId);
    }
}
