using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.Client.Models;

namespace WebApp.Client.Services
{
    public interface IApiServices
    {
        Task<bool> RegisterAsync(RegisterBindingModel model);
        Task<bool> LoginUserAsync(string username, string password);
    }
}
