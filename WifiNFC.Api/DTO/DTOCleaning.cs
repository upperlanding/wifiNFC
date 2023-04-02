using Wifi.Domain.Entity;

namespace WifiNFC.Api.DTO
{
    public class DTOCleaning
    {
        public DTOCleaning(DateTime time, string room, string? note)
        {
            this.Time = time;
            this.Room = room;
            this.Note = note ?? "";
        }

        public DateTime Time { get; set; }
        public string Room { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
    }

}
