//using KoiOrderingSystemInJapan.Common.Enum;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Service.Interfaces
{
    public interface IRoleService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int RoleId);
        Task<IServiceResult> Save(Role role);
        Task<IServiceResult> DeleteById(int RoleId);
    }
}
