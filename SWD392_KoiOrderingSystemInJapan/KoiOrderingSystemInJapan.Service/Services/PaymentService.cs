using KoiOrderingSystemInJapan.Common;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Data;
using KoiOrderingSystemInJapan.Service.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiOrderingSystemInJapan.Service.Interfaces;
namespace KoiOrderingSystemInJapan.Service.Services
{

    public class PaymentService : IPaymentService
    {
        private readonly UnitOfWork _unitOfWork;

        public PaymentService()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IServiceResult> GetAll()
        {
            var payments = await _unitOfWork.PaymentRepository.GetAllPaymentsAsync();

            if (payments == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<Payment>());
            }
            else
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, payments);
            }
        }

        public async Task<IServiceResult> GetById(int PaymentId)
        {
            var payment = await _unitOfWork.PaymentRepository.GetByIdPaymentAsync(PaymentId);

            if (payment == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new Payment());
            }
            else
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, payment);
            }
        }

        public async Task<IServiceResult> Save(Payment payment)
        {
            try
            {
                int result = -1;

                var paymentTmp = _unitOfWork.PaymentRepository.GetById(payment.PaymentId);

                if (paymentTmp != null)
                {
                    result = await _unitOfWork.PaymentRepository.UpdateAsync(payment);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, payment);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                    }
                }
                else
                {
                    result = await _unitOfWork.PaymentRepository.CreateAsync(payment);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, payment);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, payment);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IServiceResult> DeleteById(int PaymentId)
        {
            try
            {
                var payment = await _unitOfWork.PaymentRepository.GetByIdAsync(PaymentId);

                if (payment == null)
                {
                    return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new Payment());
                }
                else
                {
                    var result = await _unitOfWork.PaymentRepository.RemoveAsync(payment);

                    if (result)
                    {
                        return new ServiceResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, payment);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, payment);
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
