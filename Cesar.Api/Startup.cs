using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cesar.Domain.CesarContext.Handlers;
using Cesar.Domain.CesarContext.Repositories;
using Cesar.Domain.CesarContext.Services;
using Cesar.Infra.CesarContext.DataContext;
using Cesar.Infra.CesarContext.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Cesar.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<CesarDataContext>();
            //var connection = "Data Source=Contatos.db"; // Configuration["ConexaoSqlite:SqliteConnectionString"];
            //services.AddDbContext<CesarDataContext>(options =>
            //    options.UseSqlite(connection)
            //);

            services.AddScoped<CesarDataContext, CesarDataContext>();
            services.AddTransient<ICollaboratorRepository, CollaboratorRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CollaboratorHandler, CollaboratorHandler>();
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "Cesar Colab", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();

            UpdateDatabase(app);
            app.UseSwagger();

            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                s.RoutePrefix = string.Empty;
            });
        }
        private static void UpdateDatabase(IApplicationBuilder app)
        {
            //using (var serviceScope = app.ApplicationServices
            //    .GetRequiredService<IServiceScopeFactory>()
            //    .CreateScope())
            //{
            //    using (var context = serviceScope.ServiceProvider.GetService<CesarDataContext>())
            //    {
            //        context.Database.Migrate();
            //    }
            //}

        }
    }
}
