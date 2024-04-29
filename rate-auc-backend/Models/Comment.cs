using System.ComponentModel.DataAnnotations;

namespace RateAucProfessors.Models
{
    public class Comment
    {
        public int Id { get; set; };

        [Required]
        public string Content { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;

        // Relationships
        public string UserId { get; set; } 
        public Student? Student { get; set; }
        public int FeedId { get; set; }
        public Feed? Feed { get; set; }
        public int ReviewId { get; set; }
        public Review? Review { get; set; }
        public ICollection<Reaction>? Reactions { get; set; }
        public ICollection<Reply>? Replies { get; set; }
    }
}
