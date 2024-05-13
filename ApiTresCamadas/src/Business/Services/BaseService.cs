using Business.Interfaces;
using Business.Models;
using Business.Notificacoes;
using FluentValidation;
using FluentValidation.Results;


namespace Business.Services
{
	public class BaseService
	{
		private readonly INotificador _notificador;
		private readonly IUnitOfWork _uow;

		public BaseService(INotificador notificador, IUnitOfWork uow)
		{ 
			_notificador = notificador;
			_uow = uow;
		}

		protected void Notificar(ValidationResult validationResult)//transformar minhas mensagens de validação (ValidationResult do fluentValidation) em Notificacao (texto0
		{
			foreach (var item in validationResult.Errors)
			{
				Notificar(item.ErrorMessage);
			}
		}

		protected void Notificar(string mensagem)
		{
			_notificador.Handle(new Notificacao(mensagem));
		}

		protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity  //classe validação e classe entidade
		{
			var validator = validacao.Validate(entidade);//validate vem do AbstractValidator

			if (validator.IsValid)
				return true;

			Notificar(validator);//passando

			return false;
		}

		protected async Task<bool> Commit()
		{
			if (await _uow.Commit()) return true;

			Notificar("Não foi possível salvar os dados no banco!");
			return false;
		}

	}
}
