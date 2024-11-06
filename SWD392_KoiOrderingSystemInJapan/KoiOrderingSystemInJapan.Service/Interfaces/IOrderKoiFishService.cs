using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Service.Interfaces
{
    public interface IOrderKoiFishService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int OrderKoiId);
        Task<IServiceResult> Save(OrderKoiFish koiFish);
        Task<IServiceResult> DeleteById(int OrderKoiId);
    }
}
