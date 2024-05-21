using System.ComponentModel.DataAnnotations;

namespace RateAucProfessors.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Credit_Hours { get; set; } = string.Empty;
        public string? Prefix { get; set; } = string.Empty;
        // Relationships
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public ICollection<Document>? Documents { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Professor>? Professors { get; set; }
     
    }
}
