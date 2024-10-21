using KoiOrderingSystemInJapan.Common;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using KoiOrderingSystemInJapan.Service;
using Microsoft.AspNetCore.Mvc;

namespace KoiOrderingSystemInJapan.APIService.Controllers
{
    public class FeedBackController : Controller
    {
        [Route("api/[controller]")]
        [ApiController]
        public class FeedbacksController : ControllerBase
        {
            private readonly IFeedbackService _feedbackService;

            public FeedbacksController(IFeedbackService feedbackService) => _feedbackService = feedbackService;

            // GET: api/Feedbacks
            [HttpGet]
            public async Task<IServiceResult> GetFeedbacks()
            {
                return await _feedbackService.GetAll();
            }

            // GET: api/Feedbacks/5
            [HttpGet("{id}")]
            public async Task<IServiceResult> GetFeedback(int id)
            {
                var feedback = await _feedbackService.GetById(id);
                return feedback;
            }

            // PUT: api/Feedbacks/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPut("{id}")]
            public async Task<IServiceResult> PutFeedback(int id, Feedback feedback)
            {
                if (id != feedback.FeedbackId)
                {
                    return new ServiceResult(Const.FAIL_UPDATE_CODE, "Feedback ID mismatch");
                }

                return await _feedbackService.Save(feedback);
            }

            // POST: api/Feedbacks
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
            public async Task<IServiceResult> PostFeedback(Feedback feedback)
            {
                return await _feedbackService.Save(feedback);
            }

            // DELETE: api/Feedbacks/5
            [HttpDelete("{id}")]
            public async Task<IServiceResult> DeleteFeedback(int id)
            {
                return await _feedbackService.DeleteById(id);
            }
        }
    }
}
