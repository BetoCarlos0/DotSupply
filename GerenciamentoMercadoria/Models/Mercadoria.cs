using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoMercadoria.Models
{
    public class Mercadoria
    {
        public int MercadoriaId { get; set; }

        [Required(ErrorMessage = "{0} Vazio"), Column(TypeName = "varchar"), MaxLength(100)]
        public string ?Nome { get; set; }

        [Required(ErrorMessage = "{0} Vazio"), RegularExpression("^[0-9]*$"), Display(Name = "N° de Registro")]
        public int NumRegistro { get; set; }

        [Required(ErrorMessage = "{0} Vazio"), Column(TypeName = "varchar"), MaxLength(50)]
        public string ?Fabricante { get; set; }

        [Required(ErrorMessage = "{0} Vazio"), Column(TypeName = "varchar"), MaxLength(50)]
        public string ?Tipo { get; set; }

        [Required(ErrorMessage = "{0} Vazio"), Display(Name = "Descrição"), Column(TypeName = "varchar"), MaxLength(200)]
        public string ?Descricao { get; set; }
    }
}
