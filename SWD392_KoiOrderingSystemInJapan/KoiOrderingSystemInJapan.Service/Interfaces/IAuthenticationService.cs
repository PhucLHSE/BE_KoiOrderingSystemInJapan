using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Service.Interfaces
{
    public interface IAuthenticationService
    {
        string Authenticate(string email, string password, out User user);
        Task<IServiceResult> RegisterAsync(User user);
        Task<IServiceResult> ForgotPasswordAsync(string email);
        Task<IServiceResult> ResetPasswordAsync(string token, string newPassword);
    }
}
