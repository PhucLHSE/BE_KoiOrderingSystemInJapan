using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using KoiOrderingSystemInJapan.Service.Services;
using KoiOrderingSystemInJapan.Service.Interfaces;
namespace KoiOrderingSystemInJapan.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KoiFishVarietiesController : ControllerBase
    {
        private readonly IKoiFishVarietyService _koiFishVarietyService;
        public KoiFishVarietiesController(IKoiFishVarietyService koiFishVarietyService)
        {
            _koiFishVarietyService = koiFishVarietyService;
        }



        // GET: api/KoiFishVarieties
        [HttpGet]
        public async Task<IServiceResult> GetKoiFish()
        {
            return await _koiFishVarietyService.GetAll();
        }

        // GET: api/KoiFishVarieties/5
        [HttpGet("{id}")]
        public async Task<IServiceResult> GetKoi(int id)
        {
            var variety = await _koiFishVarietyService.GetById(id);

            return variety;
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IServiceResult> PutKoi(int id, KoiFishVariety koiFishVariety)
        {
            return await _koiFishVarietyService.Save(koiFishVariety);
        }

        // POST: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IServiceResult> PostKoi(KoiFishVariety koiFishVariety)
        {
            return await _koiFishVarietyService.Save(koiFishVariety);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IServiceResult> DeleteKoiFish(int id)
        {
            return await _koiFishVarietyService.DeleteById(id);
        }

        private bool RoleExists(int id)
        {
            return _koiFishVarietyService.GetById(id) != null;
        }
    }
}
