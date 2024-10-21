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
    public interface ITripScheduleService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int ScheduleId);
        Task<IServiceResult> Save(TripSchedule tripSchedule);
        Task<IServiceResult> DeleteById(int ScheduleId);
    }
    public class TripScheduleService : ITripScheduleService
    {
        private readonly UnitOfWork _unitOfWork;
        public TripScheduleService()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IServiceResult> GetAll()
        {
            var tripSchedules = await _unitOfWork.TripScheduleRepository.GetAllAsync();

            if (tripSchedules == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<TripSchedule>());
            }
            else
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, tripSchedules);
            }
        }

        public async Task<IServiceResult> GetById(int ScheduleId)
        {
            var tripSchedule = await _unitOfWork.TripScheduleRepository.GetByIdAsync(ScheduleId);

            if (tripSchedule == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new TripSchedule());
            }
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, tripSchedule);
            }
        }

        public async Task<IServiceResult> Save(TripSchedule tripSchedule)
        {
            try
            {
                int result = -1;

                var tripScheduleTmp = _unitOfWork.TripScheduleRepository.GetById(tripSchedule.ScheduleId);

                if (tripScheduleTmp != null)
                {
                    result = await _unitOfWork.TripScheduleRepository.UpdateAsync(tripSchedule);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, tripSchedule);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                    }
                }
                else
                {
                    result = await _unitOfWork.TripScheduleRepository.CreateAsync(tripSchedule);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, tripSchedule);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, tripSchedule);
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
                var tripSchedule = await _unitOfWork.TripScheduleRepository.GetByIdAsync(ScheduleId);

                if (tripSchedule == null)
                {
                    return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new TripSchedule());
                }
                else
                {
                    var result = await _unitOfWork.TripScheduleRepository.RemoveAsync(tripSchedule);

                    if (result)
                    {
                        return new ServiceResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, tripSchedule);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, tripSchedule);
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
