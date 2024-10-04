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
    public interface IScheduleService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int ScheduleId);
        Task<IServiceResult> Save(Schedule schedule);
        Task<IServiceResult> DeleteById(int ScheduleId);
    }
    public class ScheduleService : IScheduleService
    {
        private readonly UnitOfWork _unitOfWork;
        public ScheduleService()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IServiceResult> GetAll()
        {
            var schedules = await _unitOfWork.ScheduleRepository.GetAllAsync();

            if (schedules == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<Schedule>());
            }
            else
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, schedules);
            }
        }

        public async Task<IServiceResult> GetById(int ScheduleId)
        {
            var schedule = await _unitOfWork.ScheduleRepository.GetByIdAsync(ScheduleId);

            if (schedule == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new Schedule());
            }
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, schedule);
            }
        }

        public async Task<IServiceResult> Save(Schedule schedule)
        {
            try
            {
                int result = -1;

                var scheduleTmp = _unitOfWork.ScheduleRepository.GetById(schedule.ScheduleId);

                if (scheduleTmp != null)
                {
                    result = await _unitOfWork.ScheduleRepository.UpdateAsync(schedule);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, schedule);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                    }
                }
                else
                {
                    result = await _unitOfWork.ScheduleRepository.CreateAsync(schedule);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, schedule);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, schedule);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IServiceResult> DeleteById(int ScheduleId)
        {
            try
            {
                var schedule = await _unitOfWork.ScheduleRepository.GetByIdAsync(ScheduleId);

                if (schedule == null)
                {
                    return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new Schedule());
                }
                else
                {
                    var result = await _unitOfWork.ScheduleRepository.RemoveAsync(schedule);

                    if (result)
                    {
                        return new ServiceResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, schedule);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, schedule);
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
