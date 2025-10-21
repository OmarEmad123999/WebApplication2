using System.ComponentModel.DataAnnotations;
using WebApplication2.Models;

namespace WebApplication2.DTOs
{
    public class CoachDTO
    {

        [Required]
        public string Name { get; set; }
       
    }
    public class GetBYIDCoachDTO
    {

        [Required]
        public string Name { get; set; }
        public int Totalnumberplayers { get; set; }
        public Team Team { get; set; }

    }
}

