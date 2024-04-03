using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
	public class Fornecedor : Entity
	{
		public string? Nome { get; set; }

		public string? Documento { get; set; }

		public TipoFornecedor TipoFornecedor { get; set; }

		public bool Ativo { get; set; }

		public Endereco? Endereco { get; set; }
	}
}
