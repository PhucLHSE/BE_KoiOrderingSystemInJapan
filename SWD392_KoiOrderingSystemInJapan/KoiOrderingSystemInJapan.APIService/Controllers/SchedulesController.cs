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
    public class SchedulesController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public SchedulesController(IScheduleService scheduleService) => _scheduleService = scheduleService;

        // GET: api/Schedules
        [HttpGet]
        public async Task<IServiceResult> GetSchedules()
        {
            return await _scheduleService.GetAll();
        }

        // GET: api/Schedules/5
        [HttpGet("{id}")]
        public async Task<IServiceResult> GetSchedule(int id)
        {
            var schedule = await _scheduleService.GetById(id);

            return schedule;
        }

        // PUT: api/Schedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IServiceResult> PutSchedule(int id, Schedule schedule)
        {
            return await _scheduleService.Save(schedule);
        }

        // POST: api/Schedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IServiceResult> PostSchedule(Schedule schedule)
        {
            return await _scheduleService.Save(schedule);
        }

        // DELETE: api/Schedules/5
        [HttpDelete("{id}")]
        public async Task<IServiceResult> DeleteSchedule(int id)
        {
            return await _scheduleService.DeleteById(id);
        }

        private bool ScheduleExists(int id)
        {
            return _scheduleService.GetById(id) != null;
        }
    }
}
