using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
	public class FornecedoresMapping : IEntityTypeConfiguration<Fornecedor>
	{
		public void Configure(EntityTypeBuilder<Fornecedor> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Nome)
				.IsRequired()
				.HasColumnType("varchar(200)");

			builder.Property(p => p.Documento)
				.IsRequired()
				.HasColumnType("varchar(14)");

			//1 : 1 => Fornecedor : Endereco
			builder.HasOne(x => x.Endereco)
				.WithOne(e => e.Fornecedor);

			//1 : N => Fornecedor : Produtos
			builder.HasMany(p => p.Produtos)
				.WithOne(p => p.Fornecedor)
				.HasForeignKey(p => p.Fornecedor.Id);	

			builder.ToTable("Fornecedores");
		}
	}
}