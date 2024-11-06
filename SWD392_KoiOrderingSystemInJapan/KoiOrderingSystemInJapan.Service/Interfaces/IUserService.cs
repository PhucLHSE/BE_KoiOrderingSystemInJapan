using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Service.Interfaces
{
    public interface IUserService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int UserId);
        Task<IServiceResult> Save(User user);
        Task<IServiceResult> DeleteById(int UserId);
    }
}
