using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Service.Interfaces
{
    public interface IOrderKoiFishDetailService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int OrderKoiFishDetailId);
        Task<IServiceResult> Save(OrderKoiFishDetail orderKoiFishDetail);
        Task<IServiceResult> DeleteById(int OrderKoiFishDetailId);
    }
}
