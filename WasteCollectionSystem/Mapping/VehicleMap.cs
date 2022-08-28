using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using WasteCollectionSystem.Models;

namespace BootcampWasteCollectionSystem.Mapping
{
    public class VehicleMap : ClassMapping<Vehicle>
    {
        public VehicleMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int64);
                x.Column("id");
                x.Generator(Generators.Increment);
            });

            Property(b => b.VehicleName, x =>
            {
                x.Length(50);
                x.Column("vehiclename");
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Property(b => b.VehiclePlate, x =>
            {
                x.Length(14);
                x.Column("vehicleplate");
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Table("vehicles");
        }

    }
}