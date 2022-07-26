
using System.ComponentModel.DataAnnotations;

namespace Teste_WebAPI.Models
{
    public class Funcionario
    {
        [Key]
        [Required]
        public int id { get; set; }

        public DateTime dataCriacao { get; set; }

        public DateTime dataAlteracao { get; set; }

        [Required]
        public string nome { get; set; }

        [Required]
        public string cpf { get; set; }

        public string rg { get; set; }

        [Required]
        public string cargo { get; set; }

        public EnderecoFuncionario endereco { get; set; }
    }
}
