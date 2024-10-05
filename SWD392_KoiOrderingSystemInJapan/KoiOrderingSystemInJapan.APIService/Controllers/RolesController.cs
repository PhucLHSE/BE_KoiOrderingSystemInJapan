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
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService) => _roleService = roleService;

        // GET: api/Roles
        [HttpGet]
        public async Task<IServiceResult> GetRoles()
        {
            return await _roleService.GetAll();
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<IServiceResult> GetRole(int id)
        {
            var role = await _roleService.GetById(id);

            return role;
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IServiceResult> PutRole(int id, Role role)
        {
            return await _roleService.Save(role);
        }

        // POST: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IServiceResult> PostRole(Role role)
        {
            return await _roleService.Save(role);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IServiceResult> DeleteRole(int id)
        {
            return await _roleService.DeleteById(id);
        }

        private bool RoleExists(int id)
        {
            return _roleService.GetById(id) != null;
        }
    }
}
