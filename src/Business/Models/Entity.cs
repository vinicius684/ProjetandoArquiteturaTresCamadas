
namespace Business.Models
{
	public abstract class Entity //abstract, classe que só pode ser herdada
	{
		protected Entity()//protected, somente quem herdar poderá fazer o uso desse construtor
		{ 			
			Id = Guid.NewGuid();
		}

		public Guid Id { get; set; }
	}
}
