using System.ComponentModel.DataAnnotations;

namespace Inter2.Models
{
    public class Produto {
        public int? Id { get; set; }
        [Display(Name="Nome")]
        [Required(ErrorMessage="Campo nome obrigatório")]
        [MinLength(3)]
        public string Nome { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public int QuantidadeEstoque { get; set; }
    }
}