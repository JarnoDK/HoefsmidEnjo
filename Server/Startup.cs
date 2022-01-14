
using FluentValidation.AspNetCore;
using HoefsmidEnjo.Shared.Event;
using HoefsmidEnjo.Shared.Invoice;
using HoefsmidEnjo.Shared.InvoiceItem;
using HoefsmidEnjo.Shared.InvoiceLine;
using HoefsmidEnjo.Shared.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Services.Data;
using Services.EventService;
using Services.InvoiceItemService;
using Services.InvoiceService;
using Services.UserService;

namespace Server
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
            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(type => type.ToString());
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sportstore API", Version = "v1" });
            });


            var builder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("sqlserver"));
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.ConnectionString)
                    .EnableSensitiveDataLogging(Configuration.GetValue<bool>("Logging:EnableSqlParameterLogging")));



            services.AddControllersWithViews().AddFluentValidation(config =>
            {
                //config.RegisterValidatorsFromAssemblyContaining<>();
                config.ImplicitlyValidateChildProperties = true;
            });
            services.AddRazorPages();

            services.AddScoped<DataInitializer>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IInvoiceItemService, InvoiceItemService>();
            services.AddScoped<IInvoiceLineService, FakeInvoiceLineService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IInvoiceService, InvoiceService>();


        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,DataInitializer data)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            data.SeedData();

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
