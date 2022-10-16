using Microsoft.AspNetCore.Identity;

namespace BookStore.Models
{
    public class User: IdentityUser
    {
        public string Name { get; set; }
    }
}
