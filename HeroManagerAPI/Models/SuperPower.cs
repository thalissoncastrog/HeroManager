using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeroManagerAPI.Models
{
    [Table("SuperPowers")]
    public class SuperPower
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Superpower { get; set; }

        [Required]
        [MaxLength(250)]
        public string? Description { get; set; }

        public ICollection<HeroSuperPowers> HeroSuperPowers { get; set; } = [];
    }
}
