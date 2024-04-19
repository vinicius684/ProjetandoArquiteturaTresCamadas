using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
	public interface IProdutoService : IDisposable
	{
		Task Adicionar(Produto fornecedor);
		Task Atualizar(Produto fornecedor);
		Task Remover(Guid id);
	}
}
