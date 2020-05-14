using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrganizerApi.Domain;
using OrganizerApi.Repository;
using OrganizerApi.Services;
using Services.Services;

namespace OrganizerApi
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
            services.AddControllers().AddNewtonsoftJson(); ;
            services.AddDbContext<OrganizerDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn")));
            services.AddScoped<IOrganizerDbContext>(provider => provider.GetService<OrganizerDbContext>());
            services.AddTransient<INoteDto, NoteDto>();
            services.AddTransient<IToDoDto, ToDoDto>();
            services.AddScoped<INoteService<INoteDto>, NoteService<INoteDto>>();
            services.AddScoped<IToDoService<IToDoDto>, ToDoService<IToDoDto>>();
            services.AddScoped<IDayService, DayService>();

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
        }
    }
}
