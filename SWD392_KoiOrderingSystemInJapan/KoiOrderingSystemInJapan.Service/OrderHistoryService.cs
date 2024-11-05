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
    public interface IOrderHistoryService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int OrderHistoryId);
        Task<IServiceResult> Save(OrderHistory history);
        Task<IServiceResult> DeleteById(int OrderHistoryId);
    }
    public class OrderHistoryService : IOrderHistoryService
    {
        private readonly UnitOfWork _unitOfWork;
        public OrderHistoryService()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IServiceResult> GetAll()
        {
            var histories = await _unitOfWork.OrderHistoryRepository.GetAllOrderHistoriesAsync();

            if (histories == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<OrderHistory>());
            }
            else
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, histories);
            }
        }

        public async Task<IServiceResult> GetById(int OrderHistoryId)
        {
            var history = await _unitOfWork.OrderHistoryRepository.GetByIdOrderHistoryAsync(OrderHistoryId);

            if (history == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new OrderHistory());
            }
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, history);
            }
        }

        public async Task<IServiceResult> Save(OrderHistory history)
        {
            try
            {
                int result = -1;

                var historyTmp = _unitOfWork.OrderHistoryRepository.GetById(history.OrderHistoryId);

                if (historyTmp != null)
                {
                    result = await _unitOfWork.OrderHistoryRepository.UpdateAsync(history);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, history);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                    }
                }
                else
                {
                    result = await _unitOfWork.OrderHistoryRepository.CreateAsync(history);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, history);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, history);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IServiceResult> DeleteById(int OrderHistoryId)
        {
            try
            {
                var history = await _unitOfWork.OrderHistoryRepository.GetByIdAsync(OrderHistoryId);

                if (history == null)
                {
                    return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new OrderHistory());
                }
                else
                {
                    var result = await _unitOfWork.OrderHistoryRepository.RemoveAsync(history);

                    if (result)
                    {
                        return new ServiceResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, history);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, history);
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
