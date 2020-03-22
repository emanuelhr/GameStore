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
    public class CartsGamesEntityConfig : IEntityTypeConfiguration<CartsGamesEntity>
    {
        public void Configure(EntityTypeBuilder<CartsGamesEntity> builder)
        {
            builder.HasKey(p => new { p.CartEntityId, p.GameEntityId });
            builder.HasOne(p => p.CartEntity)
                .WithMany(g => g.CartsGames)
                .HasForeignKey(g => g.GameEntityId);
            builder.HasOne(g => g.GameEntity)
                .WithMany(p => p.CartsGames)
                .HasForeignKey(p => p.CartEntityId);
        }
    }
}
