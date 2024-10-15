using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service;
using KoiOrderingSystemInJapan.Service.Base;

namespace KoiOrderingSystemInJapan.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderHistoriesController : ControllerBase
    {
        private readonly IOrderHistoryService _orderHistoryService;

        public OrderHistoriesController(IOrderHistoryService orderHistoryService) =>  _orderHistoryService = orderHistoryService;
        

        // GET: api/OrderHistories
        [HttpGet]
        public async Task<IServiceResult> GetOrderHistories()
        {
            return await _orderHistoryService.GetAll();
        }

        // GET: api/OrderHistories/5
        [HttpGet("{id}")]
        public async Task<IServiceResult> GetOrderHistory(int id)
        {
            var history = await _orderHistoryService.GetById(id);
            return history;
        }

        // PUT: api/OrderHistories/5
        [HttpPut("{id}")]
        public async Task<IServiceResult> PutOrderHistory(int id, OrderHistory orderHistory)
        {

            return await _orderHistoryService.Save(orderHistory);
        }


        // POST: api/OrderHistories
        [HttpPost]
        public async Task<IServiceResult> PostOrderHistory(OrderHistory orderHistory)
        {
            return await _orderHistoryService.Save(orderHistory);
        }

        // DELETE: api/OrderHistories/5
        [HttpDelete("{id}")]
        public async Task<IServiceResult> DeleteOrderHistory(int id)
        {
            return await _orderHistoryService.DeleteById(id);
        }

        private bool OrderHistoryExists(int id)
        {
            return _orderHistoryService.GetById(id) != null;
        }
    }
}
