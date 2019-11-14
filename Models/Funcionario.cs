using System.ComponentModel.DataAnnotations;

namespace Inter2.Models
{
    public class Funcionario : Pessoa
    {
        [Required(ErrorMessage="Campo Anos de Experiencia obrigatório")]
        [DataType(DataType.Currency)]
        public int AnosExperiencia { get; set; }
    }

}