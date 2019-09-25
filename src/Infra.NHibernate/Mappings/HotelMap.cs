using Domain;
using Domain.Hotels.Entities;
using NHibernate.Mapping.ByCode;
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

			//Map(hotel => hotel.PriceByCostumerType, collection =>
			//{
			//	collection.Cascade(Cascade.All);
			//	collection.Inverse(true);
			//}, key =>
			//{
			//	key.Element(element =>
			//	{
			//		element.Column("CostumerType");
			//		element.Length(10);
			//		element.Type<CostumerType>();
			//	});
			//}, relation =>
			//{
			//	relation.OneToMany();
			//});
		}
	}
}
