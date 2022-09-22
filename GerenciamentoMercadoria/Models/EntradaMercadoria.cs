using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotSupply.Models
{
    public class EntradaMercadoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} Vazio")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "{0} Vazio"), DataType(DataType.DateTime)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "{0} Vazio"), Column(TypeName = "varchar"), MaxLength(50)]
        public string? Local { get; set; }

        [Required(ErrorMessage = "{0} Vazio")]
        public int MercadoriaId { get; set; }
        public Mercadoria? Mercadoria { get; set; }
    }
}
