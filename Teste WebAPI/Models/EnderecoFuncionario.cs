using System.ComponentModel.DataAnnotations;

namespace Teste_WebAPI.Models
{
    public class EnderecoFuncionario
    {
        [Key]
        public int id { get; set; }

        public int idFuncionario { get; set; }

        public string cep { get; set; }

        public string rua { get; set; }

        public int numero { get; set; }

        public string bairro { get; set; }

        public string cidade { get; set; }

        public string estado { get; set; }

    }
}
