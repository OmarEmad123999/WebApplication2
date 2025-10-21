using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Models;

namespace WebApplication2.DTOs
{
    public class TeamDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string? City { get; set; }
        public int CoachId { get; set; }
        public int Playercount { get; set; }
    }
}
