using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Service.Interfaces
{
    public interface IKoiFishVarietyService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int RoleId);
        Task<IServiceResult> Save(KoiFishVariety koiFishVariety);
        Task<IServiceResult> DeleteById(int RoleId);
    }
}
