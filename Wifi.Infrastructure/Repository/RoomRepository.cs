using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Wifi.Domain.Entity;
using Wifi.Infrastructure.Exceptions;

namespace Wifi.Infrastructure.Repository
{
    public class RoomRepository : BaseRepository, IRoomRepository
    {
        public async Task<string> GetLastCleanerOfRoom(string nfc)
        {
            try
            {
                using (context = new())
                {
                    var room = await context.Room
                        .Include(x => x.Cleanings)
                            .ThenInclude(x => x.Employee)
                        .FirstOrDefaultAsync(x => x.Nfc_Id.ToLower() == nfc.ToLower());

                    if (room is null || room.Cleanings is null)
                        throw new RoomNotFoundException();

                    if (room.Cleanings.Count() < 1)
                        throw new NoEntryException();

                    var lastCleaning = room.Cleanings
                        .OrderByDescending(x => x.TimeOfCleaning)
                        .First();

                    return lastCleaning.Employee.Email;
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<int> GetRoomIdByNFC(string nfc)
        {
            try
            {
                using (context = new())
                {
                    var room = await context.Room
                        .FirstOrDefaultAsync(x => x.Nfc_Id.ToLower() == nfc.ToLower());

                    if (room is null)
                        throw new RoomNotFoundException();
                    else
                        return room.Id;
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
