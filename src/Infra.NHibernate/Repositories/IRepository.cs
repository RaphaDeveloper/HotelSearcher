using System.Linq;
using System.Threading.Tasks;

namespace Infra.NHibernate.Repositories
{
	public interface IRepository<TEntity> where TEntity : class
	{
		IQueryable<TEntity> GetAll();
		Task Save(TEntity entity);
		Task Delete(TEntity entity);
	}
}
