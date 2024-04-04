using Business.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
	public class BaseService
	{
		protected void Notificar(string mensagem)
		{ 
			
		}

		protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity  //classe validação e classe entidade
		{
			var validator = validacao.Validate(entidade);//validate vem do AbstractValidator

			if (validator.IsValid)
				return true;

			//lancamento de notificações

			return false;
		}

	}
}
