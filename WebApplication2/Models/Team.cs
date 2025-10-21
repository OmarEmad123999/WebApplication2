using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
      
        public string? City { get; set; }
        public int CoachId { get; set; }
        [ForeignKey("CoachId")]
        public Coach Coach { get; set; }
        public List<Player> Players { get; set; }
        public List<Competetion> competetions { get; set; }
    }
}
