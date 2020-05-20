using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrganizerApi.Domain;
using OrganizerApi.Repository;
using OrganizerApi.Services;

namespace Common
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<OrganizerDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn")));
            services.AddScoped<IOrganizerDbContext>(provider => provider.GetService<OrganizerDbContext>());
            services.AddTransient<INoteDto, NoteDto>();
            services.AddTransient<IToDoDto, ToDoDto>();
            services.AddTransient<IScheduleEntryDto, ScheduleEntryDto>();
            services.AddScoped<INoteService<INoteDto>, NoteService<INoteDto>>();
            services.AddScoped<IToDoService<IToDoDto>, ToDoService<IToDoDto>>();
            services.AddScoped<IDayService, DayService>();
            services.AddScoped<IScheduleService<IScheduleEntryDto>, ScheduleService<IScheduleEntryDto>>();
        }
    }
}
