using Business.Interfaces;
using Business.Models;
using Business.Models.Validations;
using DevIO.Business.Models.Validations;

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
			if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)  || !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco)) return;

			if (_fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento).Result.Any())
			{
				Notificar("Já existe um fornecedor com este documento informado.");
				return;
			}

			await _fornecedorRepository.Adicionar(fornecedor);
		}

		public async Task Atualizar(Fornecedor fornecedor)
		{
			if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return;

			if (_fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id).Result.Any())
			{
				Notificar("Já existe um fornecedor com este documento informado.");
				return;
			}

			await _fornecedorRepository.Atualizar(fornecedor);
		}

		public async Task Remover(Guid id)
		{
			var fornecedor = await _fornecedorRepository.ObterFornecedorProdutosEndereco(id);

			if (fornecedor == null)
			{
				Notificar("Fornecedor não existe!");
					return;
			}

			if (fornecedor.Produtos.Any())
			{
				Notificar("O fornecedor possui produtos cadastrados!");
				return;
			}

			var endereco = await _fornecedorRepository.ObterEnderecoPorFornecedor(id);

			if (endereco != null)
			{ 
				await _fornecedorRepository.RemoverEnderecoFornecedor(endereco);
			}

			await _fornecedorRepository.Remover(id);
		}

		public void Dispose()
		{
			_fornecedorRepository?.Dispose();//Dê o dispose na instancia do Fornecedor Repository. Quando o garbage collector passar, vai tirar esse cara da memória
		}
	}
}
