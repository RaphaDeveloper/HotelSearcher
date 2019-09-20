using Domain;
using NHibernate;
using System.Linq;

namespace Infra.NHibernate.Context
{
	public class Context : IContext
	{
		public ISession Session { get; }

		public Context(ISession session)
		{
			this.Session = session;
		}

		public IQueryable<Hotel> Hotels => Session.Query<Hotel>();
	}
}
