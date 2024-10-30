using KoiOrderingSystemInJapan.Common;
using KoiOrderingSystemInJapan.Data;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Service
{
    public interface IScheduleFarmService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int ScheduleFarmId);
        Task<IServiceResult> Save(ScheduleFarm scheduleFarm);
        Task<IServiceResult> DeleteById(int ScheduleFarmId);
    }
    public class ScheduleFarmService : IScheduleFarmService
    {
        private readonly UnitOfWork _unitOfWork;

        public ScheduleFarmService()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IServiceResult> GetAll()
        {
            var scheduleFarms = await _unitOfWork.ScheduleFarmRepository.GetAllScheduleFarmsAsync();

            if (scheduleFarms == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<ScheduleFarm>());
            }
            else
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, scheduleFarms);
            }
        }

        public async Task<IServiceResult> GetById(int ScheduleFarmId)
        {
            var scheduleFarm = await _unitOfWork.ScheduleFarmRepository.GetByIdScheduleFarmAsync(ScheduleFarmId);

            if (scheduleFarm == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new ScheduleFarm());
            }
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, scheduleFarm);
            }
        }

        public async Task<IServiceResult> Save(ScheduleFarm scheduleFarm)
        {
            try
            {
                int result = -1;

                var scheduleFarmTmp = _unitOfWork.ScheduleFarmRepository.GetById(scheduleFarm.ScheduleFarmId);

                if (scheduleFarmTmp != null)
                {
                    result = await _unitOfWork.ScheduleFarmRepository.UpdateAsync(scheduleFarm);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, scheduleFarm);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                    }
                }
                else
                {
                    result = await _unitOfWork.ScheduleFarmRepository.CreateAsync(scheduleFarm);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, scheduleFarm);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, scheduleFarm);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IServiceResult> DeleteById(int ScheduleFarmId)
        {
            try
            {
                var scheduleFarm = await _unitOfWork.ScheduleFarmRepository.GetByIdAsync(ScheduleFarmId);

                if (scheduleFarm == null)
                {
                    return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new ScheduleFarm());
                }
                else
                {
                    var result = await _unitOfWork.ScheduleFarmRepository.RemoveAsync(scheduleFarm);

                    if (result)
                    {
                        return new ServiceResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, scheduleFarm);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, scheduleFarm);
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
