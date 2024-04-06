using System.ComponentModel.DataAnnotations;

namespace RateAucProfessors.Models
{
    public class Reaction
    {
        public int Id { get; set; }

        [Required]
        public bool IsLike { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;

        // Relationships
        public int FeedId { get; set; }
        public Feed? Feed { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
