using Domain;
using NHibernate.Mapping.ByCode.Conformist;

namespace Infra.NHibernate.Mappings
{
	public class HotelMap : ClassMapping<Hotel>
	{
		public HotelMap()
		{
			Id(h => h.Id);
			Property(h => h.Name);
			Property(h => h.Rating);
			Map(h => h.PriceByCostumerType, 
				mapEntity => 
				{
					mapEntity.Key(k => k.PropertyRef(h => h.Id));
					mapEntity.Table("HotelPriceByCustomerType");
				}, 
				mapKey => mapKey.Element(k => k.Column("CostumerType")),
				mapValue => mapValue.OneToMany());
		}
	}
}
