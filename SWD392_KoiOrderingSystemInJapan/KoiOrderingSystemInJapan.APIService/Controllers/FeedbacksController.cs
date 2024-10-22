using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystemInJapan.Data.DBContext;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service;
using KoiOrderingSystemInJapan.Service.Base;

namespace KoiOrderingSystemInJapan.APIService.Controllers
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

        private bool FeedbackExists(int id)
        {
            return _feedbackService.GetById(id) != null;
        }
    }
}
