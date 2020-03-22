using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.EntityConfigurations
{
    public class DeveloperEntityConfig : IEntityTypeConfiguration<DeveloperEntity>
    {
        public void Configure(EntityTypeBuilder<DeveloperEntity> builder)
        {
            builder.Property(d => d.Headquarters)
                
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(d => d.Name)
                
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
