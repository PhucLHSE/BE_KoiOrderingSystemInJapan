using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Service.Interfaces
{
    public interface IInsurancePolicyService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int InsuranceId);
        Task<IServiceResult> Save(InsurancePolicy insurancePolicy);
        Task<IServiceResult> DeleteById(int InsuranceId);
    }
}
