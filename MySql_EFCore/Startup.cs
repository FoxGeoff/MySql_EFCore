using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySql_EFCore.Data.Entities;

namespace MySql_EFCore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _env;
        private string _testSecret = null;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _testSecret = _configuration["MySecret"];
            /*
            services.AddDbContext<MySqlDbContext>(options =>
                options.UseMySql(_configuration.GetConnectionString("MySqlConnectionString")));
            */

            services.AddDbContext<MySqlDbContext>(options =>
                options.UseMySql(_configuration["MySecret"]));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                /*TODO: replace with logging
                var result = string.IsNullOrEmpty(_testSecret) ? "Null" : "Not Null";
                app.Run(async (context) =>
                {
                    await context.Response.WriteAsync($"Secret is {result}");
                });
                */
            }

app.UseMvc();
        }
    }
}
