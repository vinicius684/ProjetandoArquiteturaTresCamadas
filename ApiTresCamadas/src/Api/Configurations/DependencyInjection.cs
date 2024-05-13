using Business.Interfaces;
using Data.Context;
using Data.Repository;
using Business.Services;
using Business.Notificacoes;
using Data.UoW;

namespace Api.Configurations
{
	public static class DependencyInjection//classe de extensão, por isso o static
	{
		public static IServiceCollection ResolveDependencies(this IServiceCollection services) 
		{
			//scoped mais utilizado em app web, a instancia dura durante o request
			//Data
			services.AddScoped<MeuDbContext>();//já está sendo resolvido na program
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IProdutoRepository, ProdutoRepository>();
			services.AddScoped<IFornecedorRepository, FornecedorRepository>();

			//Business
			services.AddScoped<IFornecedorService, FornecedorService>();
			services.AddScoped<IProdutoService, ProdutoService>();
			services.AddScoped<INotificador, Notificador>();

			return services;
		}
	}
}
