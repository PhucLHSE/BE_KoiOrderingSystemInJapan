// IAuthenticationRepository.cs
using KoiOrderingSystemInJapan.Data.DBContext;
using KoiOrderingSystemInJapan.Data.Models;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Data.Repository
{
    public interface IAuthenticationRepository
    {
        User GetUserByEmail(string email);
        Task AddUserAsync(User user);
        Role GetUserRoleById(int roleId);
        Task CommitAsync();
        User GetUserById(int userId);
        void UpdateUser(User user);
    }



    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly KoiOrderingSystemInJapanContext _context;

        public AuthenticationRepository(KoiOrderingSystemInJapanContext context)
        {
            _context = context;
        }

        public User GetUserByEmail(string email) => _context.Users.FirstOrDefault(x => x.Email == email);

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public Role GetUserRoleById(int roleId) => _context.Roles.FirstOrDefault(r => r.RoleId == roleId);
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
        public User GetUserById(int userId) => _context.Users.FirstOrDefault(x => x.UserId == userId);

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }

    }
}

