using System.ComponentModel.DataAnnotations;

namespace Api.Db.Models.Entities
{
    public class Promocao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Regra { get; set; }
    }
}