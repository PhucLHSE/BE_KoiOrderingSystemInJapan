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
using Microsoft.AspNetCore.Authorization;
using KoiOrderingSystemInJapan.Service.Services;
using KoiOrderingSystemInJapan.Service.Interfaces;
namespace KoiOrderingSystemInJapan.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmsController : ControllerBase
    {
        private readonly IFarmService _farmService;

        public FarmsController(IFarmService farmService) => _farmService = farmService;

        // GET: api/Farms
        [HttpGet]
        public async Task<IServiceResult> GetFarms()
        {
            return await _farmService.GetAll();
        }

        // GET: api/Farms/5
        [HttpGet("{id}")]
        public async Task<IServiceResult> GetFarm(int id)
        {
            var farm = await _farmService.GetById(id);

            return farm;
        }

        // PUT: api/Farms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IServiceResult> PutFarm(int id, Farm farm)
        {
            return await _farmService.Save(farm);
        }

        // POST: api/Farms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IServiceResult> PostFarm(Farm farm)
        {
            return await _farmService.Save(farm);
        }

        // DELETE: api/Farms/5
        [HttpDelete("{id}")]
        public async Task<IServiceResult> DeleteFarm(int id)
        {
            return await _farmService.DeleteById(id);
        }

        private bool FarmExists(int id)
        {
            return _farmService.GetById(id) != null;
        }
    }
}
