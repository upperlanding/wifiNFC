using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wifi.Infrastructure.Repository;

namespace WifiNFC.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        [HttpGet]
        public async Task<ActionResult<string>> LastCleanerOfRoom([FromHeader]string roomNfc)
        {
            return Ok(await roomRepository.GetLastCleanerOfRoom(roomNfc));
        }
    }
}
