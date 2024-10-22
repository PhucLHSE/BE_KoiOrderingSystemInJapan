using KoiOrderingSystemInJapan.Common;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Data;
using KoiOrderingSystemInJapan.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Service
{
    public interface IInsurancePolicyService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int InsuranceId);
        Task<IServiceResult> Save(InsurancePolicy insurancePolicy);
        Task<IServiceResult> DeleteById(int InsuranceId);
    }
    public class InsurancePolicyService : IInsurancePolicyService
    {
        private readonly UnitOfWork _unitOfWork;
        public InsurancePolicyService()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IServiceResult> GetAll()
        {
            var insurancePolicies = await _unitOfWork.InsurancePolicyRepository.GetAllAsync();

            if (insurancePolicies == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<InsurancePolicy>());
            }
            else
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, insurancePolicies);
            }
        }

        public async Task<IServiceResult> GetById(int InsuranceId)
        {
            var insurancePolicy = await _unitOfWork.InsurancePolicyRepository.GetByIdAsync(InsuranceId);

            if (insurancePolicy == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new InsurancePolicy());
            }
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, insurancePolicy);
            }
        }

        public async Task<IServiceResult> Save(InsurancePolicy insurancePolicy)
        {
            try
            {
                int result = -1;

                var insurancePolicyTmp = _unitOfWork.InsurancePolicyRepository.GetById(insurancePolicy.InsuranceId);

                if (insurancePolicyTmp != null)
                {
                    result = await _unitOfWork.InsurancePolicyRepository.UpdateAsync(insurancePolicy);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, insurancePolicy);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                    }
                }
                else
                {   
                    result = await _unitOfWork.InsurancePolicyRepository.CreateAsync(insurancePolicy);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, insurancePolicy);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, insurancePolicy);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IServiceResult> DeleteById(int InsuranceId)
        {
            try
            {
                var insurancePolicy = await _unitOfWork.InsurancePolicyRepository.GetByIdAsync(InsuranceId);

                if (insurancePolicy == null)
                {
                    return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new InsurancePolicy());
                }
                else
                {
                    var result = await _unitOfWork.InsurancePolicyRepository.RemoveAsync(insurancePolicy);

                    if (result)
                    {
                        return new ServiceResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, insurancePolicy);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, insurancePolicy);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }
    }
}
