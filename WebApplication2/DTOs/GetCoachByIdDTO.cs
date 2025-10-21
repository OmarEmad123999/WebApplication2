using System.ComponentModel.DataAnnotations;
using WebApplication2.Models;

namespace WebApplication2.DTOs
{
    public class GetCoachByIdDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Specialization { get; set; }
        [Required]
        public int ExperienceYears { get; set; }
        public int PlayersCount { get; set; }
        public Team Team { get; set; }
    }
}
