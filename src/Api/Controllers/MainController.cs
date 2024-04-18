using Business.Interfaces;
using Business.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace Api.Controllers
{
	[ApiController]
	public abstract class MainController : ControllerBase
	{
		private readonly INotificador _notificador;

		protected MainController(INotificador notificador)
		{ 
			_notificador = notificador;
		}

		protected bool OperacaoValida() 
		{
			//return true;
			return !_notificador.TemNotificacao();
		}

		protected ActionResult CustomResponse(HttpStatusCode statusCode = HttpStatusCode.OK, Object result = null)//se não for passado nenhum objeto vai usar o valor padrão null
		{
			if (OperacaoValida())
			{
				return new ObjectResult(result)
				{
					StatusCode = Convert.ToInt32(statusCode),
				};
			}

			return BadRequest(new
			{
				errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
			});
		}

		protected ActionResult CustomResponse(ModelStateDictionary modelState) 
		{
			if (!modelState.IsValid) NotificarErrorModelInvalida(modelState);
			return CustomResponse();
		}

		protected void NotificarErrorModelInvalida(ModelStateDictionary modelState)
		{
			var erros = modelState.Values.SelectMany(e => e.Errors);
			foreach(var erro in erros)
				{ 
				var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
				NotificarErro(errorMsg);
			}
		}

		protected void NotificarErro(string mensagem)
		{
			_notificador.Handle(new Notificacao(mensagem));
		}

	}
}
