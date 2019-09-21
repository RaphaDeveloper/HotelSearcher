using Infra.NHibernate.Context;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.NHibernate.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		private readonly IContext context;

		public Repository(IContext context)
		{
			this.context = context;
		}

		public IQueryable<TEntity> GetAll()
		{
			return context.Session.Query<TEntity>();
		}

		public async Task Delete(TEntity entity)
		{
			await context.Session.DeleteAsync(entity);
		}

		public async Task Save(TEntity entity)
		{
			await context.Session.SaveOrUpdateAsync(entity);
		}
	}
}
