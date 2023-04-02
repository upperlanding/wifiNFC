using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wifi.Domain.Entity;
using Wifi.Infrastructure.Exceptions;
using Wifi.Infrastructure.Repository;
using WifiNFC.Api.DTO;
using WifiNFC.Api.Services.Mapper;

namespace WifiNFC.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CleaningController : ControllerBase
    {
        private readonly ICleaningRepository cleaningRepository;
        private readonly IDTOMapper mapper;
        private readonly IRoomRepository roomRepository;

        public CleaningController(ICleaningRepository cleaningRepository,
            IDTOMapper mapper, IRoomRepository roomRepository)
        {
            this.cleaningRepository = cleaningRepository;
            this.mapper = mapper;
            this.roomRepository = roomRepository;
        }

        [HttpGet]
        public async Task<ActionResult<DTOCleaning[]>> GetCleaningHistory()
        {
            var id = HttpContext.User.Identity?.Name ?? "";
            if (String.IsNullOrEmpty(id) ||
                !Int32.TryParse(id, out int parsedId))
                throw new TokenException();

            var getHistory =
                await cleaningRepository.GetCleaningHistoryOfEmployee(parsedId);

            return Ok(mapper.CleaningToDTO(getHistory));
        }

        [HttpPost]
        public async Task<ActionResult> CreateCleaning(DTOCreateCleaning cleaning)
        {
            var id = HttpContext.User.Identity?.Name ?? "";
            if (String.IsNullOrEmpty(id) ||
                !Int32.TryParse(id, out int parsedId))
                throw new TokenException();

            var roomId = await roomRepository.GetRoomIdByNFC(cleaning.NfcCode);

            Cleaning newCleaning = new()
            {
                EmployeeId = parsedId,
                Note = cleaning.Note,
                TimeOfCleaning = DateTime.Now,
                RoomId = roomId
            };

            await cleaningRepository.CreateCleaning(newCleaning);

            return Ok();
        }
    }
}
