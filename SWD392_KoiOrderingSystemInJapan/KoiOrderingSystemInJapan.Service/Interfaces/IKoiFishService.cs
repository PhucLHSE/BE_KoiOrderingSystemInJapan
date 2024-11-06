using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Service.Interfaces
{
    public interface IKoiFishService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int koiFishID);
        Task<IServiceResult> Save(KoiFish koiFish);
        Task<IServiceResult> DeleteById(int koifishId);
    }
}
