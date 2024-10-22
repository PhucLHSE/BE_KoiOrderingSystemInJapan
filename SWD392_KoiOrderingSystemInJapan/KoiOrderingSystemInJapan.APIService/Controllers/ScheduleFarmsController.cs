using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystemInJapan.Data.DBContext;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using KoiOrderingSystemInJapan.Service;

namespace KoiOrderingSystemInJapan.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleFarmsController : ControllerBase
    {
        private readonly IScheduleFarmService _scheduleFarmService;

        public ScheduleFarmsController(IScheduleFarmService scheduleFarmService) => _scheduleFarmService = scheduleFarmService;

        // GET: api/ScheduleFarms
        [HttpGet]
        public async Task<IServiceResult> GetScheduleFarms()
        {
            return await _scheduleFarmService.GetAll();
        }

        // GET: api/ScheduleFarms/5
        [HttpGet("{id}")]
        public async Task<IServiceResult> GetScheduleFarm(int id)
        {
            var scheduleFarm = await _scheduleFarmService.GetById(id);

            return scheduleFarm;
        }

        // PUT: api/ScheduleFarms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IServiceResult> PutScheduleFarm(int id, ScheduleFarm scheduleFarm)
        {
            return await _scheduleFarmService.Save(scheduleFarm);
        }

        // POST: api/ScheduleFarms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IServiceResult> PostScheduleFarm(ScheduleFarm scheduleFarm)
        {
            return await _scheduleFarmService.Save(scheduleFarm);
        }

        // DELETE: api/ScheduleFarms/5
        [HttpDelete("{id}")]
        public async Task<IServiceResult> DeleteScheduleFarm(int id)
        {
            return await _scheduleFarmService.DeleteById(id);
        }

        private bool FarmExists(int id)
        {
            return _scheduleFarmService.GetById(id) != null;
        }
    }
}
