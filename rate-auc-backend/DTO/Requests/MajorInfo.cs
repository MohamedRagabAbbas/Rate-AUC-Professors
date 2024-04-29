using RateAucProfessors.Models;

namespace RateAucProfessors.DTO.Requests
{
    public class MajorInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
    }
}
