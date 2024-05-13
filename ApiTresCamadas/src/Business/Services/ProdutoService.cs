using Business.Interfaces;
using Business.Models;
using Business.Models.Validations;
using Business.Notificacoes;

namespace Business.Services
{
	public class ProdutoService : BaseService, IProdutoService
	{
		private readonly IProdutoRepository _produtoRepository;

		public ProdutoService(IProdutoRepository produtoRepository, INotificador notificador, IUnitOfWork uow) : base(notificador, uow)
        {
			_produtoRepository = produtoRepository;
		}

		public async Task Adicionar(Produto produto)
		{
			if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

		   _produtoRepository.Adicionar(produto);

            await Commit();
        }

		public async Task Atualizar(Produto produto)
		{
			if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

			var produtoExistente = _produtoRepository.ObterPorId(produto.Id);

			if (produtoExistente != null)
			{
				Notificar("Já existe um produto com ID informado!");
				return;
			}

			 _produtoRepository.Atualizar(produto);
            await Commit();
        }

		public async Task Remover(Guid id)
		{
			 _produtoRepository.Remover(id);
            await Commit();
        }

		public void Dispose()
		{
			_produtoRepository?.Dispose();//Dê o dispose na instancia do Fornecedor Repository. Quando o garbage collector passar, vai tirar esse cara da memória
		}
	}
}
