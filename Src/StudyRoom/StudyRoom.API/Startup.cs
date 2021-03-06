using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using StudyRoom.API.Data;
using StudyRoom.API.Repository.Interface;
using StudyRoom.API.Repository;
using Microsoft.OpenApi.Models;

namespace StudyRoom.API
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
            services.AddControllers();

            // Repository class configuration
            services.AddTransient<IRoomsRepository,RoomRepository>();

            //# Connection string local
            //var connection = @"Server=127.0.0.1,1435;Database=RoomData;User=sa;Password=Staycool@99;";
            //services.AddDbContext<StudyRoomDbContext>(options => options.UseSqlServer(connection),ServiceLifetime.Singleton);

            services.AddTransient<IRoomsRepository,RoomRepository>();

            services.AddDbContext<StudyRoomDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("StudyRoomDbContext")),ServiceLifetime.Singleton);

            services.AddSwaggerGen(c=> {
                c.SwaggerDoc("v1",new OpenApiInfo{ Title = "Study Room API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Study Room API v1"); });
        }
    }
}
