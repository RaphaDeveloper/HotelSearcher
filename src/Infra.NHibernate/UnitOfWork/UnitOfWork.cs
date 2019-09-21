using NHibernate;
using System;
using System.Threading.Tasks;

namespace Infra.NHibernate.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		private readonly ISession session;
		private ITransaction transaction;

		public UnitOfWork(ISession session)
		{
			this.session = session;
		}

		public void BeginTransaction()
		{
			transaction = session.BeginTransaction();
		}

		public async Task Commit()
		{
			await transaction.CommitAsync();
		}

		public async Task Rollback()
		{
			await transaction.RollbackAsync();
		}

		public void Dispose()
		{
			transaction.Dispose();
			transaction = null;
		}
	}
}
