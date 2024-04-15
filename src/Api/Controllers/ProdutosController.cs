using Api.Controllers;
using Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/produtos")]
	public class ProdutosController : MainController
	{
		public ProdutosController()
		{
		}

		[HttpGet]
		public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
		{

		}

		[HttpGet("{id:guid}")]
		public async Task<ActionResult<ProdutoViewModel>> ObterPorId(Guid id)
		{

		}

		[HttpPost]
		public async Task<ActionResult<ProdutoViewModel>> Adicionar(ProdutoViewModel produtoViewModel)
		{

		}

		[HttpPut("{id:guid}")]
		public async Task<IActionResult> Atualizar(Guid id, ProdutoViewModel produtoViewModel)
		{

		}

		[HttpDelete("{id:guid}")]
		public async Task<ActionResult<ProdutoViewModel>> Excluir(Guid id)
		{

		}
	}
}