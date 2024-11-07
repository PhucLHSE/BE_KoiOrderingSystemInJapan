using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiOrderingSystemInJapan.Common;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Data;
using KoiOrderingSystemInJapan.Service.Base;
using KoiOrderingSystemInJapan.Service.Interfaces;
namespace KoiOrderingSystemInJapan.Service.Services
{
    public class OrderKoiFishDetailService : IOrderKoiFishDetailService
    {
        private readonly UnitOfWork _unitOfWork;
        public OrderKoiFishDetailService()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IServiceResult> GetAll()
        {
            var orderKoiFishDetails = await _unitOfWork.OrderKoiFishDetailRepository.GetAllOrderKoiFishDetailAsync();

            if (orderKoiFishDetails == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<OrderKoiFishDetail>());
            }
            else
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, orderKoiFishDetails);
            }
        }

        public async Task<IServiceResult> GetById(int OrderKoiFishDetailId)
        {
            var orderKoiFishDetail = await _unitOfWork.OrderKoiFishDetailRepository.GetByIdOrderKoiFishDetailAsync(OrderKoiFishDetailId);

            if (orderKoiFishDetail == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new OrderKoiFishDetail());
            }
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, orderKoiFishDetail);
            }
        }

        public async Task<IServiceResult> Save(OrderKoiFishDetail orderKoiFishDetail)
        {
            try
            {
                int result = -1;

                var orderKoiFishDetailTmp = _unitOfWork.OrderKoiFishDetailRepository.GetById(orderKoiFishDetail.OrderKoiFishDetailId);

                if (orderKoiFishDetailTmp != null)
                {
                    result = await _unitOfWork.OrderKoiFishDetailRepository.UpdateAsync(orderKoiFishDetail);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, orderKoiFishDetail);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                    }
                }
                else
                {
                    result = await _unitOfWork.OrderKoiFishDetailRepository.CreateAsync(orderKoiFishDetail);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, orderKoiFishDetail);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, orderKoiFishDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IServiceResult> DeleteById(int OrderKoiFishDetailId)
        {
            try
            {
                var orderKoiFishDetail = await _unitOfWork.OrderKoiFishDetailRepository.GetByIdAsync(OrderKoiFishDetailId);

                if (orderKoiFishDetail == null)
                {
                    return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new OrderKoiFishDetail());
                }
                else
                {
                    var result = await _unitOfWork.OrderKoiFishDetailRepository.RemoveAsync(orderKoiFishDetail);

                    if (result)
                    {
                        return new ServiceResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, orderKoiFishDetail);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, orderKoiFishDetail);
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
