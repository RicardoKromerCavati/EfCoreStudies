using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repositories.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    private const string IntDatabaseType = "INT";
    private const string DateTimeDatabaseType = "DATETIME";
    private const string VarcharDatabaseType = "VARCHAR";
    
    public void Configure(EntityTypeBuilder<Customer> entity)
    {
        entity.ToTable("CustomerTable");
        entity.HasKey(property => property.Id);
				
        entity.Property(propertyName => propertyName.Id).HasColumnType(IntDatabaseType).UseIdentityColumn();;
        //entity.Property(propertyName => propertyName.Id).ValueGeneratedOnAdd();
        entity.Property(propertyName => propertyName.CreationDate).HasColumnName("CreationDate").HasColumnType(DateTimeDatabaseType).IsRequired();
        entity.Property(propertyName => propertyName.Name).HasColumnType($"{VarcharDatabaseType}(100)").IsRequired();
        entity.Property(propertyName => propertyName.BirthDate).HasColumnType(DateTimeDatabaseType);
        entity.Property(propertyName => propertyName.Cpf).HasColumnType($"{VarcharDatabaseType}(11)").IsRequired();
    }
}