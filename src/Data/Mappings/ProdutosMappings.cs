using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
	public class ProdutosMappings : IEntityTypeConfiguration<Produto>
	{
		//Mapeamento apenas dos campos, que realemnte é necessário definir alguma caracteristica, Decimal e DateTime não necessários nesse caso
		public void Configure(EntityTypeBuilder<Produto> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Nome)
				.IsRequired()
				.HasColumnType("varchar(200)");//se não colocar vai criar um campo com temanho n que é desnecessário

			builder.Property(p => p.Descricao)
				.IsRequired()
				.HasColumnType("varchar(1000)");

			builder.ToTable("Produtos");
		}
	}
}
