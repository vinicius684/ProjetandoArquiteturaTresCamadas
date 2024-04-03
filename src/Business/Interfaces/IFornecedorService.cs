using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
	public interface IFornecedorService : IDisposable //IDisposable - liberar recursos não gerenciado
	{
		Task Adicionar(Fornecedor fornecedor);
		Task Atualizar(Fornecedor fornecedor);
		Task Remover(Guid id);
	}
}
