using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.Infrastructure.Repository;

namespace Wifi.Infrastructure
{
    public static class DInjection
    {
        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<ICleaningRepository, CleaningRepository>();
        }
    }
}
