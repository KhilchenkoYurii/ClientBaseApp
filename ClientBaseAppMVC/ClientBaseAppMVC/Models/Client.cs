using System.ComponentModel.DataAnnotations;

namespace ClientBaseAppMVC.Models
{
    public class Client
    {
        public string? Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Surname { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Phone { get; set; } = null!;

        public string Address { get; set; } = null!;
    }
}
