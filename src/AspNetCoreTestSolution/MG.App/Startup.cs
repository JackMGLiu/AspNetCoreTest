using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MG.Data.Repositories;
using MG.Entity;
using MG.Entity.DbContext;
using MG.Infrastructure.Repositories;
using MG.Service.Impl;
using MG.Service.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MG.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //数据库链接
            var connection = Configuration.GetConnectionString("SqlServerConnection");
            services.AddDbContextPool<ProjectContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("MG.App")));

            //工作单元
            services.AddUnitOfWork<ProjectContext>();

            //DI
            AddDependencies(services);

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private IServiceCollection AddDependencies(IServiceCollection services)
        {
            //services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IBaseRepository<Account>, BaseRepository<Account>>();
            services.AddSingleton<IBaseRepository<SysRole>, BaseRepository<SysRole>>();
            services.AddSingleton<IBaseRepository<SysOrganize>, BaseRepository<SysOrganize>>();

            //Services
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ISysRoleService, SysRoleService>();

            return services;
        }
    }
}
