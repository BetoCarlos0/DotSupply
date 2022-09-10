using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoMercadoria.Models
{
    public class EntradaSaidaMercadoria
    {
        public int Id { get; set; }

        [Required, NotMapped, Column(TypeName = "varchar"), MaxLength(10)]
        public string InfoCadastro { get; set; }

        [Required(ErrorMessage = "{0} Vazio")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "{0} Vazio"), DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "{0} Vazio"), Column(TypeName = "varchar"), MaxLength(50)]
        public string Local { get; set; }
        public IEnumerable<Mercadoria> ? Mercadorias { get; set; }
    }
}
