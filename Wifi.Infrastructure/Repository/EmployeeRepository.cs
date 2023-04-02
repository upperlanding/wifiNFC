using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.Domain.Entity;

namespace Wifi.Infrastructure.Repository
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public async Task<Employee?> CheckCredentialsAndGetUser(string email, string pwd)
        {
			try
			{
				using(context = new())
				{
					return await context.Employee
						.FirstOrDefaultAsync(x =>
							x.Password == pwd &&
							x.Email == email);
				}
			}
			catch (Exception)
			{
				throw new Exception();
			}
        }
    }
}
