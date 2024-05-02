namespace RateAucProfessors.DTO.Response
{
    public class AuthenticationResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsAuthenticated { get; set; } = false;
        public string Token { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
