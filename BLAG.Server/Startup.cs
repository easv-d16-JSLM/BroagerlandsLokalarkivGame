using System;
using BLAG.Common.Models;
using BLAG.Server.Hub;
using LiteDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace BLAG.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseCors(builder =>
                builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()
                        .AllowCredentials()        );
            //app.UseCors("CorsPolicy");
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSignalR(routes => { routes.MapHub<GameSessionHub>("/gamesession"); });
            app.UseMvc();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info {Title = "My API", Version = "v1"}); });
            var repository = new LiteRepository(Configuration.GetConnectionString("MainDatabase"));
            DbInitializer testData = new DbInitializer(repository);
            testData.SeedDatabase();
            Console.WriteLine(repository.Single<GameSession>(s => s.JoinCode == "abcde").Id);
            services.AddSingleton(repository);
            //services.AddCors(options => options.AddPolicy("CorsPolicy",
            //    builder =>
            //    {
            //        builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()
            //            .AllowCredentials();
            //    }));
            services.AddSignalR(o => o.EnableDetailedErrors = true);
        }
    }
}