using Microsoft.AspNetCore.Identity;
using System.Security.Principal;

namespace Flappy_Birb.Models
{
    public class User : IdentityUser
    {
        public virtual IList<Score> Scores { get; set; } = null!;
    }
}
