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
    public interface ITripService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int TripId);
        Task<IServiceResult> Save(Trip trip);
        Task<IServiceResult> DeleteById(int TripId);
    }
    public class TripService : ITripService
    {
        private readonly UnitOfWork _unitOfWork;
        public TripService()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IServiceResult> GetAll()
        {
            var trips = await _unitOfWork.TripRepository.GetAllAsync();

            if (trips == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<Trip>());
            }
            else
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, trips);
            }
        }

        public async Task<IServiceResult> GetById(int TripId)
        {
            var trip = await _unitOfWork.TripRepository.GetByIdAsync(TripId);

            if (trip == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new Trip());
            }
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, trip);
            }
        }

        public async Task<IServiceResult> Save(Trip trip)
        {
            try
            {
                int result = -1;

                var tripTmp = _unitOfWork.TripRepository.GetById(trip.TripId);

                if (tripTmp != null)
                {
                    result = await _unitOfWork.TripRepository.UpdateAsync(trip);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, trip);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                    }
                }
                else
                {
                    result = await _unitOfWork.TripRepository.CreateAsync(trip);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, trip);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, trip);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IServiceResult> DeleteById(int TripId)
        {
            try
            {
                var trip = await _unitOfWork.TripRepository.GetByIdAsync(TripId);

                if (trip == null)
                {
                    return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new Trip());
                }
                else
                {
                    var result = await _unitOfWork.TripRepository.RemoveAsync(trip);

                    if (result)
                    {
                        return new ServiceResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, trip);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, trip);
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
