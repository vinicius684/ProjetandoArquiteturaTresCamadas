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

        public DbSet<Produto> Produtos { get; set; }
		public DbSet<Endereco> Enderecos { get; set; }
		public DbSet<Fornecedor> Fornecedores { get; set; }

	}
}
