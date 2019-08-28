using Credit.API.Models.Request;
using Credit.API.Validations;
using Credit.Business.Abstract;
using Credit.Business.Concrete;
using Credit.Data.Abstract;
using Credit.Data.Concrete.EntityFramework;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace Credit.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddFluentValidation(o =>
            {
                o.RegisterValidatorsFromAssemblyContaining<CustomerValidator>();
            });

            services.AddScoped<ICustomerDal, EfCustomerDal>();
            services.AddScoped<ICustomerScoreDal, EfCustomerScoreDal>();
            services.AddScoped<ICustomerHistoryDal, EfCustomerHistoryDal>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ISmsSender, SmsSender>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Credit System", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.AddFluentValidationRules();
            });

            services.AddSingleton<AbstractValidator<CustomerCreditRequest>, CustomerValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", ".Net Core API"));
        }
    }
}
