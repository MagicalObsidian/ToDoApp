using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ToDoApp.Api.Context;
using ToDoApp.Api.Context.Repository;
using ToDoApp.Api.Extensions;
using ToDoApp.Api.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ToDoApp.Api
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
            services.AddDbContext<ToDoAppContext>(option =>
            {
                var connectionString = Configuration.GetConnectionString("ToDoConnection");
                option.UseSqlite(connectionString);
            }).AddUnitOfWork<ToDoAppContext>()
            .AddCustomRepository<ToDo, ToDoRepository>()
            .AddCustomRepository<Memo, MemoRepository>()
            .AddCustomRepository<User, UserRepository>();


            services.AddControllers();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDoApp.Api", Version = "v1" });
            });


            //services.AddDbContext<ToDoAppContext>(option =>
            //{
            //    var connectionString = Configuration.GetConnectionString("ToDoConnection");
            //    option.UseSqlite(connectionString);
            //}).AddUnitOfWork<ToDoAppContext>()
            //.AddCustomRepository<ToDo, ToDoRepository>()
            //.AddCustomRepository<Memo, MemoRepository>()
            //.AddCustomRepository<User, UserRepository>();

            services.AddTransient<IToDoService, ToDoService>();
            services.AddTransient<IMemoService, MemoService>();
            services.AddTransient<ILoginService, LoginService>();

            //添加AutoMapper
            var automapperConfog = new MapperConfiguration(config =>
            {
                config.AddProfile(new AutoMapperProFile());
            });

            services.AddSingleton(automapperConfog.CreateMapper());


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyToDo.Api v1"));
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapSwagger();
            });
        }
    }
}