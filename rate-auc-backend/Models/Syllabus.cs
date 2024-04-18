using System.ComponentModel.DataAnnotations;

namespace RateAucProfessors.Models
{
    public class Syllabus
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;
        public DateTime UploadDate { get; set; } = DateTime.Now;

        //Relationships
        public string UserId { get; set; }
        public Student? Student { get; set; } 
        public int ProfessorId { get; set; }
        public Professor? Professor { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
