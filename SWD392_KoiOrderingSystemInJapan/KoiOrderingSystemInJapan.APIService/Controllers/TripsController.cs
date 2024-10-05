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
    public class TripsController : ControllerBase
    {
        private readonly ITripService _tripService;

        public TripsController(ITripService tripService) => _tripService = tripService;

        // GET: api/Trips
        [HttpGet]
        public async Task<IServiceResult> GetTrips()
        {
            return await _tripService.GetAll();
        }

        // GET: api/Trips/5
        [HttpGet("{id}")]
        public async Task<IServiceResult> GetTrip(int id)
        {
            var trip = await _tripService.GetById(id);

            return trip;
        }

        // PUT: api/Trips/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IServiceResult> PutTrip(int id, Trip trip)
        {
            return await _tripService.Save(trip);
        }

        // POST: api/Trips
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IServiceResult> PostTrip(Trip trip)
        {
            return await _tripService.Save(trip);
        }

        // DELETE: api/Trips/5
        [HttpDelete("{id}")]
        public async Task<IServiceResult> DeleteTrip(int id)
        {
            return await _tripService.DeleteById(id);
        }

        private bool TripExists(int id)
        {
            return _tripService.GetById(id) != null;
        }
    }
}
