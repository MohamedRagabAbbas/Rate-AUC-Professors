using System.ComponentModel.DataAnnotations;

namespace RateAucProfessors.Models
{
    public class Major
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Relationships
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public ICollection<StudentMajor>? StudentMajors { get; set; }

    }
}
