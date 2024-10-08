using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service; // Ensure this is where your service interfaces are defined
using KoiOrderingSystemInJapan.Service.Base; // Ensure this is where IServiceResult is defined

namespace KoiOrderingSystemInJapan.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderTripsController : ControllerBase
    { 
      private readonly IOrderTripService _orderTripService;

    public OrderTripsController(IOrderTripService orderTripService) => _orderTripService = orderTripService;

    // GET: api/OrderTrip
    [HttpGet]
    public async Task<IServiceResult> GetOrderTrips()
    {
        return await _orderTripService.GetAll();
    }

    // GET: api/OrderTrip/5
    [HttpGet("{id}")]
    public async Task<IServiceResult> GetOrderTrip(int id)
    {
        var trip = await _orderTripService.GetById(id);
        return trip;
    }

        // PUT: api/OrderTrip/5
        [HttpPut("{id}")]
    public async Task<IServiceResult> PutOrderTrip(int id, OrderTrip orderTrip)
    {
        return await _orderTripService.Save(orderTrip);
    }

        // POST: api/OrderTrip
        [HttpPost]
    public async Task<IServiceResult> PostOrderTrip( OrderTrip orderTrip)
    {
        return await _orderTripService.Save(orderTrip);
    }

        // DELETE: api/OrderTrip/5
        [HttpDelete("{id}")]
    public async Task<IServiceResult> DeleteOrderTrip(int id)
    {
        return await _orderTripService.DeleteById(id);

    }

    private bool OrderTripExists(int id)
    {

        return _orderTripService.GetById(id) != null;
    }

}
}
