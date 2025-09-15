using System.ComponentModel.DataAnnotations;

namespace Api.Db.Models.Entities
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Sku { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        public decimal PrecoBase { get; set; }

        public bool Ativo { get; set; }

        public int EstoqueAtual { get; set; }
    }
}