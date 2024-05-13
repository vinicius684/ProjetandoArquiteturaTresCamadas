using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
	public interface IRepository<TEntity> : IDisposable where TEntity : Entity //Tem que ser a classe Entity ou qualquer uma que herde dela
	{
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> ObterPorId(Guid id);

		Task<List<TEntity>> ObterTodos();

        void Adicionar(TEntity entity);

        void Atualizar(TEntity entity);

		void Remover(Guid id);

		Task<int> SaveChanges();//int é o número de linhas afetadas naquele commit
	}
}
