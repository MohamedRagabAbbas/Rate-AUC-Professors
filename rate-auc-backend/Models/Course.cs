using System.ComponentModel.DataAnnotations;

namespace RateAucProfessors.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public int CreditHours { get; set; }

        // Relationships
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        public ICollection<Document>? Documents { get; set; }
        public ICollection<Review>? Reviews { get; set; }

        public string ProfessorEmail { get; set; }
        public Professor Professor { get; set; }
     
    }
}
