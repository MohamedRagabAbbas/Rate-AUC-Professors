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
        public string UserId { get; set; }
        public Student? Student { get; set; }
        public int CommentId { get; set; }
        public Comment? Comment { get; set; }
        public int ReviewId { get; set; }
        public Review? Review { get; set; }
        public int FeedId { get; set; }
        public Feed? Feed { get; set; }
        public int ReplyId { get; set; }
        public Reply? Reply { get; set; }

    }
}
