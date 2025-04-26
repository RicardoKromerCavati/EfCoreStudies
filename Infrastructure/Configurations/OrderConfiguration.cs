using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    private const string IntDatabaseType = "INT";
    private const string DateTimeDatabaseType = "DATETIME";
    
    public void Configure(EntityTypeBuilder<Order> entity)
    {
        entity.ToTable("OrderTable");
        entity.HasKey(property => property.Id);
        entity.Property(propertyName => propertyName.Id).HasColumnType(IntDatabaseType).ValueGeneratedNever().UseIdentityColumn();;
        entity.Property(propertyName => propertyName.CreationDate).HasColumnName("CreationDate").HasColumnType(DateTimeDatabaseType).IsRequired();

        //Fk for other tables
        entity.Property(propertyName => propertyName.CustomerId).HasColumnType(IntDatabaseType).IsRequired();
        entity.Property(propertyName => propertyName.BookId).HasColumnType(IntDatabaseType).IsRequired();
				
        entity
            .HasOne(propertyName => propertyName.Customer)
            .WithMany(c => c.Orders)
            .HasPrincipalKey(customer => customer.Id)
            //.HasConstraintName("example")
            ;
				
        entity
            .HasOne(propertyName => propertyName.Book)
            .WithMany(b => b.Orders)
            .HasPrincipalKey(book => book.Id);    
    }
    
}