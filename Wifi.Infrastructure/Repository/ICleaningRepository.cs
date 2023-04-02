using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.Domain.Entity;

namespace Wifi.Infrastructure.Repository
{
    public interface ICleaningRepository
    {
        Task CreateCleaning(Cleaning cleaning);
        Task<Cleaning[]> GetCleaningHistoryOfEmployee(int EmployeeId);
    }
}
