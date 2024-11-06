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
    public class FeedbackService : IFeedbackService
    {
        private readonly UnitOfWork _unitOfWork;

        public FeedbackService()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IServiceResult> GetAll()
        {
            var feedbacks = await _unitOfWork.FeedbackRepository.GetAllFeedbacksAsync();

            if (feedbacks == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<Feedback>());
            }
            else
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, feedbacks);
            }
        }

        public async Task<IServiceResult> GetById(int FeedbackId)
        {
            var feedback = await _unitOfWork.FeedbackRepository.GetByIdFeedbackAsync(FeedbackId);

            if (feedback == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new Feedback());
            }
            else
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, feedback);
            }
        }

        public async Task<IServiceResult> Save(Feedback feedback)
        {
            try
            {
                int result = -1;

                var feedbackTmp = await _unitOfWork.FeedbackRepository.GetByIdAsync(feedback.FeedbackId);

                if (feedbackTmp != null)
                {
                    result = await _unitOfWork.FeedbackRepository.UpdateAsync(feedback);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, feedback);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                    }
                }
                else
                {
                    result = await _unitOfWork.FeedbackRepository.CreateAsync(feedback);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, feedback);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, feedback);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IServiceResult> DeleteById(int FeedbackId)
        {
            try
            {
                var feedback = await _unitOfWork.FeedbackRepository.GetByIdAsync(FeedbackId);

                if (feedback == null)
                {
                    return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new Feedback());
                }
                else
                {
                    var result = await _unitOfWork.FeedbackRepository.RemoveAsync(feedback);

                    if (result)
                    {
                        return new ServiceResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, feedback);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, feedback);
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

