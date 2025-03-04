using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.SenderCity)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(o => o.SenderAddress)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(o => o.RecipientCity)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(o => o.RecipientAddress)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(o => o.CargoWeight)
                .IsRequired();

            builder.Property(o => o.PickupDate)
                .IsRequired();

            builder.Property(o => o.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
