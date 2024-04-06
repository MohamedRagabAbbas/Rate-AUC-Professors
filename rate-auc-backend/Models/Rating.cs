using System.ComponentModel.DataAnnotations;

namespace RateAucProfessors.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;

        [Required]
        [Range(1, 5)]
        public int Value { get; set; }
        public string Comments { get; set; } = string.Empty;

        //Relationships
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public int ProfessorId { get; set; }
        public Professor? Professor { get; set; }

        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
