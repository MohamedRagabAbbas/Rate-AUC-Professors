using System.ComponentModel.DataAnnotations;

namespace RateAucProfessors.Models
{
    public class Review   
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;
        [Range(1, 5)]
        public int Value { get; set; }
        //relationships
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Reaction>? Reactions { get; set; }
        public string UserId { get; set; }
        public Student? Student { get; set; }
        public int ProfessorId { get; set; }
        public Professor? Professor { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }

    }
}
