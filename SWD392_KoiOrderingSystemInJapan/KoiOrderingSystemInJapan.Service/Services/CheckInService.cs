using KoiOrderingSystemInJapan.Common;
using KoiOrderingSystemInJapan.Data;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiOrderingSystemInJapan.Service.Interfaces;
namespace KoiOrderingSystemInJapan.Service.Services
{

    public class CheckInService : ICheckInService
    {
        private readonly UnitOfWork _unitOfWork;

        public CheckInService()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IServiceResult> GetAll()
        {
            var checkIns = await _unitOfWork.CheckInRepository.GetAllCheckInsAsync();

            if (checkIns == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<CheckIn>());
            }
            else
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, checkIns);
            }
        }

        public async Task<IServiceResult> GetById(int CheckInId)
        {
            var checkIn = await _unitOfWork.CheckInRepository.GetByIdCheckInAsync(CheckInId);

            if (checkIn == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new CheckIn());
            }
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, checkIn);
            }
        }

        public async Task<IServiceResult> Save(CheckIn checkIn)
        {
            try
            {
                int result = -1;

                var checkInTmp = _unitOfWork.CheckInRepository.GetById(checkIn.CheckInId);

                if (checkInTmp != null)
                {
                    result = await _unitOfWork.CheckInRepository.UpdateAsync(checkIn);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, checkIn);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                    }
                }
                else
                {
                    result = await _unitOfWork.CheckInRepository.CreateAsync(checkIn);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, checkIn);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, checkIn);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IServiceResult> DeleteById(int CheckInId)
        {
            try
            {
                var checkIn = await _unitOfWork.CheckInRepository.GetByIdAsync(CheckInId);

                if (checkIn == null)
                {
                    return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new CheckIn());
                }
                else
                {
                    var result = await _unitOfWork.CheckInRepository.RemoveAsync(checkIn);

                    if (result)
                    {
                        return new ServiceResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, checkIn);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, checkIn);
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
