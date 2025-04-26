using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repositories.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    private const string IntDatabaseType = "INT";
    private const string DateTimeDatabaseType = "DATETIME";
    private const string VarcharDatabaseType = "VARCHAR";
    
    public void Configure(EntityTypeBuilder<Book> entity)
    {
        entity.ToTable("BookTable");
        entity.HasKey(property => property.Id);
        entity.Property(propertyName => propertyName.Id).HasColumnType(IntDatabaseType).ValueGeneratedNever().UseIdentityColumn();;
        entity.Property(propertyName => propertyName.CreationDate).HasColumnName("CreationDate").HasColumnType(DateTimeDatabaseType).IsRequired();
				
        entity.Property(propertyName => propertyName.Name).HasColumnType($"{VarcharDatabaseType}(100)").IsRequired();
        entity.Property(propertyName => propertyName.Publisher).HasColumnType($"{VarcharDatabaseType}(100)").IsRequired();
    }
}