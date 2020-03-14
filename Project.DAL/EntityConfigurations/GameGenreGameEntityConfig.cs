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
    public class GameGenreGameEntityConfig : IEntityTypeConfiguration<GameGenreGameEntity>
    {
        public void Configure(EntityTypeBuilder<GameGenreGameEntity> builder)
        {
            builder.HasKey(p => new { p.GameEntityId, p.GameGenreEntityId });
            builder.HasOne(p => p.GameEntity)
                .WithMany(g=>g.GameGenre)
                .HasForeignKey(g=>g.GameEntityId);
            builder.HasOne(g => g.GameGenreEntity)
                .WithMany(p => p.GameGenre)
                .HasForeignKey(p => p.GameGenreEntityId);
        }
    }
}
