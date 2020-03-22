using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class CartsGamesEntity
    {
        public int CartEntityId { get; set; }
        public CartEntity CartEntity { get; set; }
        public int GameEntityId { get; set; }
        public GameEntity GameEntity { get; set; }
    }
}
