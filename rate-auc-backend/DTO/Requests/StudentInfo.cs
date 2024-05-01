using RateAucProfessors.Models;

namespace RateAucProfessors.DTO.Requests
{
    public class StudentInfo
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Standing { get; set; } = string.Empty;
        public string GraduationYear { get; set; } = string.Empty;
        public string Student_Id { get; set; } = string.Empty;
        public string? Color { get; set; } = "#6171BA";
    }
}
