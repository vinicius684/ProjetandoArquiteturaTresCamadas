using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection.Metadata.Ecma335;

namespace Api.Controllers
{
	[ApiController]
	public abstract class MainController : ControllerBase
	{
		protected bool OperacaoValida() 
		{
			return true;
		}

		protected ActionResult CustomResponse(Object result = null)//se não for passado nenhum objeto vai usar o valor padrão null
		{
			if (OperacaoValida())
			{
				return new ObjectResult(result);
			}

			return BadRequest(new
			{
				//errors
			});
		}

		protected ActionResult CustomResponse(ModelStateDictionary modelState) 
		{
			if (!modelState.IsValid) { }//notificar erros
			return CustomResponse();
		}

		protected void NotificarErro(string mensagem)
		{ 
			
		}

	}
}
