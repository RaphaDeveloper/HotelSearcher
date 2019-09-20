using System.Threading.Tasks;

namespace Infra.NHibernate.UnitOfWork
{
	public interface IUnitOfWork
	{
		void BeginTransaction();
		Task Commit();
		Task Rollback();
		void CloseTransaction();
	}
}
