using Business.Models;


namespace Business.Interfaces
{
	public interface IProdutoRepository: IRepository<Produto>
	{
		Task<IEnumerable<Produto>> ObterProdutosPorForneedor(Guid forncedorid);

		Task<IEnumerable<Produto>> ObterProdutosFornecedores();

		Task<Produto> ObterProdutoFornecedor(Guid id);
	}
}
