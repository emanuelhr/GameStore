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
    public class GameEntityConfig : IEntityTypeConfiguration<GameEntity>
    {



        public void Configure(EntityTypeBuilder<GameEntity> builder)
        {
            //builder
            //     .Property(p => p.Name)
            //     .HasColumnType("varchar")
            //     .HasMaxLength(20)
            //     .IsRequired();
            //builder
            //        .Property(p => p.Price)
            //        .HasColumnType("smallmoney")
            //        .IsRequired();
            builder
                    .HasOne(p => p.Developer)
                    .WithMany(p => p.Games)
                    .HasForeignKey(p => p.DeveloperId)
                    .IsRequired();
        }
    }
}
