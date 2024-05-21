using System.ComponentModel.DataAnnotations;

namespace RateAucProfessors.Models
{
    public class Feed
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;
        // Relationships
        public string UserId { get; set; }
        public Student? Student { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Reaction>? Reactions { get; set; }
    }
}
