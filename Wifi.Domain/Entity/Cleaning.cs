using System.ComponentModel.DataAnnotations;

namespace Wifi.Domain.Entity
{
    public class Cleaning
    {
        public int Id { get; set; }
        public DateTime TimeOfCleaning { get; set; }
        [StringLength(250)]
        public string? Note { get; set; } 
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = default!;
        public int RoomId { get; set; }
        public Room Room { get; set; } = default!;
    }
}