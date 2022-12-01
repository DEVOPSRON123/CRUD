using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace CRUD.Models
{
    public class Login:IdentityUser
    {
        public string? username { get; set; }
        public string? password { get; set; }
    }
}
