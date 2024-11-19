using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Flappy_Birb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Flappy_Birb.Data
{
    public class FlappyBirbContext : IdentityDbContext<User>
    {
        public FlappyBirbContext (DbContextOptions<FlappyBirbContext> options)
            : base(options)
        {
        }

        public DbSet<Flappy_Birb.Models.Score> Score { get; set; } = default!;
    }
}
