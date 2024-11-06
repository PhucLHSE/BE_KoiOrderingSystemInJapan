using KoiOrderingSystemInJapan.Common;
using KoiOrderingSystemInJapan.Data;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Data.Repository;
using KoiOrderingSystemInJapan.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiOrderingSystemInJapan.Service.Interfaces;
namespace KoiOrderingSystemInJapan.Service.Services
{
    public class KoiFishService : IKoiFishService
    {
        private readonly UnitOfWork _unitOfWork;
        public KoiFishService()
        {
            _unitOfWork ??= new UnitOfWork();
        }
        public async Task<IServiceResult> DeleteById(int koifishId)
        {
            {
                try
                {
                    var fish = await _unitOfWork.KoiFishRepository.GetByIdAsync(koifishId);

                    if (fish == null)
                    {
                        return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new KoiFish());
                    }
                    else
                    {
                        var result = await _unitOfWork.KoiFishRepository.RemoveAsync(fish);

                        if (result)
                        {
                            return new ServiceResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, fish);
                        }
                        else
                        {
                            return new ServiceResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, fish);
                        }
                    }
                }
                catch (Exception ex)
                {
                    return new ServiceResult(Const.ERROR_EXCEPTION, ex.ToString());
                }
            }
        }

        public async Task<IServiceResult> GetAll()
        {
            var list = await _unitOfWork.KoiFishRepository.GetAllKoiFishesAsync();

            if (list == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<KoiFish>());
            }
            else
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, list);
            }
        }

        public async Task<IServiceResult> GetById(int koiFishID)
        {
            var fish = await _unitOfWork.KoiFishRepository.GetByIdKoiFishAsync(koiFishID);
            if (fish == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new KoiFish());
            }
            else
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, fish);
            }
        }

        public async Task<IServiceResult> Save(KoiFish koiFish)
        {
            try
            {
                int result = -1;

                var farmTmp = _unitOfWork.FarmRepository.GetById(koiFish.KoiFishId);

                if (farmTmp != null)
                {
                    result = await _unitOfWork.KoiFishRepository.UpdateAsync(koiFish);

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
                    result = await _unitOfWork.KoiFishRepository.CreateAsync(koiFish);

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
    }
}
