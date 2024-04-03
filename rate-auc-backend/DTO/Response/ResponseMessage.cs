namespace RateAucProfessors.DTO.Response
{
    public class ResponseMessage<T>
    {
        public string Message { get; set; } = string.Empty;
        public bool Status { get; set; } = false;
        public T? Data { get; set; }
    }
}
