namespace RateAucProfessors.JWT
{
    public class Jwt
    {
        public Jwt() { }
        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int ExpireAfterInMinutes { get; set; } = 0;
    }
}
