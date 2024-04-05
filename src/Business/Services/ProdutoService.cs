using Business.Interfaces;
using Business.Models;
using Business.Models.Validations;

namespace Business.Services
{
	internal class ProdutoService : BaseService, IProdutoService
	{
		private readonly IProdutoRepository _produtoRepository;

		public ProdutoService(IProdutoRepository produtoRepository, INotificador notificador) : base(notificador)
		{
			_produtoRepository = produtoRepository;
		}

		public async Task Adicionar(Produto produto)
		{
			if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

			await _produtoRepository.Adicionar(produto);
		}

		public async Task Atualizar(Produto produto)
		{
			if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

			await _produtoRepository.Atualizar(produto);
		}

		public async Task Remover(Guid id)
		{
			await _produtoRepository.Remover(id);
		}

		public void Dispose()
		{
			_produtoRepository?.Dispose();//Dê o dispose na instancia do Fornecedor Repository. Quando o garbage collector passar, vai tirar esse cara da memória
		}
	}
}
