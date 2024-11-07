using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystemInJapan.Data.DBContext;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Interfaces;
using KoiOrderingSystemInJapan.Service.Base;
using KoiOrderingSystemInJapan.Service.Services;

namespace KoiOrderingSystemInJapan.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderKoiFishDetailsController : ControllerBase
    {
        private readonly IOrderKoiFishDetailService _orderKoiFishDetailService;

        public OrderKoiFishDetailsController(IOrderKoiFishDetailService orderKoiFishDetailService) => _orderKoiFishDetailService = orderKoiFishDetailService;

        // GET: api/OrderKoiFishDetails
        [HttpGet]
        public async Task<IServiceResult> GetOrderKoiFishDetails()
        {
            return await _orderKoiFishDetailService.GetAll();
        }

        // GET: api/OrderKoiFishDetails/5
        [HttpGet("{id}")]
        public async Task<IServiceResult> GetOrderKoiFishDetail(int id)
        {
            var orderKoiFishDetail = await _orderKoiFishDetailService.GetById(id);

            return orderKoiFishDetail;
        }

        // PUT: api/OrderKoiFishDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IServiceResult> PutOrderKoiFishDetail(int id, OrderKoiFishDetail orderKoiFishDetail)
        {
            return await _orderKoiFishDetailService.Save(orderKoiFishDetail);
        }

        // POST: api/OrderKoiFishDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IServiceResult> PostOrderKoiFishDetail(OrderKoiFishDetail orderKoiFishDetail)
        {
            return await _orderKoiFishDetailService.Save(orderKoiFishDetail);
        }

        // DELETE: api/OrderKoiFishDetails/5
        [HttpDelete("{id}")]
        public async Task<IServiceResult> DeleteOrderKoiFishDetail(int id)
        {
            return await _orderKoiFishDetailService.DeleteById(id);
        }

        private bool OrderKoiFishDetailExists(int id)
        {
            return _orderKoiFishDetailService.GetById(id) != null;
        }
    }
}
