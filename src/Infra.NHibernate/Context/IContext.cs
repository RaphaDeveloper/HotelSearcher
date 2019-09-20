using Domain;
using NHibernate;
using System.Linq;

namespace Infra.NHibernate.Context
{
	public interface IContext
	{
		ISession Session { get; }

		IQueryable<Hotel> Hotels { get; }
	}
}
