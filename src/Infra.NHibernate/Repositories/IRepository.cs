using System.Threading.Tasks;

namespace Infra.NHibernate.Repositories
{
	public interface IRepository<TEntity> where TEntity : class
	{
		Task Save(TEntity entity);
		Task Delete(TEntity entity);
	}
}
