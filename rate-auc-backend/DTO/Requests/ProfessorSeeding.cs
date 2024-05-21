namespace RateAucProfessors.DTO.Requests
{
    public class ProfessorSeeding
    {
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Bio { get; set; } = string.Empty;
        public string? Image { get; set; } = string.Empty;
        public string? Position { get; set; } = string.Empty;
        public string departmentName { get; set; } = string.Empty;
    }
}
