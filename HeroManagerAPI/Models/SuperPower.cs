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
        public required string SuperpowerName { get; set; }

        [Required]
        [MaxLength(250)]
        public string? Description { get; set; }

        public ICollection<HeroSuperPower> HeroSuperPowers { get; set; }

        public static List<SuperPower> CreateInitialOptions()
        {
            return new List<SuperPower>
        {
            new SuperPower { Id = 1, SuperpowerName = "Voo", Description = "Habilidade de voar." },                              
            new SuperPower { Id = 2, SuperpowerName = "Força sobre-humana", Description = "Força muito além dos limites humanos." },
            new SuperPower { Id = 3, SuperpowerName = "Hiper velocidade", Description = "Capacidade de se mover em velocidades extremas." },
            new SuperPower { Id = 4, SuperpowerName = "Telepatia", Description = "Capacidade de ler mentes e se comunicar mentalmente." },
            new SuperPower { Id = 5, SuperpowerName = "Invisibilidade", Description = "Capacidade de se tornar invisível aos olhos." },
            new SuperPower { Id = 6, SuperpowerName = "Manipulação do tempo", Description = "Controle sobre o fluxo do tempo." },
            new SuperPower { Id = 7, SuperpowerName = "Controle elemental", Description = "Domínio sobre os elementos naturais: água, fogo, terra, ar." },
            new SuperPower { Id = 8, SuperpowerName = "Telecinese", Description = "Habilidade de mover objetos com a mente." },
            new SuperPower { Id = 9, SuperpowerName = "Transformação de forma", Description = "Capacidade de alterar a aparência física." },
            new SuperPower { Id = 10, SuperpowerName = "Geração de campo de força", Description = "Criação de uma barreira de proteção invisível." },
            new SuperPower { Id = 11, SuperpowerName = "Cura acelerada", Description = "Capacidade de se curar rapidamente de ferimentos." },
            new SuperPower { Id = 12, SuperpowerName = "Viagem interdimensional", Description = "Deslocamento entre diferentes dimensões." }

        };
        }

        
    }
}
