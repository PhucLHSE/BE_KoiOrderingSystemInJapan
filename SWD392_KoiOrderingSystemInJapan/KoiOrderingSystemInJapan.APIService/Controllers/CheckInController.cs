using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using KoiOrderingSystemInJapan.Service;
using Microsoft.AspNetCore.Mvc;

namespace KoiOrderingSystemInJapan.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckInsController : ControllerBase
    {
        private readonly ICheckInService _checkInService;

        public CheckInsController(ICheckInService checkInService)
        {
            _checkInService = checkInService;
        }

        // GET: api/CheckIns
        [HttpGet]
        public async Task<IServiceResult> GetCheckIns()
        {
            return await _checkInService.GetAll();
        }

        // GET: api/CheckIns/5
        [HttpGet("{id}")]
        public async Task<IServiceResult> GetCheckIn(int id)
        {
            var checkIn = await _checkInService.GetById(id);
            return checkIn;
        }

        // PUT: api/CheckIns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IServiceResult> PutCheckIn(int id, CheckIn checkIn)
        {
            if (id != checkIn.CheckInId)
            {
                return new ServiceResult(400, "Invalid CheckIn ID");
            }

            return await _checkInService.Save(checkIn);
        }

        // POST: api/CheckIns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IServiceResult> PostCheckIn(CheckIn checkIn)
        {
            return await _checkInService.Save(checkIn);
        }

        // DELETE: api/CheckIns/5
        [HttpDelete("{id}")]
        public async Task<IServiceResult> DeleteCheckIn(int id)
        {
            return await _checkInService.DeleteById(id);
        }

        private bool CheckInExists(int id)
        {
            return _checkInService.GetById(id) != null;
        }
    }
}
