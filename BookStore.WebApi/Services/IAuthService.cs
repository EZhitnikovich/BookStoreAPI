using BookStore.WebApi.Models;

namespace BookStore.WebApi.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> Registration(string email, string password);
        Task<AuthResponse> Login(string email, string password);
    }
}
