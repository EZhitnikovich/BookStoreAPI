namespace BookStore.WebApi.Models
{
    public class AuthResponse
    {
        public bool Succeeded { get; set; }
        public string Token { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
