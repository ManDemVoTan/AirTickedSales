using AirTickedSales.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AirTickedSales.Data.Configurations
{
    public class CompanyInfoConfiguration : IEntityTypeConfiguration<CompanyInfo>
    {
        public void Configure(EntityTypeBuilder<CompanyInfo> builder)
        {
            builder.ToTable("CompanyInfo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CompanyCode).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CompanyName).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.ShortName).IsRequired().HasMaxLength(500);
        }
    }
}
