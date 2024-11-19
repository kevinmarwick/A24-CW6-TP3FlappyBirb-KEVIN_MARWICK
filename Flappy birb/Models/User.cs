using Microsoft.AspNetCore.Identity;

namespace Flappy_birb.Models
{
    public class User:IdentityUser
    {
        public virtual IList<Score> Scores { get; set; } = null!;
    }
}
