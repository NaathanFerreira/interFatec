using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Inter2
{
    public class Startup
    {
        // Adicionar serviços
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // Usar serviços
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           app.UseMvc(options => {
             options.MapRoute("default","{controller=Dashboard}/{action=Index}/{id?}");
           });
        }
    }
}
