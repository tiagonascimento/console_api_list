using Bank.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bank.Infra.repository
{
    internal class ItemConfiguration : IEntityTypeConfiguration<Item>
    {

        public void Configure(EntityTypeBuilder<Item> builder)
        {
            //nescessário mudar a chave pois o positionsID esta nulo
            builder.ToTable("positions");
            builder.HasKey(u => new { u.positionId, u.date });

            builder.Property(u => u.productId)
                   .HasColumnName("productid")
                   .IsRequired();

            builder.Property(u => u.positionId)
              .HasColumnName("positionid")
              .IsRequired();

            builder.Property(u => u.clientId)
                   .HasColumnName("clientid")
                   .IsRequired()
                   .HasMaxLength(255);

            
            builder.Property(u => u.date)
                   .HasColumnName("date")
                   .IsRequired();


            builder.Property(u => u.value)
                   .HasColumnName("value")
                   .IsRequired();
                   

            builder.Property(u => u.quantity)
                   .HasColumnName("quantity")
                   .IsRequired();
                  

        }

    }
}
