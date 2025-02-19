using Microsoft.AspNetCore.Identity;

namespace ProjektZaliczeniowyASP.NET.Models
{
    public class UserModel : IdentityUser
    {
        public string FullName { get; set; }
    }
}
