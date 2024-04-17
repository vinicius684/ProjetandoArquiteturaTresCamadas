using Api.Controllers;
using Api.ViewModels;
using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;


namespace DevIO.Api.Controllers
{
    [Route("api/fornecedores")]
    public class FornecedoresController : MainController
    {
		private readonly IMapper _mapper;
		private readonly IFornecedorRepository _fornecedorRepository;
		private readonly IFornecedorService _fornecedorService;

		public FornecedoresController(IMapper mapper,
									  IFornecedorRepository fornecedorRepository,
									  IFornecedorService fornecedorService)
		{
			_mapper = mapper;
			_fornecedorRepository = fornecedorRepository;
			_fornecedorService = fornecedorService;
		}

		[HttpGet]
		public async Task<IEnumerable<FornecedorViewModel>> ObterTodos()
		{
			return _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
		}

		[HttpGet("{id:guid}")]
		public async Task<ActionResult<FornecedorViewModel>> ObterPorId(Guid id)
		{
			var fornecedor = await ObterFornecedorProdutosEndereco(id);

			if (fornecedor == null) return NotFound();

			return fornecedor;
		}

		[HttpPost]
		public async Task<ActionResult<FornecedorViewModel>> Adicionar(FornecedorViewModel fornecedorViewModel)
		{
			if (!ModelState.IsValid) return CustomResponse(ModelState);

			await _fornecedorService.Adicionar(_mapper.Map<Fornecedor>(fornecedorViewModel));

			return CustomResponse(fornecedorViewModel);
		}

		[HttpPut("{id:guid}")]
		public async Task<ActionResult<FornecedorViewModel>> Atualizar(Guid id, FornecedorViewModel fornecedorViewModel)
		{
			if (id != fornecedorViewModel.Id)
			{
				NotificarErro("O id informado não é o mesmo que foi passado na query");
				return CustomResponse();
			}

			if (!ModelState.IsValid) return CustomResponse(ModelState);

			await _fornecedorService.Atualizar(_mapper.Map<Fornecedor>(fornecedorViewModel));

			return CustomResponse();
		}

		[HttpDelete("{id:guid}")]
		public async Task<ActionResult<FornecedorViewModel>> Excluir(Guid id)
		{
			await _fornecedorService.Remover(id);

			return CustomResponse();
		}

		private async Task<FornecedorViewModel> ObterFornecedorProdutosEndereco(Guid id)
		{
			return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorProdutosEndereco(id));
		}
	}
}