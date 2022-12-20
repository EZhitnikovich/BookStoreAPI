using BookStore.WebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            var user = await userManager.FindByEmailAsync(userDto.Email);
            if (user != null)
            {
                return Conflict(nameof(user));
            }

            user = new IdentityUser
            {
                Email = userDto.Email,
                UserName = userDto.Email
            };

            var res = await userManager.CreateAsync(user, userDto.Password);

            if(res.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
