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
    public interface IFarmService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int FarmId);
        Task<IServiceResult> Save(Farm farm);
        Task<IServiceResult> DeleteById(int FarmId);
    }
    public class FarmService : IFarmService
    {
        private readonly UnitOfWork _unitOfWork;
        public FarmService()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IServiceResult> GetAll()
        {
            var farms = await _unitOfWork.FarmRepository.GetAllFarmsAsync();

            if (farms == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<Farm>());
            }
            else
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, farms);
            }
        }

        public async Task<IServiceResult> GetById(int FarmId)
        {
            var farm = await _unitOfWork.FarmRepository.GetByIdFarmAsync(FarmId);

            if (farm == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new Farm());
            }
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, farm);
            }
        }

        public async Task<IServiceResult> Save(Farm farm)
        {
            try
            {
                int result = -1;

                var farmTmp = _unitOfWork.FarmRepository.GetById(farm.FarmId);

                if (farmTmp != null)
                {
                    result = await _unitOfWork.FarmRepository.UpdateAsync(farm);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, farm);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                    }
                }
                else
                {
                    result = await _unitOfWork.FarmRepository.CreateAsync(farm);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, farm);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, farm);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IServiceResult> DeleteById(int FarmId)
        {
            try
            {
                var farm = await _unitOfWork.FarmRepository.GetByIdAsync(FarmId);

                if (farm == null)
                {
                    return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new Farm());
                }
                else
                {
                    var result = await _unitOfWork.FarmRepository.RemoveAsync(farm);

                    if (result)
                    {
                        return new ServiceResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, farm);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, farm);
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
