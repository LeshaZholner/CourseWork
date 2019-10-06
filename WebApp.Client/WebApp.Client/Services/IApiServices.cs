using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Client.Services
{
    public interface IApiServices
    {
        Task<bool> RegisterAsync(string email, string password, string confirmPassword);
        Task LoginUserAsync(string username, string password);
    }
}
