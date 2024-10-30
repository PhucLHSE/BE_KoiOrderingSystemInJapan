using KoiOrderingSystemInJapan.Common;
using KoiOrderingSystemInJapan.Data;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Service
{
    public interface IKoiFishVarietyService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int RoleId);
        Task<IServiceResult> Save(KoiFishVariety koiFishVariety);
        Task<IServiceResult> DeleteById(int RoleId);
    }
    public class KoiFishVarietyService : IKoiFishVarietyService
    {
        private readonly UnitOfWork _unitOfWork;
        public KoiFishVarietyService()
        {
            _unitOfWork ??= new UnitOfWork();
        }
        public async Task<IServiceResult> DeleteById(int id)
        {
            {
                try
                {
                    var variety = await _unitOfWork.KoiFishVarietyRepository.GetByIdAsync(id);

                    if (variety == null)
                    {
                        return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new KoiFishVariety());
                    }
                    else
                    {
                        var result = await _unitOfWork.KoiFishVarietyRepository.RemoveAsync(variety);

                        if (result)
                        {
                            return new ServiceResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, variety);
                        }
                        else
                        {
                            return new ServiceResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, variety);
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
            var list = await _unitOfWork.KoiFishVarietyRepository.GetAllKoiFishVarietiesAsync();

            if (list == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<KoiFishVariety>());
            }
            else
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, list);
            }
        }

        public async Task<IServiceResult> GetById(int id)
        {
            var variety = await _unitOfWork.KoiFishVarietyRepository.GetByIdKoiFishVarietyAsync(id);
            if (variety == null)
            {
                return new ServiceResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new KoiFishVariety());
            }
            else
            {
                return new ServiceResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, variety);
            }
        }

        public async Task<IServiceResult> Save(KoiFishVariety koiFishVariety)
        {
            try
            {
                int result = -1;

                var varietyTmp = _unitOfWork.KoiFishVarietyRepository.GetById(koiFishVariety.KoiFishVarietyId);

                if (varietyTmp != null)
                {
                    result = await _unitOfWork.KoiFishVarietyRepository.UpdateAsync(koiFishVariety);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, koiFishVariety);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                    }
                }
                else
                {
                    result = await _unitOfWork.KoiFishVarietyRepository.CreateAsync(koiFishVariety);

                    if (result > 0)
                    {
                        return new ServiceResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, koiFishVariety);
                    }
                    else
                    {
                        return new ServiceResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, koiFishVariety);
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
