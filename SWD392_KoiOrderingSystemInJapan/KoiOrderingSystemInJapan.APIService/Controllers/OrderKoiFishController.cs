using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service;
using KoiOrderingSystemInJapan.Service.Base;

namespace KoiOrderingSystemInJapan.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderKoiFishController : ControllerBase
    {
        private readonly IOrderKoiFishService _orderKoiFishService;

        public OrderKoiFishController(IOrderKoiFishService orderKoiFishService) => _orderKoiFishService = orderKoiFishService;

        // GET: api/OrderKoiFish
        [HttpGet]
        public async Task<IServiceResult> GetOrderKoiFishes()
        {
                return await _orderKoiFishService.GetAll();
        }

        // GET: api/OrderKoiFish/5
        [HttpGet("{id}")]
        public async Task<IServiceResult> GetOrderKoiFish(int id)
        {
            var koiFish = await _orderKoiFishService.GetById(id);
            return koiFish;
        }

        // PUT: api/OrderKoiFish/5
        [HttpPut("{id}")]
        public async Task<IServiceResult> PutOrderKoiFish(int id, OrderKoiFish orderKoiFish)
        {
                    return await _orderKoiFishService.Save(orderKoiFish);   
        }

        // POST: api/OrderKoiFish
        [HttpPost]
        public async Task<IServiceResult> PostOrderKoiFish(OrderKoiFish orderKoiFish)
        {
                return await _orderKoiFishService.Save(orderKoiFish);
        }

        // DELETE: api/OrderKoiFish/5
        [HttpDelete("{id}")]
        public async Task<IServiceResult> DeleteOrderKoiFish(int id)
        {
                return await _orderKoiFishService.DeleteById(id);

        }

        private bool OrderKoiFishExists(int id)
        {

                return _orderKoiFishService.GetById(id) != null;
            }

        }
    }
