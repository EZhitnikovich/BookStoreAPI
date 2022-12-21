using BookStore.WebApi.Models;
using BookStore.WebApi.Options;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStore.WebApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly JwtSettings jwtSettings;

        public AuthService(UserManager<IdentityUser> userManager,
            JwtSettings jwtSettings)
        {
            this.userManager = userManager;
            this.jwtSettings = jwtSettings;
        }

        public async Task<AuthResponse> Login(string email, string password)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return new AuthResponse
                {
                    Succeeded = false,
                    Token = string.Empty,
                    Errors = new[] { "User not found." }
                };
            }

            var userHasValidPassword = await userManager.CheckPasswordAsync(user, password); ;

            if (!userHasValidPassword)
            {
                return new AuthResponse
                {
                    Succeeded = false,
                    Token = string.Empty,
                    Errors = new[] { "Password is incorrect." }
                }; ;
            }

            return GenerateResponseWithTokenByUser(user);
        }

        public async Task<AuthResponse> Registration(string email, string password)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user != null)
            {
                return new AuthResponse
                {
                    Succeeded = false,
                    Token = string.Empty,
                    Errors = new[] { "User with this email already exists." }
                };
            }

            user = new IdentityUser
            {
                Email = email,
                UserName = email
            };

            var res = await userManager.CreateAsync(user, password);

            if (!res.Succeeded)
            {
                return new AuthResponse
                {
                    Succeeded = false,
                    Token = string.Empty,
                    Errors = res.Errors.Select(x => x.Description)
                };
            }

            return GenerateResponseWithTokenByUser(user);
        }

        private AuthResponse GenerateResponseWithTokenByUser(IdentityUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim("id", user.Id)
                }),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthResponse
            {
                Succeeded = true,
                Token = tokenHandler.WriteToken(token),
                Errors = Enumerable.Empty<string>()
            };
        }
    }
}
