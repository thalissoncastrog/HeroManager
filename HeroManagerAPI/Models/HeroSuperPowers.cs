using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeroManagerAPI.Models
{
    [Table("HeroesSuperPowers")]
    public class HeroSuperPowers
    {
        [Key]
        public int HeroId { get; set; }
        public Hero Hero { get; set; }

        [Key]
        public int SuperPowerId { get; set; }
        public SuperPower SuperPower { get; set; }

    }
}
