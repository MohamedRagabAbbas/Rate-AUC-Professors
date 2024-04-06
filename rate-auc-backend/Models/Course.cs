using System.ComponentModel.DataAnnotations;

namespace RateAucProfessors.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        // Relationships
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public ICollection<Professor>? Professors { get; set; }
        public ICollection<Syllabus>? Syllabuses { get; set; }
        public ICollection<Lecture>? Lectures { get; set; }
        public ICollection<Note>? Notes { get; set; }
        public ICollection<Assignment>? Assignments { get; set; }
        public ICollection<Rating>? Ratings { get; set; }
    }
}
