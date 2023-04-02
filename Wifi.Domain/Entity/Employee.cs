using System.ComponentModel.DataAnnotations;

namespace Wifi.Domain.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(255)]
        public string Password { get; set; } = string.Empty;
        public IEnumerable<Cleaning> Cleanings { get; set; } = default!;
    }
}