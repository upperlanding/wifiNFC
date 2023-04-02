using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.Domain.Entity;

namespace Wifi.Infrastructure.Repository
{
    public class CleaningRepository : BaseRepository, ICleaningRepository
    {
        public async Task CreateCleaning(Cleaning cleaning)
        {
			try
			{
				using(context = new())
				{
					await context.Cleaning.AddAsync(cleaning);
					await context.SaveChangesAsync();
				}
			}
			catch (Exception)
			{
				throw new Exception();
			}
        }

        public async Task<Cleaning[]> GetCleaningHistoryOfEmployee(int EmployeeId)
        {
            try
            {
                using (context = new())
                {
                    return await context.Cleaning
                        .Include(x => x.Room)
                        .Where(x => x.EmployeeId == EmployeeId)
                        .ToArrayAsync();
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
