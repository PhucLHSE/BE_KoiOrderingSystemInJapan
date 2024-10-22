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
    public class RefundRequestsController : ControllerBase
    {
        private readonly IRefundRequestService _refundRequestService;

        public RefundRequestsController(IRefundRequestService refundRequestService) => _refundRequestService = refundRequestService;

        // GET: api/RefundRequests
        [HttpGet]
        public async Task<IServiceResult> GetRefundRequests()
        {
            return await _refundRequestService.GetAll();
        }

        // GET: api/RefundRequests/5
        [HttpGet("{id}")]
        public async Task<IServiceResult> GetRefundRequest(int id)
        {
            var refundRequest = await _refundRequestService.GetById(id);

            return refundRequest;
        }

        // PUT: api/RefundRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IServiceResult> PutRefundRequest(int id, RefundRequest refundRequest)
        {
            return await _refundRequestService.Save(refundRequest);
        }

        // POST: api/RefundRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IServiceResult> PostRefundRequest(RefundRequest refundRequest)
        {
            return await _refundRequestService.Save(refundRequest);
        }

        // DELETE: api/RefundRequests/5
        [HttpDelete("{id}")]
        public async Task<IServiceResult> DeleteRefundRequest(int id)
        {
            return await _refundRequestService.DeleteById(id);
        }

        private bool RefundRequestExists(int id)
        {
            return _refundRequestService.GetById(id) != null;
        }
    }
}
