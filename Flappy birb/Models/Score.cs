using System.ComponentModel;

namespace Flappy_Birb.Models
{
    public class Score
    {
        public int Id { get; set; }

        [DisplayName("Score")]
        public int Points { get; set; }

        public decimal Temps { get; set; }

        public DateOnly Date { get; set; }

        public bool IsVisible { get; set; }

        public virtual User User { get; set; }

    }
}
