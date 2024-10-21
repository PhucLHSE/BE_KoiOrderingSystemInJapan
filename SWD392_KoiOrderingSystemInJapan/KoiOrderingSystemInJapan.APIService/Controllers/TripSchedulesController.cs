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
    public class TripSchedulesController : ControllerBase
    {
        private readonly ITripScheduleService _tripScheduleService;

        public TripSchedulesController(ITripScheduleService tripScheduleService) => _tripScheduleService = tripScheduleService;

        // GET: api/TripSchedules
        [HttpGet]
        public async Task<IServiceResult> GetTripSchedules()
        {
            return await _tripScheduleService.GetAll();
        }

        // GET: api/TripSchedules/5
        [HttpGet("{id}")]
        public async Task<IServiceResult> GetTripSchedule(int id)
        {
            var user = await _tripScheduleService.GetById(id);

            return user;
        }

        // PUT: api/TripSchedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IServiceResult> PutTripSchedule(int id, TripSchedule tripSchedule)
        {
            return await _tripScheduleService.Save(tripSchedule);
        }

        // POST: api/TripSchedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IServiceResult> PostTripSchedule(TripSchedule tripSchedule)
        {
            return await _tripScheduleService.Save(tripSchedule);
        }

        // DELETE: api/TripSchedules/5
        [HttpDelete("{id}")]
        public async Task<IServiceResult> DeleteTripSchedule(int id)
        {
            return await _tripScheduleService.DeleteById(id);
        }

        private bool TripScheduleExists(int id)
        {
            return _tripScheduleService.GetById(id) != null;
        }
    }
}
