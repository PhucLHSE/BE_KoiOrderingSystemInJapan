using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Service.Interfaces
{
    public interface IFarmService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int FarmId);
        Task<IServiceResult> Save(Farm farm);
        Task<IServiceResult> DeleteById(int FarmId);
    }
}
