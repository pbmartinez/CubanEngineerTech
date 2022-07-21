
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tests.WebApiTests
{
    class WebApiApplication : WebApplicationFactory<Program>
    {
        private static WebApiApplication _webApiApplication = null!;
        
        private WebApiApplication()
        {

        }

        public static WebApiApplication GetWebApiApplication()
        {
            if (_webApiApplication == null)
            {
                _webApiApplication = new WebApiApplication();
            }
            return _webApiApplication;
        }

        public async Task ExecuteScopeAsync(Func<IServiceProvider, Task> action)
        {
            using var scope = GetWebApiApplication().Services.GetService<IServiceScopeFactory>()!.CreateScope();
            await action(scope.ServiceProvider);
        }

        

    }
}
