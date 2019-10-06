using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;
using WebApp.Client.Services;

namespace WebApp.Client.DI
{
    public static class DiCollection
    {
        public static ServiceProvider ServiceProvider = new ServiceCollection()
            .AddScoped<IApiServices, ApiServices>()
            .BuildServiceProvider();
    }
}
