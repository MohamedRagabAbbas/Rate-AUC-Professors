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

        public int Comment_no { get; set; }
        public Comment? Comment { get; set; }

        public int review_no { get; set; }
        public Review? Review { get; set; }

        public int PostId { get; set; }
        public Post? Post { get; set; }

        public int reply_no { get; set; }
        public Reply? Reply { get; set; }

    }
}
