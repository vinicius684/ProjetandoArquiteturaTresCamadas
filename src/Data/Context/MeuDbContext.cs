using Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
	public class MeuDbContext : DbContext
	{
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options) 
        {
            //algumas confis
        }

		//Entidades Assembly meu DB Context
        public DbSet<Produto> Produtos { get; set; }
		public DbSet<Endereco> Enderecos { get; set; }
		public DbSet<Fornecedor> Fornecedores { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)//Config Ef core/ config para mapeamentos
		{
			//pegar cada propriedade dentro das minhas entidades, onde essa propriedade for do tipo string, setar para varchar(100) - Antes do mapeamento, ent para entidades que não estejam lá, para evitar o varchar n
			foreach (var property in modelBuilder.Model.GetEntityTypes()
				.SelectMany(e => e.GetProperties()
					.Where(p => p.ClrType == typeof(string))))
				property.SetColumnType("varchar(100)");

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);//Toda vez que eu incializar esse projeto, uma vez só na inicialização, vou pegar todos os tipos que implementam o IEntityTypeConfiguration<> (Mapings) para todas as entidades que estão dentro do Assembly MeuDbCoontext

			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;//varrer relacionamentos do tipo chave estrangeira, o que achar, setar esse comportamento para 'ClientSetNull'. Fazendo isso impede que ao deletar um fornecedor eu delete todos os produtos relacionados, Deleção em cascade.

			base.OnModelCreating(modelBuilder);//aproveitando lógica da classe base
		}
	}
}
