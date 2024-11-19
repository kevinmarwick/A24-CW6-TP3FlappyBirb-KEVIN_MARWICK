using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Flappy_birb.Models
{
    public class Score
    {
        public int Id { get; set; }

        [DisplayName("Score")]
        public int Points { get; set; }

        public decimal Temps { get; set; }

        public DateOnly  Date { get; set; }

        public bool EstVisible { get; set; }

        public string Pseudo { get; set; }

        public virtual User User { get; set; }
    }
}
