using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityTypeConfigurations
{
    public class TicketEntityTypeConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
           builder.HasKey(t => t.Id);
            builder.Property(t => t.PhoneNumber).HasColumnType("NVARCHAR").HasMaxLength(20);
            builder.Property(t => t.District).HasColumnType("NVARCHAR").HasMaxLength(100);
            builder.Property(t => t.Governorate).HasColumnType("NVARCHAR").HasMaxLength(100);
            builder.Property(t => t.City).HasColumnType("NVARCHAR").HasMaxLength(100);
            
        }
    }
}
