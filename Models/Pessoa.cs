using System.ComponentModel.DataAnnotations;

namespace Inter2.Models
{
    public class Pessoa
    {
        public int? Id { get; set; }

        [Display(Name="Nome")]
        [Required(ErrorMessage="Campo nome obrigatório")]
        [MinLength(1)]
        public string Nome { get; set; }

        [Required(ErrorMessage="Campo email obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage="Campo cpf obrigatório")]
        public string Cpf { get; set; }
    }
}