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
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string HeroName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public float Height { get; set; }

        public ICollection<HeroSuperPowers> HeroSuperPowers { get; set; }

    }
}
