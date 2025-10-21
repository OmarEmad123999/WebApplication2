using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Coach
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Specialization { get; set; }
        [Required]
        public int ExperienceYears { get; set; }
        public Team Team { get; set; }
    }
}
