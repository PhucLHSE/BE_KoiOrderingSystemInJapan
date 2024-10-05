using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service;
using KoiOrderingSystemInJapan.Service.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KoiOrderingSystemInJapan.APIService.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class KoiFishController : ControllerBase
    {
        private readonly IKoiFishService koiFishService;
        public KoiFishController(IKoiFishService koiFishService)
        {
            this.koiFishService = koiFishService;
        }

        [HttpGet]
        public async Task<IServiceResult> GetKoiFish()
        {
            return await koiFishService.GetAll();
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<IServiceResult> GetRole(int id)
        {
            var role = await koiFishService.GetById(id);

            return role;
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IServiceResult> PutRole(int id, KoiFish koiFish)
        {
            return await koiFishService.Save(koiFish);
        }

        // POST: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IServiceResult> PostRole(KoiFish koiFish)
        {
            return await koiFishService.Save(koiFish);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IServiceResult> DeleteRole(int id)
        {
            return await koiFishService.DeleteById(id);
        }

        private bool RoleExists(int id)
        {
            return koiFishService.GetById(id) != null;
        }
    }
}
