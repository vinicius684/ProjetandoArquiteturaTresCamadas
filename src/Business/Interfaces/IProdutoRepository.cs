using Business.Models;


namespace Business.Interfaces
{
	public interface IProdutoRepository: IRepository<Produto>
	{
		Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid forncedorid);

		Task<IEnumerable<Produto>> ObterProdutosFornecedores();

		Task<Produto> ObterProdutoFornecedor(Guid id);
	}
}
