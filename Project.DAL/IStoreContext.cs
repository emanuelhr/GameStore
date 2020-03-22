using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL
{
    public interface IStoreContext : IDbContext
    {

        DbSet<CartEntity> Carts { get; set; }
        DbSet<DeveloperEntity> Developers { get; set; }
        DbSet<GameEntity> Games { get; set; }
        DbSet<GameGenreEntity> Genres { get; set; }

       
    }
}
