using WasteCollectionSystem.Models;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;


namespace BootcampWasteCollectionSystem.Mapping
{
    public class ContainerMap : ClassMapping<Container>
    {
        public ContainerMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int64);
                x.Column("id");
                x.Generator(Generators.Increment);
            });

            Property(b => b.ContainerName, x =>
            {
                x.Length(50);
                x.Column("containername");
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Property(b => b.Latitude, x =>
            {
                x.Length(10);
                x.Column("latitude");
                x.Type(NHibernateUtil.Double);
                x.NotNullable(true);
            });
            Property(b => b.Longitude, x =>
            {
                x.Length(10);
                x.Column("longitude");
                x.Type(NHibernateUtil.Double);
                x.NotNullable(true);
            });

            Property(b => b.VehicleId, x =>
            {
                x.Column("vehicleid");
                x.Type(NHibernateUtil.Int64);
                x.NotNullable(true);
            });

            Table("containers");
        }
    }
}