using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Competetion
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Location { get; set; }
        public DateTime Date { get; set; }

        public List<Team> teams { get; set; }

    }
}
