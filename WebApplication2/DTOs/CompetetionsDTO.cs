using System.ComponentModel.DataAnnotations;
using WebApplication2.Models;

namespace WebApplication2.DTOs
{
    public class CompetetionsDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Location { get; set; }
        public DateTime Date { get; set; }
        public int partTeamsnumber  { get; set; }
        public int countplayersnumber { get; set; }
        public Team Team { get; set; }
    }
}
