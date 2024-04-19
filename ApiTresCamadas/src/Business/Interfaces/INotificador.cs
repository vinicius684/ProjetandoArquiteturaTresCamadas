

using Business.Notificacoes;

namespace Business.Interfaces
{
	public interface INotificador
	{
		bool TemNotificacao();

		List<Notificacao> ObterNotificacoes();

		void Handle(Notificacao notificacao); //manipular a notificacao, fazer alguma coisa para que a notificação seja guardada de algum jeito que ela chegue do outro lado
	}
}
