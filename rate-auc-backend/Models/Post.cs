using System.ComponentModel.DataAnnotations;

namespace RateAucProfessors.Models
{
    public class Post
    {
        public int ID { get; set; }

        [Required]
        public string Text { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;


        // Relationships
        public string UserId { get; set; }
        public Student? Student { get; set; }
        public ICollection<Comment>? Comments { get; set; }

    }
}
