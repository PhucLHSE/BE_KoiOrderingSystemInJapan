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
    public interface IOrderKoiFishService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int OrderKoiId);
        Task<IServiceResult> Save(OrderKoiFish koiFish);
        Task<IServiceResult> DeleteById(int OrderKoiId);
    }
    public class OrderKoiFishService : IOrderKoiFishService
    {
        private readonly UnitOfWork _unitOfWork;
        public OrderKoiFishService()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IServiceResult> GetAll()
        {
            var koiFishes = await _unitOfWork.OrderKoiFishRepository.GetAllAsync();

            if (koiFishes == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<OrderKoiFish>());
            }
            else
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, koiFishes);
            }
        }

        public async Task<IServiceResult> GetById(int OrderKoiId)
        {
            var koiFish = await _unitOfWork.OrderKoiFishRepository.GetByIdAsync(OrderKoiId);

            if (koiFish == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new OrderKoiFish());
            }
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, koiFish);
            }
        }

        public async Task<IServiceResult> Save(OrderKoiFish koiFish)
        {
            try
            {
                int result = -1;

                var koiFishTmp = _unitOfWork.OrderKoiFishRepository.GetById(koiFish.OrderKoiId);

                if (koiFishTmp != null)
                {
                    result = await _unitOfWork.OrderKoiFishRepository.UpdateAsync(koiFish);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, koiFish);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                    }
                }
                else
                {
                    result = await _unitOfWork.OrderKoiFishRepository.CreateAsync(koiFish);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, koiFish);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, koiFish);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IServiceResult> DeleteById(int OrderKoiId)
        {
            try
            {
                var koiFish = await _unitOfWork.OrderKoiFishRepository.GetByIdAsync(OrderKoiId);

                if (koiFish == null)
                {
                    return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new OrderKoiFish());
                }
                else
                {
                    var result = await _unitOfWork.OrderKoiFishRepository.RemoveAsync(koiFish);

                    if (result)
                    {
                        return new ServiceResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, koiFish);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, koiFish);
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
