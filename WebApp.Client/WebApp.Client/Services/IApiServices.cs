using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.Client.Models;
using WebApp.Client.Request;

namespace WebApp.Client.Services
{
    public interface IApiServices
    {
        Task<ApiRequest> RegisterAsync(RegisterBindingModel model);
        Task<ApiRequest> LoginUserAsync(string username, string password);
        Task<UserInfo> UserInfoAsync();
        Task<ApiRequest> ChangePasswordAsync(ChangePassword model);
        Task<ApiRequest> LogoutUserAsync();
    }
}
