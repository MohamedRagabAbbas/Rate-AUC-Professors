using System.ComponentModel.DataAnnotations;

namespace RateAucProfessors.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<Professor>? Professors { get; set; }
    }
}
