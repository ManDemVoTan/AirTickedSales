using AirTickedSales.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirTickedSales.Data.Configurations
{
    public class TimeKeepingConfigurations : IEntityTypeConfiguration<TimeKeeping>
    {
        public void Configure(EntityTypeBuilder<TimeKeeping> builder)
        {
            builder.ToTable("TimeKeeping");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasOne(x => x.AppUser).WithMany(x => x.TimeKeeping).HasForeignKey(x => x.UserId);
        }
    }
}
