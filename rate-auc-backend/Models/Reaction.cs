using System.ComponentModel.DataAnnotations;

namespace RateAucProfessors.Models
{
    public class Reaction
    {
        
        [Required]
        public bool IsLike { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;

        // Relationships
        public string UserId { get; set; }
        public Student? Student { get; set; }

        public string UserId { get; set; }
        public Student? Student { get; set; }

        public string UserId { get; set; }
        public Student? Student { get; set; }
    }
}
