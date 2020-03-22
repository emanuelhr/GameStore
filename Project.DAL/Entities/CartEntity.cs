using Project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class CartEntity
    {

        public CartEntity()
        {
            CartsGames = new Collection<CartsGamesEntity>();
        }
        
       public int Id { get; set; }

        public ICollection<CartsGamesEntity> CartsGames { get; set; } 
        
       [DataType("smallmoney")]
       public double TotalPrice { get; set; }

        

       





    }
}
