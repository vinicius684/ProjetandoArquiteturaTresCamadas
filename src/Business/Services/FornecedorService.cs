using Business.Interfaces;
using Business.Models;

namespace Business.Services
{
	internal class FornecedorService : BaseService, IFornecedorService
	{
		private readonly IFornecedorRepository _fornecedorRepository;

		public FornecedorService(IFornecedorRepository forncedorRepository)
		{
			_fornecedorRepository = forncedorRepository;
		}

		public async Task Adicionar(Fornecedor fornecedor)
		{
			//validar se a entidade é consistente...

			//validar se ja nao existe outro fornecedor com o mesmo doc

			await _fornecedorRepository.Adicionar(fornecedor);
		}

		public async Task Atualizar(Fornecedor fornecedor)
		{
			await _fornecedorRepository.Atualizar(fornecedor);
		}

		public async Task Remover(Guid id)
		{
			await _fornecedorRepository.Remover(id);
		}

		public void Dispose()
		{
			_fornecedorRepository?.Dispose();//Dê o dispose na instancia do Fornecedor Repository. Quando o garbage collector passar, vai tirar esse cara da memória
		}
	}
}
