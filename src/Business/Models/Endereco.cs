

namespace Business.Models
{
	public class Endereco : Entity
	{
		public string? Logradouro { get; set; }

		public string? Numero { get; set; }

		public string? Complemento { get; set; }

		public string? Cep { get; set; }

		public string? Bairro { get; set; }

		public string? Cidade { get; set; }

		public string? Estado { get; set; }


		/*EF Relation - Dizer no mappinga que Fornecedor tem 1 Endereco e Endereco tem 1 Fornecedor*/ 
		public Fornecedor Fornecedor { get; set; }
	}
}