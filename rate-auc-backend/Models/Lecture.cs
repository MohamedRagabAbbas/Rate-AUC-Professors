using System.ComponentModel.DataAnnotations;

namespace RateAucProfessors.Models
{
    public class Lecture
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;
        public DateTime UploadDate { get; set; } = DateTime.Now;

        //Relationships
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int ProfessorId { get; set; }
        public Professor? Professor { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
