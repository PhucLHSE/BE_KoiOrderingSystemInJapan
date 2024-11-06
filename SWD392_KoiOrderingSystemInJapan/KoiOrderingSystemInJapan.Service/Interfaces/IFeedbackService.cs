using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Service.Interfaces
{
    public interface IFeedbackService
    {
        Task<IServiceResult> GetAll();
        Task<IServiceResult> GetById(int FeedbackId);
        Task<IServiceResult> Save(Feedback feedback);
        Task<IServiceResult> DeleteById(int FeedbackId);
    }
}
