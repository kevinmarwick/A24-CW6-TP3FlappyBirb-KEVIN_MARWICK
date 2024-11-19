using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Flappy_birb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Flappy_birb.Data
{
    public class FlappyBirbContext : IdentityDbContext<User>
    {
        public FlappyBirbContext (DbContextOptions<FlappyBirbContext> options)
            : base(options)
        {
        }

        public DbSet<Flappy_birb.Models.Score> Score { get; set; } = default!;
    }
}
