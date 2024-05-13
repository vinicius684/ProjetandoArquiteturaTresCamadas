using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
	public interface IFornecedorRepository: IRepository<Fornecedor>
	{
		Task<Fornecedor> ObterFornecedorEndereco(Guid id);

		Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);

		Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);

		void RemoverEnderecoFornecedor(Endereco endereco);
	}
}
