using System.ComponentModel.DataAnnotations;

namespace Wifi.Domain.Entity
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nfc_Id { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        public IEnumerable<Cleaning> Cleanings { get; set; } = default!;
    }
}