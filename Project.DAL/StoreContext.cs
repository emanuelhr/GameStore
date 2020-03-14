using Microsoft.EntityFrameworkCore;

using Project.DAL.Entities;
using Project.DAL.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL
{
    public class StoreContext : DbContext, IStoreContext
    {

       
        public DbSet<CartEntity> Carts { get ; set; }
        public DbSet<DeveloperEntity> Developers { get; set; }
        public DbSet<GameEntity> Games { get; set; }
        public DbSet<GameGenreEntity> Genres { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CartEntityConfig());
            modelBuilder.ApplyConfiguration(new DeveloperEntityConfig());
            modelBuilder.ApplyConfiguration(new GameGenreGameEntityConfig());
            
            #region GameEntity

            modelBuilder.Entity<GameEntity>()
                .Property(p => p.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20)
                .IsRequired();
            modelBuilder.Entity<GameEntity>()
                .Property(p => p.Developer)
                .IsRequired();
            modelBuilder.Entity<GameEntity>()
                .Property(p => p.Price)
                .HasColumnType("SMALLMONEY")
                .IsRequired();
            #endregion




            base.OnModelCreating(modelBuilder);
        }

    }
    
}
