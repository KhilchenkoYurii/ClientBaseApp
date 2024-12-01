using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ClientBaseAppMVC.Models
{
    [BsonIgnoreExtraElements]
    public class Client
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(30)]
        public string Surname { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [Phone]
        public string Phone { get; set; } = null!;
        
        [MaxLength(20)]
        public string Address { get; set; } = null!;
    }
}
