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
    public interface IRefundRequestService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int RefundRequestId);
        Task<IServiceResult> Save(RefundRequest refundRequest);
        Task<IServiceResult> DeleteById(int RefundRequestId);
    }
    public class RefundRequestService : IRefundRequestService
    {
        private readonly UnitOfWork _unitOfWork;
        public RefundRequestService()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IServiceResult> GetAll()
        {
            var refundRequests = await _unitOfWork.RefundRequestRepository.GetAllAsync();

            if (refundRequests == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<RefundRequest>());
            }
            else
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, refundRequests);
            }
        }

        public async Task<IServiceResult> GetById(int RefundRequestId)
        {
            var refundRequest = await _unitOfWork.RefundRequestRepository.GetByIdAsync(RefundRequestId);

            if (refundRequest == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new RefundRequest());
            }
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, refundRequest);
            }
        }

        public async Task<IServiceResult> Save(RefundRequest refundRequest)
        {
            try
            {
                int result = -1;

                var refundRequestTmp = _unitOfWork.RefundRequestRepository.GetById(refundRequest.RefundRequestId);

                if (refundRequestTmp != null)
                {
                    result = await _unitOfWork.RefundRequestRepository.UpdateAsync(refundRequest);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, refundRequest);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                    }
                }
                else
                {
                    result = await _unitOfWork.RefundRequestRepository.CreateAsync(refundRequest);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, refundRequest);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, refundRequest);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IServiceResult> DeleteById(int RefundRequestId)
        {
            try
            {
                var refundRequest = await _unitOfWork.RefundRequestRepository.GetByIdAsync(RefundRequestId);

                if (refundRequest == null)
                {
                    return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new RefundRequest());
                }
                else
                {
                    var result = await _unitOfWork.RefundRequestRepository.RemoveAsync(refundRequest);

                    if (result)
                    {
                        return new ServiceResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, refundRequest);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, refundRequest);
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
