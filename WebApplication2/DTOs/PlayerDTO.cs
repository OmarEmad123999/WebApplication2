using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Models;

namespace WebApplication2.DTOs
{
    public class PlayerDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string? Position { get; set; }
        public int Age { get; set; }
        public int TeamId { get; set; }
    }
}
