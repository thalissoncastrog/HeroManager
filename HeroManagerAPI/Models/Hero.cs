using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeroManagerAPI.Models
{
    [Table("Heroes")]
    public class Hero
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string Name { get; set; }

        [Required]
        [MaxLength(120)]
        public string HeroName { get; set; }

        [Required]
        public DateTime? BirthDate { get; set; }

        [Required]
        public float Height { get; set; }

        [Required]
        public float Weight { get; set; }

        public ICollection<HeroSuperPower> HeroSuperPowers { get; set; }

    }
}
