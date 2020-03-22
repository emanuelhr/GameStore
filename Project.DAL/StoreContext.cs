using Microsoft.EntityFrameworkCore;


using Project.DAL.Entities;
using Project.DAL.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL
{
    public class StoreContext : DbContext, IStoreContext
    {

        

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
           
           // Database.EnsureCreated();
        }
        public DbContext Instance => this;

        #region Entities
        public DbSet<CartEntity> Carts { get; set; }
        public DbSet<DeveloperEntity> Developers { get; set; }
        public DbSet<GameEntity> Games { get; set; }
        public DbSet<GameGenreEntity> Genres { get; set; }

       
        #endregion



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                        

          //  modelBuilder.ApplyConfiguration(new CartEntityConfig());
         //   modelBuilder.ApplyConfiguration(new DeveloperEntityConfig());
            modelBuilder.ApplyConfiguration(new GameGenreGameEntityConfig());
            modelBuilder.ApplyConfiguration(new CartsGamesEntityConfig());
            modelBuilder.ApplyConfiguration(new GameEntityConfig());        
                                 
            base.OnModelCreating(modelBuilder);
        }


       // private string _connectionString = @"Data Source=DESKTOP-I4S93V3\SQLEXPRESS;Initial Catalog=GameStore;Integrated Security=True";
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    //optionsBuilder.UseSqlServer(_connectionString);
        //}

    }
    
}
