using RateAucProfessors.Models;
using System.ComponentModel.DataAnnotations;

namespace RateAucProfessors.DTO.Requests
{
    public class CourseInfo
    {
        public string Name { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
    }
}
